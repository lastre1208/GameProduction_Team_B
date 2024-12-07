using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DelayPlaySound
{
    [Header("’x‰„ŽžŠÔ")]
    [SerializeField] float _delayTime;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _sound;
    float _currentTime=0;
    bool _played = false;

    public void Update()
    {
        if(_played) return;

        _currentTime += Time.deltaTime;

        if(_currentTime>=_delayTime)
        {
            _audioSource.PlayOneShot(_sound);
            _played = true;
        }
    }
}
