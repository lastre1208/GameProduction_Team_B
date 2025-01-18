using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//行動内容
[System.Serializable]
public class ActionPattern//行動とその行動の次に行動を始めるまでの時間
{
    [Header("行動名")]
    [Tooltip("行動名は処理に全く影響はありませんので、開発者にわかりやすいように好きに書いて構わないです(技名考えたりするのは多分モチベにもつながるからね...？)")]
    [SerializeField] string _actionName;//行動名、処理には全く影響はない
    [Header("▼行動")]
    [SerializeField] EnemyActionTypeBase[] action;//行動
    [Header("▼行動時間")]
    [SerializeField] float actionTime;//行動時間

    public EnemyActionTypeBase[] Action
    {
        get { return action; }
    }

    public float ActionTime
    {
        get { return actionTime; }
    }
}
