using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//最大コンボ回数のスコア
[CreateAssetMenu(menuName = "ScriptableObjects/Score/ComboMax")]
public class Score_ComboMax : Score_Base
{
    int m_comboMax;//最大コンボ回数
    float m_scorePerCombo;//1回ごとのスコア

    public int ComboMax { get { return m_comboMax; }  } 
    public float ScorePerCombo { get {  return m_scorePerCombo; } }

    public void Rewrite(float score,int comboMax,float scorePerCombo)//スコアの書き換え
    {
        m_score=score;
        m_comboMax=comboMax;
        m_scorePerCombo=scorePerCombo;
    }
}
