using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeTrickControl : MonoBehaviour
{
    //波の内側に波乗りしているときはoutSideChargeTrick、inSideChargeTrickの合計分トリックが増える
    [SerializeField] float outSideChargeTrick=1;//波の外側に波乗りした時に溜まるトリックの値
    [SerializeField] float inSideChargeTrick=2;//波の内側(中央)に波乗りした時に溜まるトリックの値
    [SerializeField] GameObject chargeSpark;//チャージ用の雷エフェクト
    private bool chargeNow=false;//今トリックをチャージしているか
    Player player;
    JumpControl jumpControl;
    Wave wave;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
        jumpControl = gameObject.GetComponent<JumpControl>();
        chargeSpark.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayChargeSpark();//波に触っているかつトリックをチャージしている時のみチャージ用の雷エフェクトを表示
    }

    void OnTriggerEnter(Collider t)
    {
        if(t.gameObject.CompareTag("InsideWave")|| t.gameObject.CompareTag("OutsideWave"))//波に触れているならWaveの情報(isTouched)を取得
        {
            wave = t.GetComponent<Wave>();
        }

        if ((Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space")) && t.gameObject.CompareTag("InsideWave")&&wave.isTouched==false)//スペースキーやボタンを押している間チャージ、一度も触れていない内側の波からチャージする
        {
            //トリックをチャージ、一度触れた波からはチャージできないようにする(触った判定にする)、チャージ用の雷エフェクトを表示
            player.ChargeTRICK(inSideChargeTrick);
            wave.isTouched = true;
            chargeNow = true;
            
        }

        else if((Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space")) && t.gameObject.CompareTag("OutsideWave") && wave.isTouched == false)//スペースキーやボタンを押している間チャージ、一度触れていない外側の波からチャージする
        {
            //トリックをチャージ、一度触れた波からはチャージできないようにする(触った判定にする)、チャージ用の雷エフェクトを表示
            player.ChargeTRICK(outSideChargeTrick);
            wave.isTouched = true;
            chargeNow = true;
        }

        else
        {
            chargeNow = false;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.gameObject.CompareTag("InsideWave")|| other.gameObject.CompareTag("InsideWave"))//波から離れたらチャージ用の雷エフェクトを非表示
    //    {
    //        chargeSpark.SetActive(false);
    //    }
    //}

    void DisplayChargeSpark()//波に触っているかつトリックをチャージしている時のみチャージ用の雷エフェクトを表示
    {
        if(chargeNow==true&&(jumpControl.touchInsideWaveNow ==true|| jumpControl.touchOutsideWaveNow == true))
        {
            chargeSpark.SetActive(true);
        }
        else
        {
            chargeSpark.SetActive(false);
        }
    }
}
