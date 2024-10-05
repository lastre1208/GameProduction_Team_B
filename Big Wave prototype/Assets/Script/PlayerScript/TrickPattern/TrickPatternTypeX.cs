using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//Xボタンを押したときのトリックパターンの効果
public class TrickPatternTypeX : TrickPatternTypeBase
{
    [Header("トリックに用いる効果音")]
    [SerializeField] AudioClip soundEffect;//トリックに用いる効果音
    [Header("敵に与えるダメージ")]
    [SerializeField] float damageAmount = 100;//敵に与えるダメージ
    [Header("音を流すためのコンポーネント")]
    [SerializeField] AudioSource audioSource;
    HP enemy_Hp;
    FeverMode feverMode;
    Critical critical;

    void Start()
    {
        button = Button.X;//ボタンAを設定
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
        feverMode = GameObject.FindWithTag("Player").GetComponent<FeverMode>();
        critical = GameObject.FindWithTag("Player").GetComponent<Critical>();
    }

    public override void TrickEffect()//トリックの効果
    {
        base.TrickEffect();
        audioSource.PlayOneShot(soundEffect);//効果音を再生
        enemy_Hp.Hp -= TotalDamageAmount();//敵にダメージを与える
    }

    float TotalDamageAmount()//ダメージ合計を算出
    {
        float damage = damageAmount;//基本ダメージ(押されたボタンに対応した現在のトリックパターンから取得)
        damage *= feverMode.CurrentPowerUp_GrowthRate;//フィーバーモードのダメージ加算
        damage *= critical.CriticalDamageRate(button);//クリティカルダメージの加算
        return damage;
    }
}
