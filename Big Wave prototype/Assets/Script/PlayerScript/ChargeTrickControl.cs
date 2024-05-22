using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ChargeTrickControl : MonoBehaviour
{
    //波の内側に波乗りしているときはoutSideChargeTrick、inSideChargeTrickの合計分トリックが増える
    [SerializeField] float outSideChargeTrick=1;//波の外側に波乗りした時に溜まるトリックの値
    [SerializeField] float inSideChargeTrick=2;//波の内側(中央)に波乗りした時に溜まるトリックの値
    [SerializeField] GameObject chargeSpark;//チャージ用の雷エフェクト
    private bool chargeNow=false;//今トリックをチャージしているか
    private float sinceLastChargeTime = 0.1f;//最後にチャージされてからの時間
    private float chargeBorderTime = 0.1f;//チャージしていない・しているの境界の時間
    JudgeTouchWave touchWave;
    Player player;
    Wave wave;
  //コントローラーの接続を確認
    // Start is called before the first frame update
    void Start()
    {
        touchWave = gameObject.GetComponent<JudgeTouchWave>();
        player = gameObject.GetComponent<Player>();
        chargeSpark.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayChargeSpark();//波に触っているかつトリックをチャージしている時のみチャージ用の雷エフェクトを表示

        JudgeChargeNow();//今チャージしているか判定
    }

    void OnTriggerEnter(Collider t)
    {
        if(t.gameObject.CompareTag("InsideWave")|| t.gameObject.CompareTag("OutsideWave"))//波に触れているならWaveの情報(isTouched)を取得
        {
            wave = t.GetComponent<Wave>();
        }

        //スペースキーやボタンを押している間チャージ、一度も触れていない内側の波からチャージする
        if ((Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space")) && t.gameObject.CompareTag("InsideWave")&&wave.isTouched==false)
        {
            //トリックをチャージ、一度触れた波からはチャージできないようにする(触った判定にする)、チャージ用の雷エフェクトを表示
            player.ChargeTRICK(inSideChargeTrick);
            wave.isTouched = true;
            sinceLastChargeTime = 0f;

        }

        //スペースキーやボタンを押している間チャージ、一度触れていない外側の波からチャージする
        else if ((Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space")) && t.gameObject.CompareTag("OutsideWave") && wave.isTouched == false)
        {
            //トリックをチャージ、一度触れた波からはチャージできないようにする(触った判定にする)、チャージ用の雷エフェクトを表示
            player.ChargeTRICK(outSideChargeTrick);
            wave.isTouched = true;
            sinceLastChargeTime = 0f;
        }
    }

    void JudgeChargeNow()//今チャージしているか判定
    {
        sinceLastChargeTime += Time.deltaTime;

        if (sinceLastChargeTime < chargeBorderTime)
        {
            chargeNow = true;

            if (player.gamepad != null)//ゲームパッドが接続されていれば振動を発生させる(二つの引数はそれぞれ左右のモーターの振動の強さ)
            {
                player.gamepad.SetMotorSpeeds(0.35f, 0.35f);
            }
           
        }
        else
        {
            chargeNow = false;

           player.gamepad.SetMotorSpeeds(0f,0f);//振動の解除！！！毎回必ず行う事！！！でないとゲーム止まっても振動し続ける事になる！！！

        }
    }

    void DisplayChargeSpark()//波に触っているかつトリックをチャージしている時のみチャージ用の雷エフェクトを表示
    {
        if(chargeNow&&touchWave.touchWaveNow)
        {
            chargeSpark.SetActive(true);
        }
        else
        {
            chargeSpark.SetActive(false);
        }
    }
}
