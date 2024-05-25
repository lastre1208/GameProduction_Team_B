using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField] float chargeTrick_VibrationSpeed=0.35f;//トリックチャージ時のバイブの速さ
    MoveControl moveControl;
    JumpControl jumpControl;
    ChargeTrickControl chargeTrickControl;
    AttackControl attackControl;
    private Gamepad gamepad = Gamepad.current;
    // Start is called before the first frame update
    void Start()
    {
        moveControl = gameObject.GetComponent<MoveControl>();
        jumpControl = gameObject.GetComponent<JumpControl>();
        chargeTrickControl = gameObject.GetComponent<ChargeTrickControl>();
        attackControl= gameObject.GetComponent<AttackControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();//プレイヤーの動き

        Jump();//ジャンプ

        Attack();//攻撃
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
        }
    }


    //攻撃関連
    void Attack()//攻撃
    {
        if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("j"))//JキーかXボタンを押した時強攻撃
        {
            attackControl.Attack_Strong();
        }

        if(Input.GetButtonDown("Fire2") || Input.GetKeyDown("k"))//KキーかBボタンを押した時中攻撃
        {
            attackControl.Attack_Medium();
        }

        if(Input.GetButtonDown("Fire3") || Input.GetKeyDown("l"))//LキーかAボタンを押した時弱攻撃
        {
            attackControl.Attack_Weak();
        }
    }

    void VibrateController_Attack()//攻撃時コントローラーがバイブする
    {

    }


    //トリックのチャージ関連
    void ChargeTrick(Collider wavePrefab)//波に乗ってトリックをチャージ
    {
        //スペースキーやボタンを押している間チャージ
        if (Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space"))
        {
            chargeTrickControl.ChargeTrick(wavePrefab);
        }

        VibrateController_Charge();//チャージしている間コントローラーがバイブする
    }

    void VibrateController_Charge()//チャージしている間コントローラーがバイブする
    {
        if(chargeTrickControl.chargeNow)
        {
            if (gamepad != null)//ゲームパッドが接続されていれば振動を発生させる(二つの引数はそれぞれ左右のモーターの振動の強さ)
            {
                gamepad.SetMotorSpeeds(chargeTrick_VibrationSpeed, chargeTrick_VibrationSpeed);
            }
        }
        else
        {
            StopVibration();
        }
    }

    //バイブを止める
    void StopVibration()
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0f, 0f);
        }
    }
}
