using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//HPのスコア
[CreateAssetMenu(menuName = "ScriptableObjects/Score/Hp")]
public class Score_HP : Score_Base
{
    float m_remainingHpPercent;//残りHP割合
    float m_scorePerOnePercent;//最大HPに対しての残りHPの1%ごとのスコア量

    public float RemainingHPPercent { get { return m_remainingHpPercent; }  }
    public float ScorePerOnePercent { get {  return m_scorePerOnePercent; } }

    public void Rewrite(float score,float remainingHpPercent,float scorePerOnePercent)//スコアの書き換え
    {
        m_score=score;
        m_remainingHpPercent=remainingHpPercent;
        m_scorePerOnePercent=scorePerOnePercent;
    }
}
