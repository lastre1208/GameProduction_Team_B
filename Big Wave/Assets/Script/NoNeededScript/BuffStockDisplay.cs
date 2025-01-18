using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者☆:桑原

public class BuffStockDisplay : MonoBehaviour
{
    //[Header("▼バフのストック数を表すゲージの黒い部分")]
    //[SerializeField] GameObject outOfBuffStockGaugeOfPlayer;//バフのストック数を表すゲージの黒い部分
    //[Header("▼バフのストック数を表すゲージ")]
    [SerializeField] GameObject buffStockGaugeOfPlayer;//バフのストック数を表すゲージ
    [Header("▼分割されたバフストックゲージをどれくらい離すか")]
    [SerializeField] float buffStockGaugeInterval;//分割されたバフストックゲージをどれくらい離すか
    [Header("▼満タン状態のトリックゲージの色")]
    [SerializeField] Color buffStockedGaugeColor;//ストック状態のバフストックゲージの色
    // private GameObject[] buffStockGauges;//プレイヤーのバフストックゲージ(内部処理用)

    // Start is called before the first frame update
    void Start()
    {

        // buffOfPlayer = GameObject.FindWithTag("Player").GetComponent<BuffOfPlayer>();
        //バフストックゲージの生成(ゲージ数個分)
        //GenerateBuffStockGauge();
        ////バフストックゲージの位置調整    
        //PositioningBuffStockGauge();
    }

    // Update is called once per frame
    void Update()
    {
        /* BuffStockGaugeOfPlayer();*///プレイヤーのバフストックゲージの処理
    }

    //プレイヤーのバフストック関係のメソッド
    //void GenerateBuffStockGauge()
    //{
    //    buffStockGauges = new GameObject[buffOfPlayer.TrickBoost.BuffStockMax];

    //    for (int i = 0; i < buffStockGauges.Length; i++)
    //    {
    //        buffStockGauges[i] = Instantiate(buffStockGaugeOfPlayer,
    //            outOfBuffStockGaugeOfPlayer.transform);
    //    }
    //}

    //void PositioningBuffStockGauge()//バフストックゲージの位置調整
    //{
    //    //黒い部分のバフストックゲージの(横の)大きさを取得
    //    Vector2 sd_OutOfBuffStockGauge = outOfBuffStockGaugeOfPlayer.GetComponent<RectTransform>().sizeDelta;
    //    //分割されているバフストックゲージの大きさを決める(全て同じ大きさ)
    //    Vector2 sd_BuffStockGauge = buffStockGauges[0].GetComponent<RectTransform>().sizeDelta;
    //    sd_BuffStockGauge.x = (sd_OutOfBuffStockGauge.x - (buffStockGauges.Length - 1) * buffStockGaugeInterval) / buffStockGauges.Length;
    //    sd_BuffStockGauge.y = sd_OutOfBuffStockGauge.y;

    //    //分割されているバフストックゲージの大きさと位置を変更
    //    for (int i = 0; i < buffStockGauges.Length; i++)
    //    {
    //        //大きさを変更
    //        buffStockGauges[i].GetComponent<RectTransform>().sizeDelta = sd_BuffStockGauge;
    //        //位置を変更
    //        Vector3 pos_BuffStockGauge;
    //        pos_BuffStockGauge = buffStockGauges[i].GetComponent<RectTransform>().anchoredPosition3D;

    //        //一つ目のゲージは左端のどこに置くかを決める
    //        if (i == 0)
    //        {
    //            pos_BuffStockGauge.x = -sd_OutOfBuffStockGauge.x / 2 + sd_BuffStockGauge.x / 2;
    //        }
    //        //それ以降のゲージは前に置いたゲージと一定間隔で置く
    //        else
    //        {
    //            Vector3 pos_BeforeBuffStockGauge = buffStockGauges[i - 1].GetComponent<RectTransform>().anchoredPosition3D;
    //            pos_BuffStockGauge.x = pos_BeforeBuffStockGauge.x + sd_BuffStockGauge.x + buffStockGaugeInterval;
    //        }

    //        pos_BuffStockGauge.y = 0;
    //        buffStockGauges[i].GetComponent<RectTransform>().anchoredPosition3D = pos_BuffStockGauge;
    //    }
    //}

    //void BuffStockGaugeOfPlayer()//プレイヤーのバフストックゲージの処理
    //{
    //    int buffStockCount = buffOfPlayer.TrickBoost.BuffStockCount;

    //    for (int i = 0; i < buffStockGauges.Length; i++)
    //    {
    //        if (i < buffStockCount)
    //        {
    //            buffStockGauges[i].GetComponent<Image>().color = buffStockedGaugeColor;
    //        }

    //        else
    //        {
    //            buffStockGauges[i].GetComponent<Image>().color = Color.clear;
    //        }
    //    }
    //}
}
