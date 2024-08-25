using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class TrickDamage : MonoBehaviour
{
    HP enemy_Hp;
    PushedButton_TrickPattern pushedButton_TrickPattern;
    FeverMode feverMode;
    Critical critical;
    void Start()
    {
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
        pushedButton_TrickPattern =GetComponent<PushedButton_TrickPattern>();
        feverMode=GetComponent<FeverMode>();
        critical=GetComponent<Critical>();
    }

    public void Damage()
    {
        enemy_Hp.Hp -= DamageAmount();
    }

    float DamageAmount()//ダメージ合計
    {
        float damage = pushedButton_TrickPattern.CurrentTrickPattern.DamageAmount;//基本ダメージ
        damage *= feverMode.CurrentPowerUp_GrowthRate;//フィーバーモードのダメージ加算
        damage *= critical.CriticalDamageRate(pushedButton_TrickPattern.CurrentTrickPattern.Button);//クリティカルダメージの加算
        return damage;
    }
}
