using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void SoundEffect()//ƒgƒŠƒbƒN‚ÌŒø‰Ê‰¹‚ÌÄ¶
    {
        AudioClip soundEffect = pushedButton_TrickPattern.SoundEffect;
        audioSource.PlayOneShot(soundEffect);
    }
}
