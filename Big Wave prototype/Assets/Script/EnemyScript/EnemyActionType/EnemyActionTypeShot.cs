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
    [SerializeField] ActionEffect actionEffect;


    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        shotType.InitShotTiming();
        actionEffect.Generate();//エフェクト生成
        _animTrigger.Start();//モーションの再生処理の初期化
    }

    public override void OnUpdate()
    {
        shotType.UpdateShotTiming();
        _animTrigger.Update();//モーションの再生処理の更新
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {

    }
}
