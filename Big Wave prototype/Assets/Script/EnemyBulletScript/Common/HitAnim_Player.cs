using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーに被弾モーションさせる
[System.Serializable]
public class HitAnim_Player
{
    public void DamageMotionTrigger(Collider p)//プレイヤーのダメージモーションを再生
    {
        DamageMotion damageMotion_Player;
        damageMotion_Player=p.GetComponentInChildren<DamageMotion>();
        damageMotion_Player.DamageTrigger();
    }
}
