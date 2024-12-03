using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーに当たった時の処理
public class AttackOfBullet : MonoBehaviour
{
    [Header("弾破壊設定")]
    [SerializeField] DestroyBullet destroyBullet;//弾破壊設定
    [Header("効果音設定")]
    [SerializeField] PlayHitAudio playHitAudio;//効果音設定
    [Header("ダメージ設定")]
    [SerializeField] DamageToPlayer damageToPlayer;//ダメージ設定
    [Header("プレイヤー被弾時のダメージモーションの設定")]
    [SerializeField] HitAnim_Player hitAnim_Player;//プレイヤー被弾時のダメージモーションの設定
    [Header("接触判定のコンポーネント")]
    [SerializeField] OnTriggerActionEvent onTriggerEvent;//接触判定のコンポーネント
    bool hit=false;//当たったか
    [Header("被弾時に発生させるエフェクト")]
    [SerializeField] GameObject damageEffect;
    GameObject damageEffectPrefab;
    void Start()
    {
        onTriggerEvent.EnterAction += HitTrigger;//当たった時の処理を登録
    }

    public void HitTrigger(Collider t)//当たった時の処理
    {
        if (t.gameObject.CompareTag("Player")&&!hit)
        {
            hit = true;

            damageToPlayer.Damage(t);//プレイヤーにダメージを与える

            hitAnim_Player.DamageMotionTrigger(t);//プレイヤーに被弾モーションをさせる

            playHitAudio.Play();//効果音を流す
            
            destroyBullet.Destroy();//弾を破壊する

            damageEffectPrefab=Instantiate(damageEffect,GameObject.Find("Player").transform.position,Quaternion.identity, GameObject.Find("Player").transform);
        }
    }
}
