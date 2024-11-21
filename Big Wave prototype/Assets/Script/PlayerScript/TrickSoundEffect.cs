using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickSoundEffect : MonoBehaviour
{
    [Header("クリティカル時の効果音")]
    [SerializeField] AudioClip criticalSE;//クリティカル時の効果音
    [Header("通常状態の効果音")]
    [SerializeField] AudioClip normalSE;//通常状態の効果音
    [Header("必要なコンポーネント")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] Critical critical;

    public void PlayTrickSE()//クリティカル状況によって鳴らす音を変える
    {
        AudioClip se=critical.CriticalNow ? criticalSE: normalSE;
        audioSource.PlayOneShot(se);
    }
}
