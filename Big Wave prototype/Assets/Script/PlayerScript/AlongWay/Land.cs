using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] Generate_AlongWay generate_AlongWay;

    void Start()
    {
        generate_AlongWay.CriticalTrickEffect.LandAction += LandEffect;
    }

    public void LandEffect()
    {
        animator.SetTrigger("Damage");
        source.PlayOneShot(clip);
    }
}
