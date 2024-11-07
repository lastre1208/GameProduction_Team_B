using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SlantHP : MonoBehaviour
{
    [Header("▼HPゲージ")]
    [SerializeField] GameObject hpGaugeOfEnemy;//HPゲージ
    [Header("▼HPを表示したいオブジェクト")]
    [SerializeField] HP objectDisplayHp;//HPを表示したいオブジェクト
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        HpGauge();
    }

    void HpGauge() // HPゲージの処理
    {
        float hpRatio = objectDisplayHp.Hp / objectDisplayHp.HpMax;
        float xPosition = Mathf.Lerp(0, -368, 1 - hpRatio);

        RectTransform rectTransform = hpGaugeOfEnemy.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(xPosition, rectTransform.anchoredPosition.y);
    }


}
