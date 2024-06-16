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
    [SerializeField] GameObject playerOfHpGauge;//プレイヤーのHPゲージ
    //プレイヤーのトリック関連
    [Header("▼プレイヤーのトリックゲージの黒い部分")]
    [SerializeField] GameObject outOfPlayerOfTrickGauge;//プレイヤーのトリックゲージの黒い部分
    [Header("▼プレイヤーのトリックゲージ")]
    [SerializeField] GameObject playerOfTrickGauge;//プレイヤーのトリックゲージ
    [Header("▼分割されたトリックゲージをどれくらい離すか")]
    [SerializeField] float trickGaugeInterval;//分割されたトリックゲージをどれくらい離すか
    [Header("▼通常状態のトリックゲージの色")]
    [SerializeField] Color trickGaugeNormalColor;
    [Header("▼満タン状態のトリックゲージの色")]
    [SerializeField] Color trickGaugeMaxColor;
    private GameObject[] trickGauges;//プレイヤーのトリックゲージ(内部処理用)
    //敵のHP関連
    [Header("▼敵のHPゲージ")]
    [SerializeField] GameObject enemyOfHpGauge;//敵のHPゲージ

    Color gaugeColor;
    Enemy enemy;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        //トリックゲージの生成(ゲージ数個分)
        GenerateTrickGauge();
        //トリックゲージの位置調整
        PositioningTrickGauge();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerOfHPGage();

        PlayerOfTRICKGage();

        EnemyOfHPGage();
    }

    void PlayerOfHPGage()//プレイヤーのHPゲージの処理
    {
        float hpratio = player.Hp / player.HpMax;
        playerOfHpGauge.GetComponent<Image>().fillAmount = hpratio;
    }

    void GenerateTrickGauge()
    {
        trickGauges=new GameObject[player.TrickGaugeNum];
        for(int i=0; i<trickGauges.Length;i++)
        {
            trickGauges[i] = Instantiate(playerOfTrickGauge,outOfPlayerOfTrickGauge.transform);
        }
    }

    void PositioningTrickGauge()//トリックゲージの位置調整
    {
        //黒い部分のトリックゲージの(横の)大きさを取得
        Vector2 sd_OutOfTrickGauge = outOfPlayerOfTrickGauge.GetComponent<RectTransform>().sizeDelta;
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

    void PlayerOfTRICKGage()//プレイヤーのトリックゲージの処理
    {
        for(int i=0; i<trickGauges.Length;i++)
        {
            float trickratio = player.Trick[i] / player.TrickMax;
            trickGauges[i].GetComponent<Image>().fillAmount = trickratio;

            
            //ゲージの色の変更
            if (trickratio == 1)//満タン時の色
            {
                trickGauges[i].GetComponent<Image>().color = trickGaugeMaxColor;
            }
            else//それ以外の時の色
            {
                trickGauges[i].GetComponent<Image>().color = trickGaugeNormalColor;
            }
        }
    }

    void EnemyOfHPGage()//敵のHPゲージの処理
    {
        if (enemy != null)
        {
            float enemy_hpratio = enemy.Hp / enemy.HpMax;
            enemyOfHpGauge.GetComponent<Image>().fillAmount = enemy_hpratio;
        }
    }
}
