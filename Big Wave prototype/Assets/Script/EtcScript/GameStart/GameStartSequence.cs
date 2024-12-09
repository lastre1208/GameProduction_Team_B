using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//作成者:杉山
//ゲームのスタートの処理
public class GameStartSequence : MonoBehaviour
{
    [Header("ゲーム中のUI")]
    [SerializeField] GameObject _duringGameUI;
    [SerializeField] MovieCameraEvent _startMovieEvent;
    [SerializeField] StartSignalEvent _startSignalEvent;
    [SerializeField] JudgeGameStart _judgeGameStart;

    [SerializeField] DelayText _delayText;
    State_GameStartSequence _state;//ゲームの開始処理の状態

    public bool FinishedStartMovie
    {
        get
        {
            return _state > State_GameStartSequence.movie;
        }
    }

    void Start()
    {
        _startMovieEvent.Trigger();//最初にムービーを流す
        if(_duringGameUI!=null) _duringGameUI.SetActive(false);//ゲーム中のUIを隠す
        _state = State_GameStartSequence.movie;
    }

    // Update is called once per frame
    void Update()
    {
       UpdateSequebce();
    }

    void UpdateSequebce()
    {
        if (_state == State_GameStartSequence.start) return;//既にスタートしているなら以下の更新処理をしない

        switch(_state)
        {
            case State_GameStartSequence.movie:

                if(_startMovieEvent.State==State_Movie.completed)//ムービーを流し終わったらスタートの合図を出す
                {
                    _startSignalEvent.Trigger();
                    if (_duringGameUI != null) _duringGameUI.SetActive(true);//ゲーム中のUIを表示状態にする
                    _state = State_GameStartSequence.signal;
                    _delayText._StartDisplay = true ;
                }

                break;

            case State_GameStartSequence.signal:

                if(_startSignalEvent.State==State_GameStartSignal.completed)//スタートの合図を出し終わったらゲームスタート
                {
                    _judgeGameStart.GameStartTrigger();
                    _state = State_GameStartSequence.start;
                }

                break;
        }
    }

    
}
