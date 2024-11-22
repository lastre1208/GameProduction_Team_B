using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//今ジャンプできるか判定する
public class JudgeJumpable : MonoBehaviour
{
    [SerializeField] JudgeJumpNow _judgeJumpNow;
    [SerializeField] JudgeTouchWave _judgeTouchWave;

    public bool Jumpable//ジャンプ可能条件
    {
        get { return _judgeTouchWave.TouchWaveNow&&!_judgeJumpNow.JumpNow(); }//波に触れている時かつジャンプしていない時のみジャンプ可能
    }
}
