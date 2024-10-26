using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//敵にダメージを与える
public class DamageToEnemy : MonoBehaviour
{
    [Header("基本ダメージ量")]
    [SerializeField] float defaultDamageAmount;//基本ダメージ量
    [Header("フィーバーモード時のダメージの増加率")]
    [SerializeField] float damageGrowthRate_Fever;//フィーバーモード時のダメージ増加率
    [Header("クリティカル時のダメージの増加率")]
    [SerializeField] float damageGrowthRate_Critical;//クリティカル時のダメージ増加率

    [Header("必要なコンポーネント")]
    [SerializeField] FeverMode feverMode;
    [SerializeField] Critical critical;
    [SerializeField] PushedButton_CurrentTrickPattern pushedButton_CurrentTrickPattern;

    const float damageGrowthRate_Normal=1;//等倍(ダメージ増加率)
    HP enemy_Hp;
    Queue<float> damageQueue = new Queue<float>();

    void Start()
    {
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
    }

    public void AccumulateDamage()//ダメージをキューに蓄積
    {
        //ダメージ計算
        float damage = defaultDamageAmount;//基本ダメージ
        damage *= feverMode.FeverNow?damageGrowthRate_Fever:damageGrowthRate_Normal;//フィーバーモードのダメージ加算
        damage *= critical.CriticalNow?damageGrowthRate_Critical:damageGrowthRate_Normal;//クリティカルダメージの加算
        //キューにダメージを登録
        damageQueue.Enqueue(damage);
    }

    public void CauseDamage()//敵にダメージを与える
    {
        enemy_Hp.Hp -= damageQueue.Dequeue();
    }
}
