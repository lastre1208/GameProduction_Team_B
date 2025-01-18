using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//連続クリティカル回数を計測
public partial class Count_Trick_Critical
{
    class CountContinuanceCritical
    {
        private int _continuanceCriticalCount = 0;//連続クリティカル回数
        private bool _continueCritical = false;//クリティカルが続いているか
        const int _resetContinuanceCriticalCount = 0;//リセット時の連続クリティカル回数

        public int ContinuanceCriticalCount { get { return  _continuanceCriticalCount; } }//連続クリティカル回数
        public bool ContinueCritical { get { return _continueCritical; } }//クリティカルが続いているか

        public CountContinuanceCritical() { }//コンストラクタ

        public void Add()//クリティカルが続いている時の加算処理
        {
            _continuanceCriticalCount++;
            _continueCritical = true;
        }

        public void Reset()//クリティカルが途切れた時のリセット処理
        {
            _continuanceCriticalCount = _resetContinuanceCriticalCount;
            _continueCritical = false;
        }
    }
}