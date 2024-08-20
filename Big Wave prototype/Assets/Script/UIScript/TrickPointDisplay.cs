using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrickPointDisplay : MonoBehaviour
{
    [Header("▼プレイヤーのトリックゲージの黒い部分")]
    [SerializeField] GameObject outOfTrickGaugeOfPlayer;//プレイヤーのトリックゲージの黒い部分
    [Header("▼プレイヤーのトリックゲージ")]
    [SerializeField] GameObject trickGaugeOfPlayer;//プレイヤーのトリックゲージ
    [Header("▼分割されたトリックゲージをどれくらい離すか")]
    [SerializeField] float trickGaugeInterval;//分割されたトリックゲージをどれくらい離すか
    [Header("▼通常状態のトリックゲージの色")]
    [SerializeField] Color trickGaugeNormalColor;//通常状態のトリックゲージの色
    [Header("▼満タン状態のトリックゲージの色")]
    [SerializeField] Color trickGaugeMaxColor;//満タン状態のトリックゲージの色
    private GameObject[] trickGauges;//プレイヤーのトリックゲージ(内部処理用)

    TrickPoint player_TrickPoint;

    // Start is called before the first frame update
    void Start()
    {
        player_TrickPoint = GameObject.FindWithTag("Player").GetComponent<TrickPoint>();
        //トリックゲージの生成(ゲージ数個分)
        GenerateTrickGauge();
        //トリックゲージの位置調整
        PositioningTrickGauge();
    }

    // Update is called once per frame
    void Update()
    {
        TRICKGaugeOfPlayer();//プレイヤーのトリックゲージの処理
    }

    void GenerateTrickGauge()//トリックゲージの生成(ゲージ数個分)
    {
        trickGauges = new GameObject[player_TrickPoint.TrickGaugeNum];
        for (int i = 0; i < trickGauges.Length; i++)
        {
            trickGauges[i] = Instantiate(trickGaugeOfPlayer, outOfTrickGaugeOfPlayer.transform);
        }
    }

    void PositioningTrickGauge()//トリックゲージの位置調整
    {
        //黒い部分のトリックゲージの(横の)大きさを取得
        Vector2 sd_OutOfTrickGauge = outOfTrickGaugeOfPlayer.GetComponent<RectTransform>().sizeDelta;
        //分割されているトリックゲージの大きさを決める(全て同じ大きさ)
        Vector2 sd_TrickGauge = trickGauges[0].GetComponent<RectTransform>().sizeDelta;
        sd_TrickGauge.x = (sd_OutOfTrickGauge.x - (trickGauges.Length - 1) * trickGaugeInterval) / trickGauges.Length;
        sd_TrickGauge.y = sd_OutOfTrickGauge.y;

        //分割されているトリックゲージの大きさと位置を変更
        for (int i = 0; i < trickGauges.Length; i++)
        {
            //大きさを変更
            trickGauges[i].GetComponent<RectTransform>().sizeDelta = sd_TrickGauge;
            //位置を変更
            Vector3 pos_TrickGauge;
            pos_TrickGauge = trickGauges[i].GetComponent<RectTransform>().anchoredPosition3D;

            //一つ目のゲージは左端のどこに置くかを決める
            if (i == 0)
            {
                pos_TrickGauge.x = -sd_OutOfTrickGauge.x / 2 + sd_TrickGauge.x / 2;
            }
            //それ以降のゲージは前に置いたゲージと一定間隔で置く
            else
            {
                Vector3 pos_BeforeTrickGauge = trickGauges[i - 1].GetComponent<RectTransform>().anchoredPosition3D;
                pos_TrickGauge.x = pos_BeforeTrickGauge.x + sd_TrickGauge.x + trickGaugeInterval;
            }

            pos_TrickGauge.y = 0;
            trickGauges[i].GetComponent<RectTransform>().anchoredPosition3D = pos_TrickGauge;
        }
    }

    void TRICKGaugeOfPlayer()//プレイヤーのトリックゲージの処理
    {
        for (int i = 0; i < trickGauges.Length; i++)
        {
            float trickRatio = player_TrickPoint.TrickPoint_[i] / player_TrickPoint.TrickPointMax;
            trickGauges[i].GetComponent<Image>().fillAmount = trickRatio;


            //ゲージの色の変更
            if (trickRatio == 1)//満タン時の色
            {
                trickGauges[i].GetComponent<Image>().color = trickGaugeMaxColor;
            }
            else//それ以外の時の色
            {
                trickGauges[i].GetComponent<Image>().color = trickGaugeNormalColor;
            }
        }
    }
}
