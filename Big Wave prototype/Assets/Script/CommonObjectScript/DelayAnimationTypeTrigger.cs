using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

//作成者:杉山
//アニメーションを遅らせて再生させる
[System.Serializable]
public class DelayAnimationTypeTrigger
{
    [Header("何秒後に再生するか")]
    [SerializeField] float _delayTime;//(初期化してから)何秒後に再生するか
    [Header("アニメーションコントローラ")]
    [SerializeField] Animator _anim;//動かしたいオブジェクトのアニメーションコントローラ
    [Header("トリガー名")]
    [SerializeField] string _triggerName;//トリガー名
    float _currentTime;//現在の時間
    const float _defaultTime = 0;//初期化時の時間
    bool _played;//再生したか
   
    public void Start()//初期化処理
    {
        _played = false;
        _currentTime = _defaultTime;
    }

    
    public void Update()//毎フレーム行う処理
    {
        UpdateDelay();
    }

    void UpdateDelay()
    {
        if (_played) return;

        _currentTime += _delayTime*Time.deltaTime;

        //まだ再生してないかつ時間になったらアニメーションを再生、
        if(_currentTime>=_delayTime&&!_played)
        {
            _played=true;
            _anim.SetTrigger(_triggerName);
        }
    }
}
