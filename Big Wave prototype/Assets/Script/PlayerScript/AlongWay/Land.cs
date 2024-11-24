using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者:杉山
//着弾時の効果音と敵の被ダメモーションのセットの処理を一時的に避難させてます
public class Land : MonoBehaviour
{
    [SerializeField] Animator animator;
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
        source.PlayOneShot(clip_Normal);
    }
    public void LandEffect()//クリティカル時
    {
        
        animator.SetTrigger("Damage");
        source.PlayOneShot(clip_Critical);
    }
    public void LandEffect_Fever()//フィーバー時
    {
        animator.SetTrigger("Damage");
        source.PlayOneShot(clip_Fever);
    }
   
}
