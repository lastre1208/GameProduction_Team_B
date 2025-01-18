using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

//作成者:杉山
//敵にダメージを与える時の基本ダメージの計算
public partial class DamageToEnemy
{
    [System.Serializable]
    class BaseDamage
    {
        [Header("ダメージ量")]
        [Header("通常時")]
        [SerializeField] float _normalDamageAmount;//通常ダメージ量
        [Header("クリティカル時")]
        [SerializeField] float _criticalDamageAmount;//クリティカルダメージ量

        public float Damage(bool critical)//ダメージ計算
        {
            return critical ? _criticalDamageAmount : _normalDamageAmount;
        }

        public float NormalDamageAmount { get { return _normalDamageAmount; } }

        public float CriticalDamageAmount { get { return _criticalDamageAmount; } }

        //コンストラクタ
        public BaseDamage() { }

        public BaseDamage(float normalDamageAmount, float criticalDamageAmount)
        {
            _normalDamageAmount = normalDamageAmount;
            _criticalDamageAmount = criticalDamageAmount;
        }
    }
}
