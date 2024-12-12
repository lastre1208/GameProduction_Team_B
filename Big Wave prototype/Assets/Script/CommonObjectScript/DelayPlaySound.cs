using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//遅延して音を出す
[System.Serializable]
public class DelayPlaySound
{
    [Header("遅延時間")]
    [SerializeField] float _delayTime;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _sound;
    float _currentTime=0;
    bool _played = false;

    public void Update()
    {
       UpdatePlayTiming();
    }

    void UpdatePlayTiming()//音を出すタイミングの更新
    {
        if (_played) return;

        _currentTime += Time.deltaTime;

        if (_currentTime >= _delayTime)
        {
            if(_audioSource!=null&&_sound!=null) _audioSource.PlayOneShot(_sound);
            _played = true;
        }
    }
}
