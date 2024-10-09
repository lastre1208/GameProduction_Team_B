using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionTypeShot : EnemyActionTypeBase
{
    [SerializeField] AnimatorController_Enemy animController;
    [SerializeField] string animName;

    [Header("射撃設定")]
    [SerializeField] ShotTypeBase shotTypeHoming;
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
