using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusDisplay : MonoBehaviour
{
    //☆塩が書いた
    //プレイヤーのHP関連
    [Header("▼プレイヤーのHPゲージ")]
    [SerializeField] GameObject hpGaugeOfPlayer;//プレイヤーのHPゲージ

    //プレイヤーのトリックポイント関連
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

    //プレイヤーのフィーバーポイント関連
    [Header("▼プレイヤーのフィーバーゲージ")]
    [SerializeField] GameObject feverGaugeOfPlayer;//プレイヤーのフィーバーゲージ
    [Header("▼通常状態のフィーバーゲージの色")]
    [SerializeField] Color feverGaugeNormalColor;//通常状態のフィーバーゲージの色
    [Header("▼フィーバー状態のフィーバーゲージの色")]
    [SerializeField] Color feverGaugeFeverModeColor;//フィーバー状態のフィーバーゲージの色

    //プレイヤーのバフストック関連
    [Header("▼バフのストック数を表すゲージの黒い部分")]
    [SerializeField] GameObject outOfBuffStockGaugeOfPlayer;//バフのストック数を表すゲージの黒い部分
    [Header("▼バフのストック数を表すゲージ")]
    [SerializeField] GameObject buffStockGaugeOfPlayer;//バフのストック数を表すゲージ
    [Header("▼分割されたバフストックゲージをどれくらい離すか")]
    [SerializeField] float buffStockGaugeInterval;//分割されたバフストックゲージをどれくらい離すか
    [Header("▼満タン状態のトリックゲージの色")]
    [SerializeField] Color buffStockedGaugeColor;//ストック状態のバフストックゲージの色
    private GameObject[] buffStockGauges;//プレイヤーのバフストックゲージ(内部処理用)


    //敵のHP関連
    [Header("▼敵のHPゲージ")]
    [SerializeField] GameObject hpGaugeOfEnemy;//敵のHPゲージ

    Enemy enemy;
    Player player;
    ProcessFeverMode processFeverPoint;
    BuffOfPlayer buffOfPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        processFeverPoint= GameObject.FindWithTag("Player").GetComponent<ProcessFeverMode>();
        buffOfPlayer = GameObject.FindWithTag("Player").GetComponent<BuffOfPlayer>();
        //トリックゲージの生成(ゲージ数個分)
        GenerateTrickGauge();
        //トリックゲージの位置調整
        PositioningTrickGauge();

        //バフストックゲージの生成(ゲージ数個分)
        GenerateBuffStockGauge();
        //バフストックゲージの位置調整    
        PositioningBuffStockGauge();
    }

    // Update is called once per frame
    void Update()
    {
        HPGaugeOfPlayer();//プレイヤーのHPゲージの処理

        TRICKGaugeOfPlayer();//プレイヤーのトリックゲージの処理

        FeverGaugeOfPlayer();//プレイヤーのフィーバーゲージの処理

        HPGaugeOfEnemy();//敵のHPゲージの処理

        BuffStockGaugeOfPlayer();//プレイヤーのバフストックゲージの処理
    }

    //プレイヤーのHP関係のメソッド

    void HPGaugeOfPlayer()//プレイヤーのHPゲージの処理
    {
        float hpRatio = player.Hp / player.HpMax;
        hpGaugeOfPlayer.GetComponent<Image>().fillAmount = hpRatio;
    }


    //プレイヤーのトリックポイント関係のメソッド

    void GenerateTrickGauge()//トリックゲージの生成(ゲージ数個分)
    {
        trickGauges=new GameObject[player.TrickGaugeNum];
        for(int i=0; i<trickGauges.Length;i++)
        {
            trickGauges[i] = Instantiate(trickGaugeOfPlayer,outOfTrickGaugeOfPlayer.transform);
        }
    }

    void PositioningTrickGauge()//トリックゲージの位置調整
    {
        //黒い部分のトリックゲージの(横の)大きさを取得
        Vector2 sd_OutOfTrickGauge = outOfTrickGaugeOfPlayer.GetComponent<RectTransform>().sizeDelta;
        //分割されているトリックゲージの大きさを決める(全て同じ大きさ)
        Vector2 sd_TrickGauge = trickGauges[0].GetComponent<RectTransform>().sizeDelta;
        sd_TrickGauge.x = ( sd_OutOfTrickGauge.x-(trickGauges.Length-1)*trickGaugeInterval )/ trickGauges.Length;
        sd_TrickGauge.y = sd_OutOfTrickGauge.y;

        //分割されているトリックゲージの大きさと位置を変更
        for(int i=0;i<trickGauges.Length ;i++)
        {
            //大きさを変更
            trickGauges[i].GetComponent<RectTransform>().sizeDelta = sd_TrickGauge;
            //位置を変更
            Vector3 pos_TrickGauge;
            pos_TrickGauge = trickGauges[i].GetComponent<RectTransform>().anchoredPosition3D;

            //一つ目のゲージは左端のどこに置くかを決める
            if (i==0)
            {
                pos_TrickGauge.x = -sd_OutOfTrickGauge.x / 2 + sd_TrickGauge.x / 2;
            }
            //それ以降のゲージは前に置いたゲージと一定間隔で置く
            else
            {
                Vector3 pos_BeforeTrickGauge= trickGauges[i-1].GetComponent<RectTransform>().anchoredPosition3D;
                pos_TrickGauge.x = pos_BeforeTrickGauge.x + sd_TrickGauge.x + trickGaugeInterval;
            }

            pos_TrickGauge.y =0;
            trickGauges[i].GetComponent<RectTransform>().anchoredPosition3D = pos_TrickGauge;
        }
    }

    void TRICKGaugeOfPlayer()//プレイヤーのトリックゲージの処理
    {
        for(int i=0; i<trickGauges.Length;i++)
        {
            float trickRatio = player.TrickPoint[i] / player.TrickPointMax;
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


    //プレイヤーのフィーバーポイント関係のメソッド

    void FeverGaugeOfPlayer()//プレイヤーのフィーバーゲージの処理
    {
        float feverRatio = player.FeverPoint / player.FeverPointMax;
        feverGaugeOfPlayer.GetComponent<Image>().fillAmount = feverRatio;
        //ゲージの色の変更
        if(processFeverPoint.FeverNow)//フィーバー状態の時
        {
            feverGaugeOfPlayer.GetComponent<Image>().color = feverGaugeFeverModeColor;
        }
        else//通常時
        {
            feverGaugeOfPlayer.GetComponent<Image>().color = feverGaugeNormalColor;
        }
    }

    //プレイヤーのバフストック関係のメソッド
    void GenerateBuffStockGauge()
    {
        buffStockGauges = new GameObject[buffOfPlayer.TrickBoost.BuffStockMax];

        for (int i = 0; i < buffStockGauges.Length; i++)
        {
            buffStockGauges[i] = Instantiate(buffStockGaugeOfPlayer,
                outOfBuffStockGaugeOfPlayer.transform);
        }
    }

    void PositioningBuffStockGauge()//バフストックゲージの位置調整
    {
        //黒い部分のバフストックゲージの(横の)大きさを取得
        Vector2 sd_OutOfBuffStockGauge = outOfBuffStockGaugeOfPlayer.GetComponent<RectTransform>().sizeDelta;
        //分割されているバフストックゲージの大きさを決める(全て同じ大きさ)
        Vector2 sd_BuffStockGauge = buffStockGauges[0].GetComponent<RectTransform>().sizeDelta;
        sd_BuffStockGauge.x = (sd_OutOfBuffStockGauge.x - (buffStockGauges.Length - 1) * buffStockGaugeInterval) / buffStockGauges.Length;
        sd_BuffStockGauge.y = sd_OutOfBuffStockGauge.y;

        //分割されているバフストックゲージの大きさと位置を変更
        for (int i = 0; i < buffStockGauges.Length; i++)
        {
            //大きさを変更
            buffStockGauges[i].GetComponent<RectTransform>().sizeDelta = sd_BuffStockGauge;
            //位置を変更
            Vector3 pos_BuffStockGauge;
            pos_BuffStockGauge = buffStockGauges[i].GetComponent<RectTransform>().anchoredPosition3D;

            //一つ目のゲージは左端のどこに置くかを決める
            if (i == 0)
            {
                pos_BuffStockGauge.x = -sd_OutOfBuffStockGauge.x / 2 + sd_BuffStockGauge.x / 2;
            }
            //それ以降のゲージは前に置いたゲージと一定間隔で置く
            else
            {
                Vector3 pos_BeforeBuffStockGauge = buffStockGauges[i - 1].GetComponent<RectTransform>().anchoredPosition3D;
                pos_BuffStockGauge.x = pos_BeforeBuffStockGauge.x + sd_BuffStockGauge.x + buffStockGaugeInterval;
            }

            pos_BuffStockGauge.y = 0;
            buffStockGauges[i].GetComponent<RectTransform>().anchoredPosition3D = pos_BuffStockGauge;
        }
    }

    void BuffStockGaugeOfPlayer()//プレイヤーのバフストックゲージの処理
    {
        int buffStockCount = buffOfPlayer.TrickBoost.BuffStockCount;

        for (int i = 0; i < buffStockGauges.Length; i++)
        {
            if (i < buffStockCount)
            {
                buffStockGauges[i].GetComponent<Image>().color = buffStockedGaugeColor;
            }

            else
            {
                buffStockGauges[i].GetComponent<Image>().color = Color.clear;
            }
        }
    }




    //敵のHP関係のメソッド

    void HPGaugeOfEnemy()//敵のHPゲージの処理
    {
        if (enemy != null)
        {
            float enemy_HpRatio = enemy.Hp / enemy.HpMax;
            hpGaugeOfEnemy.GetComponent<Image>().fillAmount = enemy_HpRatio;
        }
    }
}
