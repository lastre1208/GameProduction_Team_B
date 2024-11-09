using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//作成者
public class TrickPointDisplay : MonoBehaviour
{

    [Header("プレイヤーのトリックゲージ")]
    [Header("注意点:トリックゲージの本数分入れてください")]
    [SerializeField] Image[] trickGauges;
    [Header("▼通常状態のトリックゲージの色")]
    [SerializeField] Color trickGaugeNormalColor;//通常状態のトリックゲージの色
    [Header("▼満タン状態のトリックゲージの色")]
    [SerializeField] Color trickGaugeMaxColor;//満タン状態のトリックゲージの色

    TrickPoint player_TrickPoint;

    // Start is called before the first frame update
    void Start()
    {
        player_TrickPoint = GameObject.FindWithTag("Player").GetComponent<TrickPoint>();

        //エラーコード
        if (player_TrickPoint.TrickGaugeNum != trickGauges.Length) Debug.Log("トリックゲージの本数分登録してください");
    }

    // Update is called once per frame
    void Update()
    {
        TRICKGaugeOfPlayer();//プレイヤーのトリックゲージの処理
    }
    void TRICKGaugeOfPlayer()//プレイヤーのトリックゲージの処理
    {
        for (int i = 0; i < trickGauges.Length; i++)
        {
            float trickRatio = player_TrickPoint[i] / player_TrickPoint.TrickPointMax;
            trickGauges[i].fillAmount = trickRatio;


            //ゲージの色の変更
            if (trickRatio == 1)//満タン時の色
            {
                trickGauges[i].color = trickGaugeMaxColor;
            }
            else//それ以外の時の色
            {
                trickGauges[i].color = trickGaugeNormalColor;
            }
        }
    }
}
