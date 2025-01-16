using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者:杉山
//着弾時の効果音と敵の被ダメモーションのセットの処理を一時的に避難させてます
public class Land : MonoBehaviour
{
    [SerializeField] DamageMotion damageMotion_Enemy;
    [Header("通常時")]
    [SerializeField] AudioSource _sourceNormal;
    [SerializeField] AudioClip _seNormal;
    [Header("クリティカル時")]
    [SerializeField] AudioSource _sourceCritical;
    [SerializeField] AudioClip _seCritical;
    [Header("クリティカルフィーバー時")]
    [SerializeField] AudioSource _sourceCriticalFever;
    [SerializeField] AudioClip _seCriticalFever;

    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip_Critical;
    [SerializeField] AudioClip clip_Normal;
    [SerializeField] AudioClip clip_Fever;
    [SerializeField] Generate_AlongWay generate_AlongWay;

    void Start()
    {
        generate_AlongWay.NormalTrickEffect.LandAction += LandEffect_Normal;
        generate_AlongWay.CriticalTrickEffect.LandAction += LandEffect;
        generate_AlongWay.CriticalFeverTrickEffect.LandAction += LandEffect_Fever;
    }

     public void LandEffect_Normal()//通常時
    {
        //source.PlayOneShot(clip_Normal);
        _sourceNormal.PlayOneShot(_seNormal);
    }
    public void LandEffect()//クリティカル時
    {
        damageMotion_Enemy.DamageTrigger();
        //source.PlayOneShot(clip_Critical);
        _sourceCritical.PlayOneShot(_seCritical);
    }
    public void LandEffect_Fever()//クリティカル＆フィーバー時
    {
        damageMotion_Enemy.DamageTrigger();
        //source.PlayOneShot(clip_Fever);
        _sourceCriticalFever.PlayOneShot(_seCriticalFever);
    }
   
}
