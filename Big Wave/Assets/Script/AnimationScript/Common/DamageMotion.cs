using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ダメージモーション(boolとトリガー両方使うことで意図しない時にダメージモーションを再生するのを防ぐ)
public class DamageMotion : MonoBehaviour
{
    [Header("アニメーター")]
    [SerializeField] Animator _enemy_animator;//アニメーター
    [SerializeField] string damageTriggerName;
    [SerializeField] string damageBoolName;
    [Header("何秒経ったら被弾を取り消すか")]
    [SerializeField] float cancelDamagedTime;//何秒経ったら被弾を取り消すか
    bool damageMotion=false;
    float currentCancelDamagedTime = 0;


    public void DamageTrigger()
    {
        _enemy_animator?.SetTrigger(damageTriggerName);
        currentCancelDamagedTime = 0;
        damageMotion = true;
    }

    void Update()
    {
        UpdateCancelDamage();
    }

    void UpdateCancelDamage()//ダメージモーションの再生のキャンセル状態の更新
    {
        currentCancelDamagedTime += Time.deltaTime;

        if (damageMotion == true && currentCancelDamagedTime >= cancelDamagedTime)
        {
            damageMotion = false;
        }

        _enemy_animator?.SetBool(damageBoolName, damageMotion);
    }

    
}
