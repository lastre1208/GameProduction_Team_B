using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームシーンでの残り時間スコアの計測・判定
public class ScoreGameScene_TimeLimit : MonoBehaviour
{
    [Header("残り時間(1秒)ごとのスコア量")]
    [SerializeField] float m_scorePerSecond;//残り時間(1秒)ごとのスコア量
    [Header("スコア反映に使うコンポーネント")]
    [SerializeField] Score_TimeLimit_ score_TimeLimit;//スコア反映
    [Header("ゲーム終了を判断するコンポーネント")]
    [SerializeField] JudgeGameSet judgeGameSet;
    const float remainingTime_GameOver = 0;//ゲームオーバー時自動的に残り時間を0とする

    private void Start()
    {
        judgeGameSet.GameSetAction += Reflect;
    }

    public void Reflect(bool gameClear)//スコア反映
    {
        float score = (gameClear ? TimeLimit.RemainingTime : remainingTime_GameOver) * m_scorePerSecond;

        score_TimeLimit.Rewrite(score, TimeLimit.RemainingTime, m_scorePerSecond);
    }
}
