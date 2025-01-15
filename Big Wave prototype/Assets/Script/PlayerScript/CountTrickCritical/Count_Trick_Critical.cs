using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//トリック・クリティカル・連続クリティカルの回数を数える
public partial class Count_Trick_Critical : MonoBehaviour
{
    [Header("必要なコンポーネント")]
    [SerializeField] Critical critical;
    CountContinuanceCritical _continuanceCritical=new CountContinuanceCritical();//連続クリティカル状況を計測するインスタンス
    private int _totalCriticalCount = 0;//合計クリティカル回数
    private int _totalTrickCount = 0;//合計トリック回数

    public int TotalCriticalCount{ get { return _totalCriticalCount; } }//合計クリティカル回数

    public int TotalTrickCount { get { return _totalTrickCount; } }//合計トリック回数

    public float CriticalRate//クリティカルの成功率
    {
        get
        {
            const float retDividedByZero = 0;//0による除算時に返す値
            if (_totalTrickCount == 0) return retDividedByZero;//0による除算が起こる場合は0を返す

            return (float)(_totalCriticalCount / _totalTrickCount); 
        } 
    }

    public int ContinuanceCriticalCount { get { return _continuanceCritical.ContinuanceCriticalCount; } }//連続クリティカル回数

    public bool ContinueCritical{ get { return _continuanceCritical.ContinueCritical; } }//クリティカルが続いているか


    public void Count()//クリティカル回数を計測
    {
        _totalTrickCount++;//合計トリック回数を加算

        if(critical.CriticalNow)//クリティカルだったら
        {
            _totalCriticalCount++;//合計クリティカル回数を加算

            _continuanceCritical.Add();//連続クリティカルの加算処理
        }

        else//クリティカルじゃなかったら
        {
            _continuanceCritical.Reset();//連続クリティカルのリセット処理
        }
    }
}
