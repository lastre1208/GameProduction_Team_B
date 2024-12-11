using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//形態ごとの行動パターン(一連の動作)
[System.Serializable]
public class SequenceOfActionPatternPerForm
{
    [Header("最初の行動をするか")]
    [SerializeField] bool _actFirst=false;//最初の行動をするか
    [Header("最初の行動内容")]
    [SerializeField] SequenceOfActionPattern _firstAction;//最初の行動内容
    [Header("最初以降の行動内容(ランダムで抽選)")]
    [SerializeField] ProbabilityGet<SequenceOfActionPattern> _afterAction;//最初以降の行動内容(ランダムで抽選)

    public bool ActFirst { get { return _actFirst; } }//最初の行動をするか
    public SequenceOfActionPattern FirstAction { get { return _firstAction; } }//最初の行動内容

    public void CalcSum()//確率合計を計算
    {
        _afterAction.CalcSum();
    }

    public SequenceOfActionPattern SelectAfterAction()//最初以降の行動をランダムで抽選して返す
    {
        return _afterAction.Get();
    }
    
}
