using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//敵にダメージを与える
//仕様の変更(クリティカルでなくてもダメージを与えられていたのをクリティカルでないとダメージを与えられないようにしました)
public class DamageToEnemy : MonoBehaviour
{
    [Header("通常ダメージ量")]
    [SerializeField] float normalDamageAmount;//通常ダメージ量
    [Header("クリティカルダメージ量")]
    [SerializeField] float criticalDamageAmount;//クリティカルダメージ量
    [Header("フィーバーモード時のダメージの増加率")]
    [SerializeField] float damageGrowthRate_Fever;//フィーバーモード時のダメージ増加率

    [Header("必要なコンポーネント")]
    [SerializeField] FeverMode feverMode;
    [SerializeField] Critical critical;
    [SerializeField] PushedButton_CurrentTrickPattern pushedButton_CurrentTrickPattern;
    [SerializeField] Generate_AlongWay generate_AlongWay;

    const float damageGrowthRate_Normal=1;//等倍(ダメージ増加率)
    HP enemy_Hp;
    Queue<float> damageQueue = new Queue<float>();

    void Start()
    {
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponentInChildren<HP>();
        generate_AlongWay.CriticalTrickEffect.LandAction += CauseDamage;
        generate_AlongWay.NormalTrickEffect.LandAction += CauseDamage;
        generate_AlongWay.CriticalFeverTrickEffect.LandAction += CauseDamage;
    }

    public void AccumulateDamage()//ダメージをキューに蓄積
    {
        //ダメージ計算
        float damage = critical.CriticalNow ? criticalDamageAmount : normalDamageAmount;//ダメージ量
        damage *= feverMode.FeverNow ? damageGrowthRate_Fever : damageGrowthRate_Normal;//フィーバーモードのダメージ加算
        //キューにダメージを登録
        damageQueue.Enqueue(damage);
    }

    public void CauseDamage()//敵にダメージを与える
    {
        enemy_Hp.Hp -= damageQueue.Dequeue();
    }
}
