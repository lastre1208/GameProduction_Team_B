using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//着弾時の効果音と敵の被ダメモーションのセットの処理を一時的に避難させてます
public class Land : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] Generate_AlongWay generate_AlongWay;

    void Start()
    {
        generate_AlongWay.CriticalTrickEffect.LandAction += LandEffect;
        generate_AlongWay.CriticalFeverTrickEffect.LandAction += LandEffect;
    }

    public void LandEffect()
    {
        animator.SetTrigger("Damage");
        source.PlayOneShot(clip);
    }
}
