using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//トリック時に押されたボタンに対応した現在のトリックパターンの効果音を取得して効果音を再生する
public class TrickSound : MonoBehaviour
{
    PushedButton_CurrentTrickPattern pushedButton_TrickPattern;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        pushedButton_TrickPattern=GetComponent<PushedButton_CurrentTrickPattern>();
        audioSource=GetComponent<AudioSource>();
    }

    public void SoundEffect()//トリックの効果音の再生
    {
        AudioClip soundEffect = pushedButton_TrickPattern.SoundEffect;//押されたボタンに対応した現在のトリックパターンから効果音を取得
        audioSource.PlayOneShot(soundEffect);//効果音を再生
    }
}
