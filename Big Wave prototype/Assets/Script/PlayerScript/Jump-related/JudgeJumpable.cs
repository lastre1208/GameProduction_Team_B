using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//作成者:杉山
//今ジャンプできるか判定する
public class JudgeJumpable : MonoBehaviour
{
    public event Action<bool> SwitchJumpable;//ジャンプ可能かが切り替わる瞬間に呼ぶ、trueならジャンプできるようになった時、falseならジャンプできなくなった時
    public event Action ToJumpable;//ジャンプ可能になった時に呼ぶ
    public event Action ToNotJumpable;//ジャンプ不可能になった時に呼ぶ
    [SerializeField] JudgeJumpNow _judgeJumpNow;
    [SerializeField] JudgeTouchWave _judgeTouchWave;
    bool _jumpableBeforeFrame = false;//前フレームのジャンプ可能状態

    public bool Jumpable//ジャンプ可能条件
    {
        get { return _judgeTouchWave.TouchWaveNow&&!_judgeJumpNow.JumpNow(); }//波に触れている時かつジャンプしていない時のみジャンプ可能
    }

    void Update()
    {
        JudgeSwitchJumpable();
    }

    void JudgeSwitchJumpable()
    {
        if(_jumpableBeforeFrame!=Jumpable)//ジャンプ可能状態が切り替わった時に切り替わりの瞬間の処理を呼ぶ
        {
            bool switchJumpable = !_jumpableBeforeFrame;//前フレームでジャンプ不可能であれば ジャンプ可能になったということ

            //ジャンプ可能状況の切り替わり時の処理を呼ぶ
            SwitchJumpable?.Invoke(switchJumpable);

            if(switchJumpable)
            {
                ToJumpable?.Invoke();
            }
            else
            {
                ToNotJumpable?.Invoke();
            }
        }

        _jumpableBeforeFrame = Jumpable;//前フレームのジャンプ可能状態の更新
    }
}
