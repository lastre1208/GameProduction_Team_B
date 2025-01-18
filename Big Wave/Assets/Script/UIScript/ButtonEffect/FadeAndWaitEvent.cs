using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//作成者:杉山
//フェードアウトをして数秒待った後イベントを起こす
public class FadeAndWaitEvent : MonoBehaviour
{
    [Header("フェードアウト")]
    [Header("フェードアウトしない場合は空のままにしてください")]
    [SerializeField] FadeOut _fadeOut;//フェードアウト
    [Header("何秒待ってからイベントを起こすか")]
    [Header("フェードアウトする場合はフェードアウトが完了してからこの時間分待ちます")]
    [SerializeField] float _waitTime;//遅延時間
    [Header("イベント")]
    [SerializeField] UnityEvent _event;//起こしたいイベント
    [Header("連打してもイベントを起こすまでは反応しないようにするか")]
    [SerializeField] bool _preventMash;//連打してもイベントを起こすまでは反応しないようにするか
    bool _switch = false;

    public void Trigger()
    {
        if (_preventMash && _switch) return;

        _switch = true;

        if (_fadeOut!=null)//フェードアウトする場合
        {
            _fadeOut.StartTrigger();
        }
        else//しない場合
        {
            StartCoroutine(DelayEventCoroutine());
        }
    }

    void Update()
    {
        CheckFade();
    }

    void CheckFade()
    {
        if (_fadeOut == null) return;

        //フェードアウト完了次第遅延してイベントを起こす
        if(_fadeOut.FadeState==State_Fade.completed&&_switch)
        {
            StartCoroutine(DelayEventCoroutine());
            _fadeOut.ReturnDefault();
        }
    }

    IEnumerator DelayEventCoroutine()
    {
        yield return new WaitForSecondsRealtime(_waitTime);
        //時間分待った後にイベントを起こす

        _switch = false;
        _event.Invoke();
      
    }
}
