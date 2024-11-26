using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーに当たった時に音を流す
[System.Serializable]
public class PlayHitAudio
{
    [Header("当たった時の効果音")]
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;

    public void Play()//効果音を流す
    {
        if (audioClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
