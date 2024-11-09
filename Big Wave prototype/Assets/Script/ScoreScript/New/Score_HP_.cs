using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//HPのスコア
[CreateAssetMenu(menuName = "ScriptableObjects/Score/Hp")]
public class Score_HP_ : Score_Base
{
    float m_remainingHp;//残りHP
    float m_scorePerHp;//HP1あたりのスコア量

    public float RemainingHP { get { return m_remainingHp; }  }
    public float ScorePerHp { get {  return m_scorePerHp; } }

    public void Rewrite(float score,float remainingHp,float scorePerHp)//スコアの書き換え
    {
        m_score=score;
        m_remainingHp=remainingHp;
        m_scorePerHp=scorePerHp;
    }
}
