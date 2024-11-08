using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//作成者☆:杉山
public class HpDisplay : MonoBehaviour
{
    [Header("▼HPゲージ")]
    [SerializeField] Image hpGauge;//HPゲージ
    [Header("▼HPを表示したいオブジェクト")]
    [SerializeField] HP objectDisplayHp;//HPを表示したいオブジェクト
    [Header("通常時の色")]
    [SerializeField] Color normalColor;//通常時の色
    [Header("体力が少ない時の色")]
    [SerializeField] Color pinchColor;//体力が少ない時の色
    [Header("体力ゲージの色が変わる境界値(割合)")]
    [Range(0f, 1f)]
    [SerializeField] float borderRatio;//体力ゲージの色が変わる境界値(%)

    void Update()
    {
        HpGauge();
    }

    void HpGauge()//HPゲージの処理
    {
        float hpRatio = objectDisplayHp.Hp / objectDisplayHp.HpMax;
        hpGauge.fillAmount = hpRatio;
        //ゲージの色の変更
        hpGauge.color = (hpRatio <= borderRatio) ? pinchColor : normalColor;
    }
}
