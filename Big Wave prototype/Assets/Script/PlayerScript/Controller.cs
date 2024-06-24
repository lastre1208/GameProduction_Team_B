using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    //☆塩が書いた
    [Header("トリックチャージ時のバイブの速さ")]
    [SerializeField] float chargeTrick_VibrationSpeed=0.35f;//トリックチャージ時のバイブの速さ
    [SerializeField] float trick_VibrationSpeed = 0.35f;//トリックチャージ時のバイブの速さ
    [SerializeField] float trickVibeTime = 0f;//トリックの振動の時間
    private float remainingTrickVibeTime = 0f;//トリックの振動の残り時間(内部用)

    MoveControl moveControl;
    JumpControl jumpControl;
    ChargeTrickFromWaveControl chargeTrickControl;
    TrickControl trickControl;
    private Gamepad gamepad = Gamepad.current;
    // Start is called before the first frame update
    void Start()
    {
        moveControl = gameObject.GetComponent<MoveControl>();
        jumpControl = gameObject.GetComponent<JumpControl>();
        chargeTrickControl = gameObject.GetComponent<ChargeTrickFromWaveControl>();
        trickControl= gameObject.GetComponent<TrickControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();//プレイヤーの動き

        Jump();//ジャンプ

        Trick();//攻撃
        
        VibrateController_Charge();//チャージしている間コントローラが振動

        VibrateController_Trick();//トリックした時にコントローラが振動
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InsideWave") || other.CompareTag("OutsideWave"))
        {
            ChargeTrick(other);//波に触れている間乗ってトリックをチャージ
        }
    }


    //移動関連
    void Move()//プレイヤーの動き
    {
        //左右キーか右スティック(左右に動かす)でキャラが左右に動く
        moveControl.Move();
    }


    //ジャンプ関連
    void Jump()//ジャンプ
    {
        //スペースキーかLBボタンかRBボタンでジャンプ
        if (Input.GetKeyUp(KeyCode.JoystickButton5) || Input.GetKeyUp(KeyCode.JoystickButton4) || Input.GetKeyUp("space"))
        {
            jumpControl.Jump();
            StopVibration();
        }
    }


    //攻撃関連
    void Trick()//攻撃
    {
        if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("j"))//JキーかXボタンを押した時バフ
        {
            trickControl.Trick_Buff();
        }

        if(Input.GetButtonDown("Fire2") || Input.GetKeyDown("k"))//KキーかBボタンを押した時攻撃
        {
            trickControl.Trick_attack();
        }

        if(Input.GetButtonDown("Fire3") || Input.GetKeyDown("l"))//LキーかAボタンを押した時回復
        {
            trickControl.Trick_Heal();
        }
    }

    void VibrateController_Trick()//攻撃時コントローラーがバイブする
    {
        remainingTrickVibeTime -= Time.deltaTime;

        if(remainingTrickVibeTime>0)
        {
            Vibration(trick_VibrationSpeed);//バイブさせる
        }
        else
        {
            StopVibration();//バイブを止める
        }
    }

    public void Vibe_Trick()//トリック時にバイブしてほしいときこれを呼ぶ
    {
        remainingTrickVibeTime = trickVibeTime;
    }

    public void StopVibe_Trick()//バイブ止めるための応急処置
    {
        remainingTrickVibeTime = 0;
    }

    //トリックのチャージ関連
    void ChargeTrick(Collider wavePrefab)//波に乗ってトリックをチャージ
    {
        //スペースキーやボタンを押している間チャージ
        if (Input.GetKey(KeyCode.JoystickButton5)  ||Input.GetKey(KeyCode.JoystickButton4)||  Input.GetKey("space"))
        {
            chargeTrickControl.ChargeTrickTouchingWave(wavePrefab);
        }
    }

    void VibrateController_Charge()//チャージしている間コントローラが振動
    {
        if (chargeTrickControl.ChargeNow)
        {
            Vibration(chargeTrick_VibrationSpeed);//バイブさせる
        }
        else
        {
            StopVibration();//バイブを止める
        }
    }


    //バイブ関連
    //バイブさせる
    //a(引数)にはバイブのスピードを入れる(0～1fまで)
    void Vibration(float a)
    {
        if (gamepad != null)//ゲームパッドが接続されていれば振動を発生させる(二つの引数はそれぞれ左右のモーターの振動の強さ)
        {
            gamepad.SetMotorSpeeds(a, a);
        }
    }

    //バイブを止める
    public void StopVibration()
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0f, 0f);
        }
    }



}
