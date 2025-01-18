using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//敵にダメージを与える時のジャンプ力ダメージの計算
public partial class DamageToEnemy
{
    [System.Serializable]
    class JumpPowerDamage
    {
        [Header("最大まで溜めた時に加算されるダメージ")]
        [Header("通常時")]
        [SerializeField] float _normalDamageAmount;
        [Header("クリティカル時")]
        [SerializeField] float _criticalDamageAmount;
        [Header("ジャンプ力を取得するためのコンポーネント")]
        [SerializeField] JumpPower _jumpPower;

        public float Damage(bool critical)//ダメージ計算
        {
            //クリティカルとジャンプ力(割合)によって値が変動
            float damage = critical ? _criticalDamageAmount : _normalDamageAmount;
            damage *= _jumpPower.RatioLastJump;

            return damage;
        }

        public float NormalDamageAmount { get { return _normalDamageAmount; } }

        public float CriticalDamageAmount { get { return _criticalDamageAmount; } }

        //コンストラクタ
        public JumpPowerDamage() { }

        public JumpPowerDamage(float damageAffectJumpPower_Normal, float damageAffectJumpPower_Critical, JumpPower jumpPower)
        {
            _normalDamageAmount = damageAffectJumpPower_Normal;
            _normalDamageAmount = damageAffectJumpPower_Critical;
            _jumpPower = jumpPower;
        }
    }
}