using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//作成者:杉山
//音量をバーで調節する
public class ChangeAudioVolume : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;
    [Header("音量の名前")]
    [SerializeField] string _audioTypeName;
    [Header("調節用スライダー")]
    [SerializeField] Slider _slider;

    void Start()
    {
        //バーの値に現在の音量を入れる
        _audioMixer.GetFloat(_audioTypeName, out float audioVolume);
        _slider.value = audioVolume;
    }

   public void SetAudioVolume(float volume)
    {
        _audioMixer.SetFloat(_audioTypeName, volume);
    }
}
