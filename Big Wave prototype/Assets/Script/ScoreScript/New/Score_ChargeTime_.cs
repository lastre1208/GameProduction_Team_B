using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//チャージのスコア
[CreateAssetMenu(menuName = "ScriptableObjects/Score/ChargeTime")]
public class Score_ChargeTime_ : Score_Base
{
    float m_chargeTime;//チャージ秒数
    float m_scorePerSecond;//1秒あたりのスコア

    public float ChargeTime { get { return m_chargeTime; } }
    public float ScorePerSecond { get { return  m_scorePerSecond; } }

    public void Rewrite(float score,float chargeTime,float scorePerSecond)//スコアの書き換え
    {
        m_score=score;
        m_chargeTime=chargeTime;
        m_scorePerSecond=scorePerSecond;
    }
}
