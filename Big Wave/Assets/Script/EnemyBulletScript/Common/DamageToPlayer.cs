using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーにダメージを与える
[System.Serializable]
public class DamageToPlayer
{
    [Header("ダメージ量")]
    [SerializeField] float damage;//ダメージ量

    public void Damage(Collider p)//プレイヤーにダメージを与える
    {
        HP player_Hp;
        player_Hp = p.GetComponentInChildren<HP>();

        if (player_Hp == null)//取得出来なかったらHPを減らさずエラーコード
        {
            Debug.Log("HPを取得できませんでした");
            return;
        }

        player_Hp.Hp -= damage;
    }
}
