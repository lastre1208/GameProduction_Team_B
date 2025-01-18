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
    [Header("被弾時に発生させるエフェクト")]
    [SerializeField] GameObject damageEffect;
    [Header("ダメージ回数をカウントするコンポーネント")]
    private ScoreGameScene_HP scoreGameScene_HP;
    bool hit = false;//当たったか

    void Start()
    {
        onTriggerEvent.EnterAction += HitTrigger;//当たった時の処理を登録
    }

    public void HitTrigger(Collider t)//当たった時の処理
    {
        if (t.gameObject.CompareTag("Player")&&!hit)
        {
            hit = true;

            scoreGameScene_HP = GameObject.FindWithTag("ScoreManager_HP").GetComponent<ScoreGameScene_HP>();
            scoreGameScene_HP.DamageCount++;//ダメージを受けた回数を増やす

            damageToPlayer.Damage(t);//プレイヤーにダメージを与える

            hitAnim_Player.DamageMotionTrigger(t);//プレイヤーに被弾モーションをさせる

            playHitAudio.Play();//効果音を流す
            
            destroyBullet.Destroy();//弾を破壊する

            Instantiate(damageEffect,t.transform.position,t.transform.rotation, t.transform);
        }
    }
}
