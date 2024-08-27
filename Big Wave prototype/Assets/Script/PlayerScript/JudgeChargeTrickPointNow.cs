using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//現在チャージしているかの判定
public class JudgeChargeTrickPointNow : MonoBehaviour
{
    [Header("チャージしていない・しているの境界の時間")]
    [SerializeField] float chargedBorderTime = 0.1f;//チャージしていない・しているの境界の時間
    private float sinceLastChargedTime = 0.1f;//最後にチャージされてからの時間

    void Start()
    {
        sinceLastChargedTime = chargedBorderTime;
    }

    void Update()
    {
        sinceLastChargedTime += Time.deltaTime;
    }

    public bool ChargeNow()//今チャージしているか
    {
        if (sinceLastChargedTime < chargedBorderTime)//最後にチャージしてからchargeBorderTime(秒)未満なら今チャージしてる判定
        {
            return true;
        }

        return false;
    }

    public void ResetSinceLastChargedTime()//最後にチャージされてからの時間をリセット
    {
        sinceLastChargedTime = 0;
    }
}
