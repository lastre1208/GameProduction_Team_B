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


//行動時のエフェクト
[System.Serializable]
class ActionEffect
{
    [Header("エフェクトを生成するか")]
    [SerializeField] bool generate = true;
    [Header("GenerateEffect(エフェクト生成)コンポーネント")]
    [SerializeField] GenerateEffect generateEffect;
    [Header("遅延生成時間")]
    [SerializeField] float delayTime;

    public void Generate()
    {
        if(generate)//生成するなら
        {
            generateEffect.Generate(delayTime);//delayTime遅延してエフェクトを生成
        }
    }
}
