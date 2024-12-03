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
        //変更したら音量をセーブする
        _audioMixer.SetFloat(_audioTypeName, volume);
        SaveData.SaveAudioVolume(_audioType, volume);
   }
}
