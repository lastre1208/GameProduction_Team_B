using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//行動内容(一連の動作の設定も可能)
[System.Serializable]
public class SequenceOfActionPattern
{
    [Header("行動名")]
    [Tooltip("行動名は処理に全く影響はありませんので、開発者にわかりやすいように好きに書いて構わないです(技名考えたりするのは多分モチベにもつながるからね...？)")]
    [SerializeField] string _actionName;//行動名、処理には全く影響はない
    [Header("行動内容")]
    [Tooltip("要素を追加すれば一連の動作として設定可能")]
    [SerializeField] ActionPattern[] _actionPatterns;//行動内容(要素を追加すれば一連の動作として設定可能)

    public ActionPattern[] ActionPatterns { get { return _actionPatterns; } }
    //行動の要素数

}
