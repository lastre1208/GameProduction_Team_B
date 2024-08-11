using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyActionTypeBase : MonoBehaviour
{
    /// <summary>
    /// 行動開始時に呼ぶ処理
    /// beforeActionTypeは前の行動パターンでした行動
    /// </summary>
    public virtual void OnEnter(EnemyActionTypeBase[] beforeActionType) { }

    /// <summary>
    /// 行動中毎フレーム呼ぶ処理
    /// </summary>
    public virtual void OnUpdate() { }

    /// <summary>
    /// 行動終了時に呼ぶ処理
    /// beforeActionTypeは次の行動パターンでする行動
    /// </summary>
    public virtual void OnExit(EnemyActionTypeBase[] nextActionType) { }
}
