using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//敵の弾(攻撃)の標的(プレイヤー)に向かっての直線撃ち
public class EnemyActionTypeShotToTarget1 : EnemyActionTypeBase
{
    [SerializeField] Animator anim;


    [SerializeField] ShotTypeNormalBullet shotTypeNormal;
    [Header("行動時のエフェクト")]
    [SerializeField] ActionEffect actionEffect;

    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
       shotTypeNormal.InitShotTiming();
        actionEffect.Generate();//エフェクト生成
        anim.SetTrigger("Attack");
    }

    public override void OnUpdate()
    {
       shotTypeNormal.UpdateShotTiming();
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {

    }


    
}
