using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//合計スコア
[CreateAssetMenu(menuName = "ScriptableObjects/Score/Total")]
public class Score_Total_ : Score_Base
{
    public void ReWrite(float totalScore)
    {
        m_score = totalScore;
    }

}
