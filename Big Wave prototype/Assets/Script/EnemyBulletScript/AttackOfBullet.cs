using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーに当たった時の処理
public class AttackOfBullet : MonoBehaviour
{
    [Header("ダメージ量")]
    [SerializeField] float damage;//ダメージ量
    [Header("プレイヤーに当たった時に弾を消すか")]
    [SerializeField] bool ifHitDestroy=true;//プレイヤーに当たった時に弾を消すか
    [Header("当たった時の効果音")]
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;
    bool hit=false;//当たったか

    void HitTrigger(Collider t)//当たった時の処理
    {
        if (t.gameObject.CompareTag("Player")&&!hit)
        {
            //プレイヤーにダメージを与える
            HP player_Hp;
            player_Hp = t.GetComponent<HP>();
            player_Hp.Hp -= damage;

            //効果音を流す
            if(audioClip!=null&&audioSource!=null)
            {
                audioSource.PlayOneShot(audioClip);
            }

            hit = true;

            if (ifHitDestroy)//trueかつ当たった時弾が消える
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider t)
    {
       HitTrigger(t);
    }
}
