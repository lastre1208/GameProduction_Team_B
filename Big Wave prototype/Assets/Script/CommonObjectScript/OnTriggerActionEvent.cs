using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//作成者:杉山
//特定オブジェクトが接触した瞬間に呼びたい関数を登録して呼び出すことが出来る
public class OnTriggerActionEvent : MonoBehaviour
{
    public event Action<Collider> EnterAction;
    public event Action<Collider> StayAction;
    public event Action<Collider> ExitAction;

    void OnTriggerEnter(Collider other)
    {
        EnterAction?.Invoke(other);
    }

    void OnTriggerStay(Collider other)
    {
        StayAction?.Invoke(other);
    }

    void OnTriggerExit(Collider other)
    {
        ExitAction?.Invoke(other);
    }
}
