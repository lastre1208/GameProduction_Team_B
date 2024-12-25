using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームシーンでの残りHPスコアの計測・判定
public class ScoreGameScene_HP : MonoBehaviour
{
    [Header("最大HPに対しての残りHPの1%ごとのスコア量")]
    [SerializeField] float m_scorePerOnePercent;//最大HPに対しての残りHPの1%ごとのスコア量
    [Header("プレイヤーのHP")]
    [SerializeField] HP player_HP;//プレイヤーのHP
    [Header("スコア反映に使うコンポーネント")]
    [SerializeField] Score_HP score_HP;//スコア反映
    [Header("ゲーム終了を判断するコンポーネント")]
    [SerializeField] JudgeGameSet judgeGameSet;
    const float ratioToPercent = 100;//割合から％に変換する係数
    const float hpRatio_GameOver = 0;//ゲームオーバー時残り体力の割合を自動的に0とする

    private void Start()
    {
        judgeGameSet.GameSetAction += Reflect;
    }

    public void Reflect(bool gameClear)//スコア反映
    {
        float hpRatio = gameClear ? (player_HP.Hp / player_HP.HpMax) : hpRatio_GameOver;//プレイヤーのHPの割合
        float hpPercent = hpRatio * ratioToPercent;//割合をパーセントに直したもの

        float score= hpPercent * m_scorePerOnePercent;//スコアの計算式

        score_HP.Rewrite(score, hpPercent, m_scorePerOnePercent);
    }
}
