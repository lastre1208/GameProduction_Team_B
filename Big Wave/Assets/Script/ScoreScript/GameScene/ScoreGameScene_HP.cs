using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームシーンでの残りHPスコアの計測・判定
//クリア時のHP割合でなく、基本スコアからダメージを受けた回数だけスコアを減らす仕様に変更
public class ScoreGameScene_HP : MonoBehaviour
{
    //[Header("最大HPに対しての残りHPの1%ごとのスコア量")]
    //[SerializeField] float m_scorePerOnePercent;//最大HPに対しての残りHPの1%ごとのスコア量
    [Header("基本スコア(ノーダメージだった場合に獲得できるスコア)")]
    [SerializeField]float baseScore;
    [Header("ダメージを受ける毎に減らすスコア")]
    [SerializeField] float decreaseScore;
    [Header("プレイヤーのHP")]
    [SerializeField] HP player_HP;//プレイヤーのHP
    [Header("スコア反映に使うコンポーネント")]
    [SerializeField] Score_HP score_HP;//スコア反映
    [Header("ゲーム終了を判断するコンポーネント")]
    [SerializeField] JudgeGameSet judgeGameSet;
   
    private int damageCount;
     public int DamageCount
    {
        get { return damageCount; }
        set { damageCount = value; }
    }
    const float ratioToPercent = 100;//割合から％に変換する係数
    const float hpRatio_GameOver = 0;//ゲームオーバー時残り体力の割合を自動的に0とする

     void Start()
    {
       DamageCount = 0;
        judgeGameSet.GameSetAction += Reflect;
    }

    public void Reflect(bool gameClear)//スコア反映
    {
        float hpScore = gameClear ? baseScore-(damageCount*decreaseScore) : hpRatio_GameOver;//スコアの計算式

        if(hpScore < 0)
        {
            hpScore = 0;
        }
       // float hpPercent = hpRatio * ratioToPercent;//割合をパーセントに直したもの

        //float score= hpPercent * m_scorePerOnePercent;//スコアの計算式

       // score_HP.Rewrite(score, hpPercent, m_scorePerOnePercent);
       score_HP.Rewrite(hpScore);
    }
  
}
