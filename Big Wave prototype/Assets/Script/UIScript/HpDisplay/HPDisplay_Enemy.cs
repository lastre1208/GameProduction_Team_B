using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplay_Enemy : MonoBehaviour
{
    [Header("▼HPゲージ")]
    [SerializeField] Image hpGauge;//HPゲージ
    [Header("▼HPを表示したいオブジェクト")]
    [SerializeField] HP objectDisplayHp;//HPを表示したいオブジェクト
    private Slant slant = new Slant();

    void Update()
    {
        HPGauge();
    }

    void HPGauge()
    {
        float hpRatio = objectDisplayHp.Hp / objectDisplayHp.HpMax;
        RectTransform rectTransform = hpGauge.GetComponent<RectTransform>();

        slant.MakeSlant(rectTransform, hpRatio);
    }
}
