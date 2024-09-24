using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//作成者:杉山
//現在チャージしているかの判定
public class JudgeChargeTrickPointNow : MonoBehaviour
{
    [Header("チャージしていない・しているの境界の時間")]
    [SerializeField] float chargedBorderTime = 0.1f;//チャージしていない・しているの境界の時間
    [Header("チャージ開始瞬間の処理")]
    [SerializeField] MomentEvent startChargeEvents;//チャージ開始瞬間の処理
    [Header("チャージ終了瞬間の処理")]
    [SerializeField] MomentEvent endChargeEvents;//チャージ終了瞬間の処理
    private float sinceLastChargedTime;//最後にチャージされてからの時間
    bool chargeNow = false;//現在チャージしているか
    bool chargeNowBeforeFrame;//前のフレームのチャージしているかの判定

    void Start()
    {
        sinceLastChargedTime = chargedBorderTime;//初期の最後にチャージされてからの時間をチャージの境界時間に設定
        chargeNowBeforeFrame = chargeNow;
    }

    void Update()
    {
        UpdateChargeNow();

        startChargeEvents.ActivateMomentEvent(chargeNow,chargeNowBeforeFrame,true);//前のフレームでチャージされていなかったかつ現在のフレームでチャージされていたら処理を行う

        endChargeEvents.ActivateMomentEvent(chargeNow, chargeNowBeforeFrame, false);//前のフレームでチャージされていたかつ現在のフレームでチャージされていなかったら処理を行う

        chargeNowBeforeFrame = chargeNow;
    }

    //チャージ状況の更新
    void UpdateChargeNow()
    {
        sinceLastChargedTime += Time.deltaTime;

        if (sinceLastChargedTime < chargedBorderTime)//最後にチャージしてからchargeBorderTime(秒)未満なら今チャージしてる判定
        {
            chargeNow = true;
        }
        else
        {
            chargeNow = false;
        }
    }

    public bool ChargeNow()//今チャージしているか
    {
        return chargeNow;
    }

    public void ResetSinceLastChargedTime()//最後にチャージされてからの時間をリセット
    {
        sinceLastChargedTime = 0;
    }
}
