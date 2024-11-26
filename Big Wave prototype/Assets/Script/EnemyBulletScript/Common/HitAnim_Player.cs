using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーに被弾モーションさせる
[System.Serializable]
public class HitAnim_Player
{
    [Header("ダメージ条件の名前")]
    [SerializeField] string damageParaName;//ダメージ条件の名前

    public void DamageMotionTrigger(Collider p)//プレイヤーのダメージモーション
    {
        Animator playerAnimator;
        playerAnimator=p.GetComponentInChildren<Animator>();

        playerAnimator.SetTrigger(damageParaName);
    }
}
