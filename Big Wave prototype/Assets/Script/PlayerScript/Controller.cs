using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

//☆作成者:杉山

public class Controller : MonoBehaviour
{
    [SerializeField] ControllerOfJump controllerOfJump;//ジャンプ関係のコントローラーの処理、(注)[SerializeField]書かないとエラー起きちゃう
    [Header("ポーズ関係")]
    [SerializeField] ControllerOfPause controllerOfPause;//ポーズ関係のコントローラーの処理
    [Header("トリック関係")]
    [SerializeField] ControllerOfTrick controllerOfTrick;//トリック関係のコントローラの処理
    [Header("トリックのチャージ関係")]
    [SerializeField] ControllerOfChargeTrick controllerOfChargeTrick;//トリックのチャージ関係のコントローラの処理

    JumpControl jumpControl;
    ChargeTrick chargeTrick;
    TrickControl trickControl;
    JudgeChargeNow judgeChargeNow;

    private Gamepad gamepad = Gamepad.current;

    // Start is called before the first frame update
    void Start()
    {
        jumpControl = gameObject.GetComponent<JumpControl>();
        chargeTrick = gameObject.GetComponent<ChargeTrick>();
        trickControl= gameObject.GetComponent<TrickControl>();
        judgeChargeNow= gameObject.GetComponent<JudgeChargeNow>();

        controllerOfJump.Start(jumpControl);
        controllerOfTrick.Start(trickControl, gamepad);
        controllerOfChargeTrick.Start(judgeChargeNow, chargeTrick, gamepad);
    }

    // Update is called once per frame
    void Update()
    {
        controllerOfJump.Update();
        controllerOfPause.Update();
        controllerOfTrick.Update();
        controllerOfChargeTrick.Update();
    }

    public void Vibe_Trick()//トリックのバイブ
    {
        controllerOfTrick.Vibe();
    }
}





[System.Serializable]
class ControllerOfPause//ポーズ関係のコントローラーの処理
{
    [Header("ポーズ画面")]
    [SerializeField] PauseControl pauseControl;//ポーズ画面

    internal void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Pause")) // Pキーが押されたら
        {
            pauseControl.TogglePause(); // ポーズの切り替え
        }
    }
}




[System.Serializable]
class ControllerOfJump//ジャンプ関係のコントローラーの処理
{
    JumpControl jumpControl;

    internal void Start(JumpControl j)
    {
        jumpControl = j;
    }

    internal void Update()//ジャンプ
    {
        //スペースキーかLBボタンかRBボタンでジャンプ
        if (Input.GetKeyUp(KeyCode.JoystickButton5) || Input.GetKeyUp(KeyCode.JoystickButton4) || Input.GetKeyUp("space"))
        {
            jumpControl.Jump();
        }
    }
}





[System.Serializable]
class ControllerOfTrick//トリック関係のコントローラーの処理
{
    [Header("トリックを決めた時のバイブの速さ")]
    [Range(0, 1)]
    [SerializeField] float vibrationSpeed = 1f;//トリックを決めた時のバイブの速さ
    [Header("トリックを決めた時の振動の時間")]
    [SerializeField] float vibeTime = 0.2f;//トリックを決めた時の振動の時間
    private float remainingVibeTime = 0f;//トリックの振動の残り時間(内部用)

    TrickControl trickControl;
    Gamepad gamepad;

    internal void Start(TrickControl t,Gamepad g)
    {
        trickControl = t;
        gamepad = g;
    }

    internal void Update()
    {
        Trick();

        VibrateController();
    }

    void Trick()//トリック
    {
        if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("h"))//HキーかYボタン
        {
            trickControl.Trick(Button.Y);
        }
        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown("j"))//JキーかXボタン
        {
            trickControl.Trick(Button.X);
        }
        if (Input.GetButtonDown("Fire4") || Input.GetKeyDown("k"))//KキーかBボタン
        {
            trickControl.Trick(Button.B);
        }
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("l"))//LキーかAボタン
        {
            trickControl.Trick(Button.A);
        }

        //自分(杉山)のコントローラー用
        //if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("h"))//HキーかYボタン
        //{
        //    trickControl.Trick(Button.Y);
        //}
        //if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("j"))//JキーかXボタン
        //{
        //    trickControl.Trick(Button.X);
        //}
        //if (Input.GetButtonDown("Fire2") || Input.GetKeyDown("k"))//KキーかBボタン
        //{
        //    trickControl.Trick(Button.B);
        //}
        //if (Input.GetButtonDown("Fire4") || Input.GetKeyDown("l"))//LキーかAボタン
        //{
        //    trickControl.Trick(Button.A);
        //}
    }

    void VibrateController()//トリック時コントローラーがバイブする
    {
        remainingVibeTime -= Time.deltaTime;

        if(gamepad!=null)
        {
            if (remainingVibeTime > 0)
            {
                gamepad.SetMotorSpeeds(vibrationSpeed,vibrationSpeed);//バイブさせる
            }
            else
            {
                gamepad.SetMotorSpeeds(0f, 0f);//バイブを止める
            }
        }
    }

    internal void Vibe()//トリック時にバイブしてほしいときこれを呼ぶ
    {
        remainingVibeTime = vibeTime;
    }
}





[System.Serializable]
class ControllerOfChargeTrick//トリックのチャージ関係の処理
{
    [Header("トリックをチャージしている時のバイブの速さ")]
    [Range(0,1)]
    [SerializeField] float vibrationSpeed = 1f;//トリックをチャージしている時のバイブの速さ

    JudgeChargeNow judgeChargeNow;
    ChargeTrick chargeTrick;
    Gamepad gamepad;

    internal void Start(JudgeChargeNow j,ChargeTrick c,Gamepad g)
    {
        judgeChargeNow = j;
        chargeTrick = c;
        gamepad = g;
    }

    internal void Update()
    {
        ChargeStandbyOn();

        VibrateController();
    }

    void ChargeStandbyOn()//波に触れてトリックがチャージできるようにする
    {
        //スペースキーやボタンを押している間は波に触れてチャージができるようになる
        if (Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space"))
        {
            chargeTrick.ChargeStandby = true;
        }
        else 
        {
            chargeTrick.ChargeStandby = false;
        }
    }

    void VibrateController()//チャージしている間コントローラが振動
    {
        if (gamepad != null)
        {
            if (judgeChargeNow.ChargeNow())
            {
                gamepad.SetMotorSpeeds(vibrationSpeed, vibrationSpeed);//バイブさせる
            }
            else
            {
                gamepad.SetMotorSpeeds(0f, 0f);//バイブを止める
            }
        }
    }
}
