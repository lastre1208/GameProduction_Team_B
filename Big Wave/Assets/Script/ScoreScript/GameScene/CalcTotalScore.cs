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
    [SerializeField] Score_Total _score_Total_;//合計スコア
    [Header("ゲーム終了を判断")]
    [SerializeField] JudgeGameSet _judgeGameSet;

    void Start()
    {
        _judgeGameSet.LatedAction += Calc;
    }

    public void Calc()
    {
        //合計を計算
        float score = 0;

        for (int i = 0; i < _addScores.Length; i++)
        {
            score += _addScores[i].Score;
        }

        //小数点を切り捨て
        score = Mathf.Floor(score);

        //合計スコアに反映
        _score_Total_.ReWrite(score);
    }
}
