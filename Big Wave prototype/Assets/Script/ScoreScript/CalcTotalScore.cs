using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//スコアの合計を計算
public class CalcTotalScore : MonoBehaviour
{
    [Header("合算するスコア")]
    [SerializeField] Score_Base[] _addScores;//合算するスコア
    [Header("合計スコア")]
    [SerializeField] Score_Total_ _score_Total_;//合計スコア

    void Awake()
    {
        //合計を計算
        float score=0;

        for(int i=0; i<_addScores.Length;i++)
        {
            score += _addScores[i].Score;
        }

        //合計スコアに反映
        _score_Total_.ReWrite(score);
        
    }
}
