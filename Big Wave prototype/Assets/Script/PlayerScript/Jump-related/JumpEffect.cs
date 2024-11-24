using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEffect : MonoBehaviour
{
    [SerializeField] JudgeJumpNow _judgeJumpNow;
    [SerializeField] GameObject _waterSplashEffect;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _jumpSE;

    void Start()
    {
        _judgeJumpNow.SwitchJumpNowAction += Effect;
    }

    public void Effect(bool switchJumpNow)
    {
        _waterSplashEffect.SetActive(!switchJumpNow);//水しぶきをジャンプ開始時に消す、着地時に出す

        //ジャンプ開始
        if (switchJumpNow)
        {
            _audioSource.PlayOneShot(_jumpSE);//ジャンプの効果音を鳴らす
        }
        //着地時
        else
        {

        }
    }
}
