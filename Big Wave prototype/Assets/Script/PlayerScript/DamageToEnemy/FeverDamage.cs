using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//作成者:杉山
//敵にダメージを与える時のフィーバー状態時のダメージの計算
public partial class DamageToEnemy
{
    [System.Serializable]
    class FeverDamage
    {
        [Header("ダメージの増加率")]
        [Header("通常時")]
        [SerializeField] float _normalDamageGrowthRate;//通常時のダメージの増加率
        [Header("フィーバーモード時")]
        [SerializeField] float _feverDamageGrowthRate;//フィーバーモード時のダメージ増加率
        [Header("フィーバーモードかを取得するためのコンポーネント")]
        [SerializeField] FeverMode _feverMode;

        public float DamageRate()//ダメージ倍率計算
        {
            return _feverMode.FeverNow ? _feverDamageGrowthRate : _normalDamageGrowthRate;
        }

        public float NormalDamageGrowthRate { get { return _normalDamageGrowthRate; } }

        public float FeverDamageGrowthRate { get { return _feverDamageGrowthRate; } }

        //コンストラクタ
        public FeverDamage() { }

        public FeverDamage(float normalDamageGrowthRate, float feverDamageGrowthRate, FeverMode feverMode)
        {
            _normalDamageGrowthRate = normalDamageGrowthRate;
            _feverDamageGrowthRate = feverDamageGrowthRate;
            _feverMode = feverMode;
        }
    }
}
