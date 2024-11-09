using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplay : MonoBehaviour
{
    [Header("▼HPゲージ")]
    [SerializeField] Image hpGauge;//HPゲージ
    [Header("▼HPを表示したいオブジェクト")]
    [SerializeField] HP objectDisplayHp;//HPを表示したいオブジェクト

    void Update()
    {
        HPGauge();
    }

    void HPGauge()//HPゲージの処理
    {
        float hpRatio = objectDisplayHp.Hp / objectDisplayHp.HpMax;
        hpGauge.fillAmount = hpRatio;
    }
}
