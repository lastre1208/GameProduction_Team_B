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
    ChargeTrickPoint chargeTrick;
    TrickControl trickControl;
    PushedButton_CurrentTrickPattern pushedButton_TrickPattern;
    private Gamepad gamepad = Gamepad.current;

    // Start is called before the first frame update
    void Start()
    {
        jumpControl = gameObject.GetComponent<JumpControl>();
        chargeTrick = gameObject.GetComponent<ChargeTrickPoint>();
        trickControl= gameObject.GetComponent<TrickControl>();
        pushedButton_TrickPattern=gameObject.GetComponent<PushedButton_CurrentTrickPattern>();

        controllerOfJump.Start(jumpControl);
        controllerOfTrick.Start(trickControl, pushedButton_TrickPattern ,gamepad);
        controllerOfChargeTrick.Start(chargeTrick, gamepad);
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



    /////内部クラス/////

    [System.Serializable]
    private class ControllerOfPause//ポーズ関係のコントローラーの処理
    {
        [Header("ポーズ画面")]
        [SerializeField] PauseControl pauseControl;//ポーズ画面

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Pause")) // Pキーが押されたら
            {
                pauseControl.TogglePause(); // ポーズの切り替え
            }
        }
    }




    [System.Serializable]
    private class ControllerOfJump//ジャンプ関係のコントローラーの処理
    {
        JumpControl jumpControl;

        public void Start(JumpControl j)
        {
            jumpControl = j;
        }

        public void Update()//ジャンプ
        {
            //スペースキーかLBボタンかRBボタンでジャンプ
            if (Input.GetKeyUp(KeyCode.JoystickButton5) || Input.GetKeyUp(KeyCode.JoystickButton4) || Input.GetKeyUp("space"))
            {

                jumpControl.Jump();
            }
        }
    }





    [System.Serializable]
    private class ControllerOfTrick//トリック関係のコントローラーの処理
    {
        [Header("トリックを決めた時のバイブの速さ")]
        [Range(0, 1)]
        [SerializeField] float vibrationSpeed = 1f;//トリックを決めた時のバイブの速さ
        [Header("トリックを決めた時の振動の時間")]
        [SerializeField] float vibeTime = 0.2f;//トリックを決めた時の振動の時間
        private float remainingVibeTime = 0f;//トリックの振動の残り時間(内部用)

        TrickControl trickControl;
        PushedButton_CurrentTrickPattern pushedButton_TrickPattern;
        Gamepad gamepad;

        public void Start(TrickControl t, PushedButton_CurrentTrickPattern p ,Gamepad g)
        {
            trickControl = t;
            pushedButton_TrickPattern = p;
            gamepad = g;
        }

        public void Update()
        {
            Trick();

            VibrateController();
        }

        void Trick()//トリック
        {
            if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("h"))//HキーかYボタン
            {
                Trick_Process(Button.Y);
            }
            else if (Input.GetButtonDown("Fire2") || Input.GetKeyDown("j"))//JキーかXボタン
            {
                Trick_Process(Button.X);
            }
            else if (Input.GetButtonDown("Fire4") || Input.GetKeyDown("k"))//KキーかBボタン
            {
                Trick_Process(Button.B);
            }
            else if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("l"))//LキーかAボタン
            {
                Trick_Process(Button.A);
            }

            //自分(杉山)のコントローラー用
            //if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("h"))//HキーかYボタン
            //{
            //    Trick_Process(Button.Y);
            //}
            //else if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("j"))//JキーかXボタン
            //{
            //    Trick_Process(Button.X);
            //}
            //else if (Input.GetButtonDown("Fire2") || Input.GetKeyDown("k"))//KキーかBボタン
            //{
            //    Trick_Process(Button.B);
            //}
            //else if (Input.GetButtonDown("Fire4") || Input.GetKeyDown("l"))//LキーかAボタン
            //{
            //     Trick_Process(Button.A);
            //}
        }

        void Trick_Process(Button button)
        {
            pushedButton_TrickPattern.SetTrickPattern(button);//押されたボタンの種類を設定
            trickControl.Trick();//トリック
        }


        void VibrateController()//トリック時コントローラーがバイブする
        {
            remainingVibeTime -= Time.deltaTime;

            if (gamepad != null)
            {
                if (remainingVibeTime > 0)
                {
                    gamepad.SetMotorSpeeds(vibrationSpeed, vibrationSpeed);//バイブさせる
                }
                else
                {
                    gamepad.SetMotorSpeeds(0f, 0f);//バイブを止める
                }
            }
        }

        public void Vibe()//トリック時にバイブしてほしいときこれを呼ぶ
        {
            remainingVibeTime = vibeTime;
        }
    }





    [System.Serializable]
    private class ControllerOfChargeTrick//トリックのチャージ関係の処理
    {
        [Header("トリックをチャージしている時のバイブの速さ")]
        [Range(0, 1)]
        [SerializeField] float vibrationSpeed = 1f;//トリックをチャージしている時のバイブの速さ

        ChargeTrickPoint chargeTrick;
        Gamepad gamepad;

        public void Start(ChargeTrickPoint c, Gamepad g)
        {
            chargeTrick = c;
            gamepad = g;
        }

        public void Update()
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
                if (chargeTrick.ChargeNow())
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



}






