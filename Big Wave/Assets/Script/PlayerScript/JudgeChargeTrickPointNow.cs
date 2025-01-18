using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

//作成者:杉山
//現在チャージしているかの判定
public class JudgeChargeTrickPointNow : MonoBehaviour
{
    [Header("チャージしていない・しているの境界の時間")]
    [SerializeField] float chargedBorderTime = 0.1f;//チャージしていない・しているの境界の時間
    public event Action StartChargeAction;//チャージ状態開始の瞬間に呼ぶ
    public event Action EndChargeAction;//チャージ状態終了の瞬間に呼ぶ
    public event Action<bool> SwitchChargeAction;//チャージ状態の切り替わり時に呼ぶ(trueであればチャージ開始、falseであればチャージ終了)
    private float sinceLastChargedTime;//最後にチャージされてからの時間
    bool chargeNow = false;//現在チャージしているか
    bool chargeNowBeforeFrame;//前のフレームのチャージしているかの判定

    public bool ChargeNow()//今チャージしているか
    {
        return chargeNow;
    }

    public void ResetSinceLastChargedTime()//最後にチャージされてからの時間をリセット
    {
        sinceLastChargedTime = 0;
    }

    void Start()
    {
        sinceLastChargedTime = chargedBorderTime;//初期の最後にチャージされてからの時間をチャージの境界時間に設定
        chargeNowBeforeFrame = chargeNow;
    }

    void Update()
    {
        UpdateChargeNow();

        CallChargeAction();

        chargeNowBeforeFrame = chargeNow;
    }

    //チャージ状況が切り替わった瞬間に登録していたメソッドを呼び出す
    void CallChargeAction()
    {
        if(chargeNow!=chargeNowBeforeFrame)
        {
            //前フレームとチャージ状況が変わっており、現在のフレームでチャージしているということはチャージが開始されたということ
            bool startCharge = chargeNow;

            SwitchChargeAction?.Invoke(startCharge);

            if(startCharge)
            {
                StartChargeAction?.Invoke();
            }
            else
            {
                EndChargeAction?.Invoke();
            }
        }
    }

    //チャージ状況の更新
    void UpdateChargeNow()
    {
        sinceLastChargedTime += Time.deltaTime;

        //最後にチャージしてからchargeBorderTime(秒)未満なら今チャージしてる判定
        chargeNow = sinceLastChargedTime < chargedBorderTime;
    }
}
