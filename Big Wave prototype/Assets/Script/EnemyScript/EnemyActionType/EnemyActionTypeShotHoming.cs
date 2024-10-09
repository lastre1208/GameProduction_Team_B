using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionTypeShotHoming : EnemyActionTypeBase
{
    [SerializeField] AnimatorController_Enemy animController;
    [SerializeField] string animName;

    [Header("ホーミング弾の射撃設定")]
    [SerializeField] ShotTypeHomingBullet shotTypeHoming;
    [Header("▼GamePos")]
    [SerializeField] GameObject gamePos;//GamePos、弾をこれの子オブジェクトとして配置する
    [Header("行動時のエフェクト")]
    [SerializeField] ActionEffect actionEffect;


    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        shotTypeHoming.InitShotTiming();
        actionEffect.Generate();//エフェクト生成
        animController.AnimControl_Trigger(animName);
    }

    public override void OnUpdate()
    {
       shotTypeHoming.UpdateShotTiming();
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {
        
    }
}
