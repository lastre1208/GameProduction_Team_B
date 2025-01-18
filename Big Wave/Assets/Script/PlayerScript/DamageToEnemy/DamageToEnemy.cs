using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//敵にダメージを与える
//仕様の変更(クリティカルでなくてもダメージを与えられていたのをクリティカルでないとダメージを与えられないようにしました)
public partial class DamageToEnemy : MonoBehaviour
{
    [Header("基本ダメージの設定")]
    [SerializeField] BaseDamage _baseDamage;
    [Header("フィーバーモード時のダメージの設定")]
    [SerializeField] FeverDamage _feverDamage;
    [Header("ジャンプ力依存のダメージの設定")]
    [SerializeField] JumpPowerDamage _jumpPowerDamage;

    [Header("必要なコンポーネント")]
    [SerializeField] Critical _critical;
    [SerializeField] Generate_AlongWay _generate_AlongWay;

    HP enemy_Hp;//敵のHP
    Queue<float> damageQueue = new Queue<float>();

    void Start()
    {
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponentInChildren<HP>();
        _generate_AlongWay.CriticalTrickEffect.LandAction += CauseDamage;
        _generate_AlongWay.NormalTrickEffect.LandAction += CauseDamage;
        _generate_AlongWay.CriticalFeverTrickEffect.LandAction += CauseDamage;
    }

    public void AccumulateDamage()//ダメージをキューに蓄積
    {
        float damage = CalcDamage();//ダメージ計算
        
        damageQueue.Enqueue(damage);//キューにダメージを登録
    }

    float CalcDamage()//ダメージ計算
    {
        bool critical = _critical.CriticalNow;

        float damage = 0;

        damage += _baseDamage.Damage(critical);//基本ダメージ量加算

        damage *= _feverDamage.DamageRate();//フィーバーモードのダメージ倍率分

        damage += _jumpPowerDamage.Damage(critical);//ジャンプ力(割合)に応じたダメージ加算

        return damage;
    }

    public void CauseDamage()//敵にダメージを与える
    {
        enemy_Hp.Hp -= damageQueue.Dequeue();
    }
}
