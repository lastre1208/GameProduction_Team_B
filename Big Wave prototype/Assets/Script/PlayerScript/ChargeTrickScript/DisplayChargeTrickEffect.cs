using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayChargeTrickEffect : MonoBehaviour
{
    [Header("チャージ用の雷エフェクト")]
    [SerializeField] GameObject chargeSpark;//チャージ用の雷エフェクト
    JudgeChargeNow judgeChargeNow;

    void Start()
    {
        judgeChargeNow = GetComponent<JudgeChargeNow>();
        chargeSpark.SetActive(false);
    }

    void Update()
    {
        DisplayChargeSpark();//トリックをチャージしている時のみチャージ用の雷エフェクトを表示
    }

    void DisplayChargeSpark()//トリックをチャージしている時のみチャージ用の雷エフェクトを表示
    {
        if (judgeChargeNow.ChargeNow())
        {
            chargeSpark.SetActive(true);
        }
        else
        {
            chargeSpark.SetActive(false);
        }
    }
}
