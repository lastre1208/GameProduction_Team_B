using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//時間制限のスコア
[CreateAssetMenu(menuName = "ScriptableObjects/Score/TimeLimit")]
public class Score_TimeLimit_ : Score_Base
{
    float m_remainingTime;//残り時間
    float m_scorePerSecond;//1秒ごとのスコア

    public float RemainingTime { get { return m_remainingTime; } }
    public float ScorePerScond { get {  return m_scorePerSecond; } }

    public void Rewrite(float score,float remainingTime,float scorePerSecond)//スコアの書き換え
    {
        m_score=score;
        m_remainingTime=remainingTime;
        m_scorePerSecond=scorePerSecond;
    }
}
