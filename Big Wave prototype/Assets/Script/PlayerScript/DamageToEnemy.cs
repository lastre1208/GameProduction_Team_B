using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToEnemy : MonoBehaviour
{
    HP enemy_Hp;
    [SerializeField] FeverMode feverMode;
    [SerializeField] Critical critical;
    [SerializeField] PushedButton_CurrentTrickPattern pushedButton_CurrentTrickPattern;
    Queue<float> damageQueue = new Queue<float>();

    void Start()
    {
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
    }

    public void AccumulateDamage(float defaultDamage)//ダメージをキューに蓄積
    {
        //ダメージ計算
        float damage = defaultDamage;//基本ダメージ(押されたボタンに対応した現在のトリックパターンから取得)
        damage *= feverMode.CurrentPowerUp_GrowthRate;//フィーバーモードのダメージ加算
        damage *= critical.CriticalDamageRate(pushedButton_CurrentTrickPattern.PushedButton);//クリティカルダメージの加算
        //キューにダメージを登録
        damageQueue.Enqueue(damage);
    }

    public void CauseDamage()//敵にダメージを与える
    {
        enemy_Hp.Hp -= damageQueue.Dequeue();
    }
}
