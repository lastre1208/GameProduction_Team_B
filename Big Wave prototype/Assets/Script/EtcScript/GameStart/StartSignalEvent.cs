using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//スタートの合図
public class StartSignalEvent : MonoBehaviour
{
    [Header("フェードインの設定")]
    [SerializeField] FadeIn _fadeIn;
    [Header("フェードアウトが完了してからフェードインを開始するまでの時間")]
    [SerializeField] float _startFadeInTime;
    [Header("フェードインが完了してからゲーム開始までの時間")]
    [SerializeField] float _startGameTime;
    [SerializeField] DisplayStart_GameStart gameStart;
   
    float _currentStartGameTime = 0;
    float _currentStartFadeInTime=0;
    State_GameStartSignal _state = State_GameStartSignal.off;//合図の状況

    public State_GameStartSignal State {  get { return _state; } }

    public void Trigger()//スタートの合図の開始
    {
        //合図が動いていない状態でなければ無視(一度開始したらこの処理は二度と呼べない)
        if (_state != State_GameStartSignal.off) return;

        _state = State_GameStartSignal.fadeIn;
    }

    void Update()
    {
        ShowSignal();
    }

    void ShowSignal()
    {
        if (_state == State_GameStartSignal.completed) return;

        switch(_state)
        {
            case State_GameStartSignal.fadeIn://フェードイン中

                //少し待ってからフェードインを始める
                _currentStartFadeInTime += Time.deltaTime;

                if(_currentStartFadeInTime>=_startFadeInTime&&_fadeIn.State==State_Fade.off)
                {
                    _fadeIn.StartTrigger();
                }

                //フェードインが完了したらスタートの合図をする
                if(_fadeIn.State==State_Fade.completed)
                {
                    _fadeIn.ReturnDefault();
                    _state = State_GameStartSignal.playing;
                    gameStart.DisplayTrigger();
                }

                break;


            case State_GameStartSignal.playing://合図中

                _currentStartGameTime += Time.deltaTime;

                if(_currentStartGameTime>=_startGameTime)//合図が終わったら合図完了状態にする
                {
                    _state = State_GameStartSignal.completed;
                   
                }

                break;
        }
    }
}
