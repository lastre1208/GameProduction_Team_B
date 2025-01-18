using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

//作成者：桑原
//[System.Serializable]
//class Borderline
//{
//    [Header("被ダメージ評価回数")]
//    [SerializeField] int borderCount = 0;//被ダメ評価基準回数
//    [Header("この評価時のスコア量")]
//    [SerializeField] int addScore = 100;//評価時に獲得できるスコア量

//    public int BorderCount
//    {
//        get { return borderCount; }
//        set { borderCount = value; }
//    }

//    public int AddScore
//    {
//        get { return addScore; }
//        set { addScore = value; }
//    }
//}

//public class ManagementOfScore : MonoBehaviour
//{
//    [Header("～時間のスコア設定～")]
//    [Header("残り時間のスコア倍率（秒数）")]
//    [SerializeField] float timeScore_ratio = 10;//残り時間評価倍率

//    [Header("～トリックゲージ残量のスコア設定～")]
//    [Header("トリックゲージ残量のスコア倍率")]
//    [SerializeField] float trickScore_ratio = 1;//トリックゲージ残量のスコア倍率

//    [Header("～トリックのスコア設定～")]
//    [Header("トリック成功時のスコア量")]
//    [SerializeField] int trickScore = 10;//トリック成功時のスコア

//    [Header("～被ダメ評価のスコア設定～")]
//    [Header("ダメージを受けた回数が")]
//    [Header("各borderCountの値（回数）を超えると、")]
//    [Header("評価が１つ下の段階に下がります。")]

//    [Header("被ダメージ評価ライン（最高）")]
//    [SerializeField] Borderline bestRank;

//    [Header("被ダメージ評価ライン（高）")]
//    [SerializeField] Borderline goodRank;

//    [Header("被ダメージ評価ライン（中間）")]
//    [SerializeField] Borderline normalRank;

//    [Header("被ダメージ評価ライン（低）")]
//    [SerializeField] Borderline badRank;

//    [Header("最低評価時のスコア量")]
//    [SerializeField] int lowestRank_AddScore = 0;

//    private static int totalScore;//合計スコア
//    private static int nowScore;//ゲーム進行中のスコア
//    private static int damageCount;//ダメージを受けた回数
//    private int remainingTime;//クリア時の残り時間(秒数）
//    //private float oldPlayerHp;//ダメージを受ける前のプレイヤーのHP。ダメージを受けた後の比較用

//    //HP player_Hp;
//    TrickPoint player_TrickPoint;
//    //HP enemy_Hp;

//    public static int TotalScore
//    {
//        get { return totalScore; }
//        private set { totalScore = value; }
//    }
//    // Start is called before the first frame update
//    void Start()
//    {
//        //player_Hp = GameObject.FindWithTag("Player").GetComponent<HP>();
//        player_TrickPoint = GameObject.FindWithTag("Player").GetComponent<TrickPoint>();
//        //enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();

//        totalScore = 0;
//        nowScore = 0;
//        damageCount = 0;
//        remainingTime = 0;
//        //oldPlayerHp = player_Hp.Hp;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//    }

//    public void CalculateScore()//スコア算出(敵死亡時に呼び出す)
//    {
//        CalculateTimeScore();
//        CalculateTrickGageScore();
//        CalculateDamageScore();

//        totalScore += nowScore;//合計スコアにプレイ中のスコアを加点
//    }

//    public void AddDamageCount()//被弾時にダメージを受けた回数を増やす
//    {
//        damageCount++;
//        //if (player_Hp.Hp < oldPlayerHp)//プレイヤーのHPが減少したら
//        //{
//        //    damageCount++;
//        //}

//        //if (player_Hp.Hp != oldPlayerHp)//プレイヤーのHPが増減したら
//        //{
//        //    oldPlayerHp = player_Hp.Hp;//現在のHPを記録

//        //    if (oldPlayerHp >= player_Hp.HpMax)
//        //    {
//        //        oldPlayerHp = player_Hp.HpMax;
//        //    }
//        //}
//    }

//    public void AddTrickScore()//トリック成功時にスコアを加点
//    {
//        nowScore += trickScore;
//    }


//    // スコア算出のメソッド

//    void CalculateTimeScore()//残り時間のスコア計算
//    {
//        remainingTime = (int)(TimeDisplay.Minutes * 60 + TimeDisplay.Seconds);
//        totalScore += (int)(remainingTime * timeScore_ratio);//残り時間に応じたスコアを加点
//    }

//    void CalculateTrickGageScore()//トリックゲージ残量のスコア計算
//    {
//        for (int i = 0; i < player_TrickPoint.TrickPoint_.Length; i++)
//        {
//            totalScore += (int)(player_TrickPoint.TrickPoint_[i] * trickScore_ratio);//トリックゲージの残量に応じたスコアを加点
//        }
//    }

//    void CalculateDamageScore()//ダメージ評価のスコア計算
//    {
//        switch (damageCount)//ダメージを受けた回数の評価
//        {
//            case int n when (n <= bestRank.BorderCount)://ダメージを受けた回数がbestRank.BoderCount回以下の時
//                totalScore += bestRank.AddScore;//合計スコアに最高評価時のスコアを加点
//                break;

//            case int n when (bestRank.BorderCount < n && n <= goodRank.BorderCount):
//                //ダメージを受けた回数がbestRank.BorderCount回を超え、かつgoodRank.BorderCount回以下である時
//                totalScore += goodRank.AddScore;//合計スコアに高評価時のスコアを加点
//                break;

//            case int n when (goodRank.BorderCount < n && n <= normalRank.BorderCount):
//                //ダメージを受けた回数がgoodRank.borderCount回を超え、かつnormalRank.BoarderCount回以下である時
//                totalScore += normalRank.AddScore;//合計スコアに普通評価時のスコアを加点
//                break;

//            case int n when (normalRank.BorderCount < n && n <= badRank.BorderCount):
//                //ダメージを受けた回数がnormalRank.BorderCount回を超え、かつbadRank.BorderCount回以下である時
//                totalScore += badRank.AddScore;//合計スコアに低評価時のスコアを加点
//                break;

//            case int n when (badRank.BorderCount < n):
//                //ダメージを受けた回数がbadRank.BorderCount回を超えた時
//                totalScore += lowestRank_AddScore;//合計スコアに最低評価時のスコアを加点
//                break;
//        }
//    }
//}
