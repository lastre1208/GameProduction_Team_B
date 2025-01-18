using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//行動時に効果音を出すコンポネントの音の設定項目
[System.Serializable]
public class Audios_PlayAudio_Action
{
    [Header("遅延時間")]
    [SerializeField] float _delayTime;//遅延時間
    [Header("効果音")]
    [SerializeField] AudioClip _se;//効果音
    [Header("AudioSource")]
    [SerializeField] AudioSource _audioSource;//AudioSource
    bool _played;//音を出したか

    public float DelayTime { get { return _delayTime; } }//遅延時間

    public void Play()//効果音を出す
    {
        _audioSource.PlayOneShot(_se);
    }

    public bool Played//音を出したか
    {
        get { return _played; }
        set { _played = value; }
    }
}
