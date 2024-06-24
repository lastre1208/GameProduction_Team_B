using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeTrickFromWaveControl : MonoBehaviour
{
    //☆塩が書いた
    //波の内側に波乗りしているときはoutSideChargeTrick、inSideChargeTrickの合計分トリックが増える
    [Header("チャージ倍率(トリックゲージの個数分配列を用意してください)")]
    [SerializeField] float[] chargeRate;//チャージ倍率
    [Header("波の外側に波乗りした時に溜まるトリックの値")]
    [SerializeField] float outSideChargeTrick=1;//波の外側に波乗りした時に溜まるトリックの値
    [Header("波の内側(中央)に波乗りした時に溜まるトリックの値")]
    [SerializeField] float inSideChargeTrick=2;//波の内側(中央)に波乗りした時に溜まるトリックの値
    [Header("チャージ用の雷エフェクト")]
    [SerializeField] GameObject chargeSpark;//チャージ用の雷エフェクト
    private bool chargeNow=false;//今トリックをチャージしているか
    private float sinceLastChargeTime = 0.1f;//最後にチャージされてからの時間
    private float chargeBorderTime = 0.1f;//チャージしていない・しているの境界の時間
    JudgeTouchWave touchWave;
    Player player;
    Wave wave;
    BuffOfPlayer buffOfPlayer;
    ProcessFeverMode processFeverPoint;
  
    public bool ChargeNow
    {
        get { return chargeNow; }
    }

    // Start is called before the first frame update
    void Start()
    {
        touchWave = gameObject.GetComponent<JudgeTouchWave>();
        player = gameObject.GetComponent<Player>();
        buffOfPlayer = gameObject.GetComponent<BuffOfPlayer>();
        processFeverPoint = gameObject.GetComponent<ProcessFeverMode>();
        chargeSpark.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayChargeSpark();//波に触っているかつトリックをチャージしている時のみチャージ用の雷エフェクトを表示

        JudgeChargeNow();//今チャージしているか判定
    }

    //波に触れてトリックをチャージ
    public void ChargeTrickTouchingWave(Collider wavePrefab)
    {
        wave = wavePrefab.GetComponent<Wave>();//Waveの情報(isTouched)を取得

        //一度も触れていない内側の波からチャージする
        if (wavePrefab.CompareTag("InsideWave") && wave.IsTouched == false)
        {
            ProcessingChargeTrick(inSideChargeTrick);
        }

        //一度触れていない外側の波からチャージする
        else if (wavePrefab.CompareTag("OutsideWave") && wave.IsTouched == false)
        {
            ProcessingChargeTrick(outSideChargeTrick);
        }
    }

    float ChargeTrickAmount(float b)//チャージされるトリック量(bにはinSideChargeTrickかoutSideChargeTrickが入る)
    {
        return b * buffOfPlayer.ChargeTrick.CurrentGrowthRate * processFeverPoint.CurrentChargeTrick_GrowthRate * chargeRate[player.MaxCount];
    }

    //波に触れてトリックをチャージするときの内部の処理
    //a(引数)にはinSideChargeTrickかoutSideChargeTrickを入れる(溜まるトリック量)
    void ProcessingChargeTrick(float a)
    {
        if(player.MaxCount!=player.TrickGaugeNum)
        {
            player.ChargeTrickPoint(ChargeTrickAmount(a));//トリックをチャージ
        }
        
        wave.IsTouched = true;//一度触れた波からはチャージできないようにする(触った判定にする)
        sinceLastChargeTime = 0f;//今チャージしている判定にする
    }



    void JudgeChargeNow()//今チャージしているか判定
    {
        sinceLastChargeTime += Time.deltaTime;

        if (sinceLastChargeTime < chargeBorderTime)//最後にチャージしてからchargeBorderTime(秒)未満なら今チャージしてる判定
        {
            chargeNow = true;
        }
        else
        {
            chargeNow = false;
        }
    }



    void DisplayChargeSpark()//波に触っているかつトリックをチャージしている時のみチャージ用の雷エフェクトを表示
    {
        if(ChargeNow&&touchWave.TouchWaveNow)
        {
            chargeSpark.SetActive(true);
        }
        else
        {
            chargeSpark.SetActive(false);
        }
    }
}
