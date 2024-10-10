using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

//作成者:杉山
//トリックのチャージ
public class ChargeTrickPoint : MonoBehaviour
{
    [Header("必要なコンポーネント")]
    [SerializeField] ChangeChargeRateTheChargers changeChargeRateTheChargers;
    [SerializeField] FeverMode feverMode;
    [SerializeField] TrickPoint player_TrickPoint;
    [SerializeField] JudgeChargeTrickPointNow judgeChargeTrickPointNow;
    [SerializeField] ChangeChargeRateTheSurfer changeChargeRateTheSurfer;
    private bool chargeStandby = false;//これがtrueになっている時かつ波に触れている時のみトリックをチャージできる

    /////private(別クラスは使用不可)のメソッド/////

    float ChargeTrickAmount(float chargeAmount)//チャージされるトリック量
    {
        float ret = chargeAmount;//通常時のチャージされるトリック量
        ret *= feverMode.CurrentChargeTrick_GrowthRate;//フィーバー状態のチャージ倍率
        ret *= changeChargeRateTheChargers.ChargeRate(player_TrickPoint.MaxCount,player_TrickPoint.TrickGaugeNum);//満タンのトリックゲージの数によるチャージ倍率
        ret *= changeChargeRateTheSurfer.ChargeRate();//波に乗っている時間によるチャージ倍率
        return ret;
    }


    /////public(別クラスも使用可能)のメソッド/////

    public bool ChargeStandby
    {
        get { return chargeStandby; }
        set { chargeStandby = value; }
    }

   
    public void Charge(float chargeAmount)//トリックのチャージ
    {
        if (chargeStandby)
        {
            player_TrickPoint.Charge(ChargeTrickAmount(chargeAmount));//トリックをチャージ
            judgeChargeTrickPointNow.ResetSinceLastChargedTime();//最後にチャージされてからの時間をリセット
        }
    }
}
