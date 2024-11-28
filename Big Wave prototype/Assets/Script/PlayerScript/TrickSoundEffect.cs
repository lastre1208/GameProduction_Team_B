using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickSoundEffect : MonoBehaviour
{
    [Header("クリティカル時の効果音")]
    [SerializeField] AudioClip criticalSE;//クリティカル時の効果音
    [Header("通常状態の効果音")]
    [SerializeField] AudioClip normalSE;//通常状態の効果音
    [Header("最大ピッチ")]
    [SerializeField] float pitchMax;
    [Header("上昇ピッチ量")]
    [SerializeField] float pitchUp;
    [Header("必要なコンポーネント")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] Critical critical;
  
    private float startPitch;
    private void Start()
    {
       startPitch= audioSource.pitch;
    }
    public void PlayTrickSE()//クリティカル状況によって鳴らす音を変える
    {
        AudioClip se=critical.CriticalNow ? criticalSE: normalSE;
        if (critical.CriticalNow&&audioSource.pitch<pitchMax)
        {
            audioSource.pitch += pitchUp;
        }
        else if(!critical.CriticalNow)
        {
          audioSource.pitch =startPitch ;
        }
        audioSource.PlayOneShot(se);
    }
}
