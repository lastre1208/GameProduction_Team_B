using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//特定オブジェクトが衝突した瞬間に呼びたい関数を登録して呼び出すことが出来る
//当たり判定のついているオブジェクトにアタッチしてお使いください
public class OnCollisionActionEvent : MonoBehaviour
{
    public event Action<Collision> EnterAction;
    public event Action<Collision> StayAction;
    public event Action<Collision> ExitAction;

    void OnCollisionEnter(Collision other)
    {
        EnterAction?.Invoke(other);
    }

    void OnCollisionStay(Collision other)
    {
        StayAction?.Invoke(other);
    }

    void OnCollisionExit(Collision other)
    {
        ExitAction?.Invoke(other);
    }
}
