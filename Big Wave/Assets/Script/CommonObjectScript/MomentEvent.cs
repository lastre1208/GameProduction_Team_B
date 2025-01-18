using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//作成者:杉山
//bool型が切り替わる瞬間に登録したイベント(メソッド)の処理をする
[System.Serializable]
public class MomentEvent 
{
    [Header("登録イベント")]
    [SerializeField] UnityEvent events;//登録イベント

    //bool型が切り替わった瞬間に登録したイベントを発動させる
    public void ActivateMomentEvent(bool current,bool before,bool currentBool)//currentがcurrentBoolと一致し、beforeがcurrentBoolの逆と一致すればイベントを発動
    {
        if(current==currentBool&&before!=currentBool)
        {
            events.Invoke();
        }
    }
}
