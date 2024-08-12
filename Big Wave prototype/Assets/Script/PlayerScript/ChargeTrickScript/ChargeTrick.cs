using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//☆作成者:杉山
//トリックのチャージ関連
public class ChargeTrick : MonoBehaviour
{
    //波の内側に波乗りしているときはoutSideChargeTrick、inSideChargeTrickの合計分トリックが増える
    private bool chargeStandby = false;//これがtrueになっている時かつ波に触れている時のみトリックをチャージできる
    JudgeChargeNow judgeChargeNow;
    TRICKPoint player_TrickPoint;
    FeverMode feverMode;
    ChangeChargeTrickTheSurfer changeChargeTrickTheSurfer;
    ChangeChargeTrickTheCharger changeChargeTrickTheCharger;

    public bool ChargeStandby
    {
        get { return chargeStandby; }
        set { chargeStandby = value; }
    }
  
    // Start is called before the first frame update
    void Start()
    {
        player_TrickPoint = gameObject.GetComponent<TRICKPoint>();
        feverMode = gameObject.GetComponent<FeverMode>();
        changeChargeTrickTheSurfer=gameObject.GetComponent<ChangeChargeTrickTheSurfer>();
        judgeChargeNow=gameObject.GetComponent<JudgeChargeNow>();
        changeChargeTrickTheCharger=gameObject.GetComponent<ChangeChargeTrickTheCharger>(); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    //波に触れてトリックをチャージ
    public void ChargeTrickTouchingWave(float chargeAmount)
    {
        if(chargeStandby)
        {
            player_TrickPoint.Charge(ChargeTrickAmount(chargeAmount));//トリックをチャージ
            judgeChargeNow.ResetSinceLastChargedTime();//最後にチャージされてからの時間をリセット
        }
    }

    float ChargeTrickAmount(float chargeAmount)//チャージされるトリック量(
    {
        float ret=chargeAmount;//通常時のチャージされるトリック量
        ret *= feverMode.CurrentChargeTrick_GrowthRate;//フィーバー状態のチャージ倍率
        ret *= changeChargeTrickTheCharger.ChargeRate();//満タンのトリックゲージの数によるチャージ倍率
        ret *= changeChargeTrickTheSurfer.CurrentChargeRate;//波に乗っている時間によるチャージ倍率
        return ret;
    }
}





