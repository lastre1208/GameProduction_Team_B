using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplay_Player : MonoBehaviour
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
    [Header("体力回復のコンポーネント")]
    [SerializeField] RecoverHPWhileCharging recoverHPWhileCharging;
    [Header("点滅の設定")]
    [SerializeField] BlinkColor blinkColor = new BlinkColor();
    const float maxHpRatio = 1;//体力満タン時の体力の割合


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

        //体力満タンでないかつ回復中は点滅させる
        if(hpRatio!=maxHpRatio&&recoverHPWhileCharging.Healing)
        {
            hpGauge.color=blinkColor.Blinking(hpGauge.color);
        }
    }
}
