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
    [SerializeField] string _audioTypeName;//音量の名前
    [Header("セーブする音量の種類")]
    [SerializeField] AudioType _audioType;
    [Header("調節用スライダー")]
    [SerializeField] Slider _slider;//調節用スライダー

    [Header("調節時に出す音&AudioSource")]
    [SerializeField] AudioClip _se;
    [SerializeField] AudioSource _audioSource;
    const int _countIgnore_PlayAudio = 1;//音を出すときに無視する回数、(Startのタイミングでバーの値の変更が一回されるため、その時に音が鳴るのを防ぐため)
    int _countChangeValue = 0;//値が変更された回数

    void Start()
    {
        //バーの値に現在の音量を入れる
        //セーブデータから現在の音量を取ってくる(無ければaudioMixerの値を入れる)
        float audioVolume;
        _audioMixer.GetFloat(_audioTypeName, out audioVolume);
        audioVolume = SaveData.GetAudioVolume(_audioType,audioVolume);
        _slider.value = audioVolume;
    }

    public void SetAudioVolume(float volume)//音量の変更
    {
        _countChangeValue++;
        PlayAudio();
        //変更したら音量をセーブする
        _audioMixer.SetFloat(_audioTypeName, volume);
        SaveData.SaveAudioVolume(_audioType, volume);
    }

    void PlayAudio()//音を鳴らす
    {
        if (!(_countChangeValue > _countIgnore_PlayAudio)) return;

        if(_se!=null&&_audioSource!=null) _audioSource.PlayOneShot(_se);
    }
}
