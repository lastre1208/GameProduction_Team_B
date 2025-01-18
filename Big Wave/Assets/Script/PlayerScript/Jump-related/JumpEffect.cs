using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEffect : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] JudgeJumpNow _judgeJumpNow;
    [SerializeField] GameObject _jumpEffect;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _jumpSE;
    [SerializeField] float _effectOffset;
    GameObject EffectPrefab;
    void Start()
    {
        _judgeJumpNow.SwitchJumpNowAction += Effect;
    }

    public void Effect(bool switchJumpNow)
    {
        //ジャンプ開始
        if (switchJumpNow)
        {
            Vector3 E_position=new(_target.transform.position.x,_target.transform.position.y-_effectOffset,_target.transform.position.z);
        EffectPrefab=Instantiate(_jumpEffect,E_position,Quaternion.Euler(-90,0,0),_target.transform);
            _audioSource.PlayOneShot(_jumpSE);//ジャンプの効果音を鳴らす
        }
        //着地時
        else
        {

        }
    }
}
