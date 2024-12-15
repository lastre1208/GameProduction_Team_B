using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionTypeShot : EnemyActionTypeBase
{
    [Header("アニメーションの設定")]
    [SerializeField] DelayAnimationTypeTrigger _animTrigger;
    [Header("射撃設定")]
    [SerializeField] ShotTypeBase shotType;
    [Header("行動時のエフェクト")]
    [SerializeField] GenerateEffect_Action _generateEffect;


    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        shotType.InitShotTiming();
        if (_generateEffect != null) _generateEffect.OnEnter();
        _animTrigger.Start();//モーションの再生処理の初期化
    }

    public override void OnUpdate()
    {
        shotType.UpdateShotTiming();
        if (_generateEffect != null) _generateEffect.OnUpdate();
        _animTrigger.Update();//モーションの再生処理の更新
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {

    }
}
