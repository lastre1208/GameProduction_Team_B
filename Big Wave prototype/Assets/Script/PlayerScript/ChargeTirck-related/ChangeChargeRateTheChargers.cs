using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//現在のトリック量によりチャージ倍率を変化させる
public class ChangeChargeRateTheChargers : MonoBehaviour
{
    [Header("チャージ倍率(トリックゲージの個数分配列を用意してください)")]
    [SerializeField] float[] chargeRate;//チャージ倍率

    //満タンのゲージの数に対応したチャージ倍率を返す
    //引数のmaxCountにはプレイヤーの満タンのトリックゲージの個数、引数のtrickGaugeNumにはプレイヤーのトリックゲージの個数を入れる
    public float ChargeRate(int maxCount, int trickGaugeNum)
    {
        maxCount = Mathf.Clamp(maxCount, 0, trickGaugeNum - 1);
        return chargeRate[maxCount];
    }
}
