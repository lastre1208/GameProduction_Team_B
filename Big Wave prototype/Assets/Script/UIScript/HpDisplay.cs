using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//作成者☆:杉山
public class HpDisplay : MonoBehaviour
{
    [Header("▼HPゲージ")]
    [SerializeField] GameObject hpGaugeOfPlayer;//HPゲージ
    [Header("▼HPを表示したいオブジェクト")]
    [SerializeField] HP objectDisplayHp;//HPを表示したいオブジェクト
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HpGauge();
    }

    void HpGauge()//HPゲージの処理
    {
        float hpRatio = objectDisplayHp.Hp / objectDisplayHp.HpMax;
        hpGaugeOfPlayer.GetComponent<Image>().fillAmount = hpRatio;
    }
}
