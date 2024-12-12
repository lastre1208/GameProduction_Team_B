using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

//作成者:杉山
//ムービーのカメラの処理
public class MovieCameraEvent : MonoBehaviour
{
    [Header("BGM")]
    [SerializeField] AudioSource _bgm;
    [Header("ムービー中のUI")]
    [SerializeField] GameObject _movieUI;
    [Header("操作")]
    [SerializeField] PlayerInput _playerInput;
    [Header("ムービーのカメラ")]
    [Tooltip("カメラの優先度はゲーム時のカメラよりも高く設定して置いてください")]
    [SerializeField] CinemachineBlendListCamera _movieCamera;
    [Header("ムービーの時間")]
    [Tooltip("この時間分経ったらフェードアウトが始まります")]
    [SerializeField] float _movieTime;
    [Header("フェードインの設定")]
    [SerializeField] FadeIn _fadeIn;
    [Header("フェードアウトの設定")]
    [SerializeField] FadeOut _fadeOut;
    float _currentMovieTime;//ムービーの現在の時間
    const string _actionMapName_Movie = "Movie";//ムービー用の操作名
    string _actionMapName_Original;//元の操作名
    const float _defaultCurrentMovieTime= 0;
    State_Movie _state = State_Movie.off;//ムービーの再生状況、初期状態はムービーを動かしていない状態

    public State_Movie State { get { return _state; } }

    public void Trigger()//ムービーの開始
    {
        //ムービーが動いていない(初期)状態でなければ無視
        if (_state!=State_Movie.off) return;

        _currentMovieTime = _defaultCurrentMovieTime;
        _state = State_Movie.playing;//再生している状態にする
        _fadeIn.StartTrigger();//フェードインを開始
        if(_movieUI!=null) _movieUI.SetActive(true);//ムービー中のUIを表示
        if (_bgm != null) _bgm.Play();//BGMを再生開始
        //操作をムービー用に変更(元の操作名も覚えておく)
        _actionMapName_Original = _playerInput.currentActionMap.name;
        _playerInput.SwitchCurrentActionMap(_actionMapName_Movie);
        _movieCamera.enabled = true;//カメラをムービー用のものに切り替える
    }

    public void End()//ムービーの終了準備処理(ムービースキップ時にこれを呼ぶ)
    {
        //ムービー再生中でなければ無視
        if (_state != State_Movie.playing) return;

        if (_movieUI != null) _movieUI.SetActive(false);//ムービー中のUIを非表示
        _state = State_Movie.ending;//終了している状態にする
        _fadeIn.CancelTrigger();//フェードインを中断し
        _fadeIn.ReturnDefault();
        _fadeOut.StartTrigger();//フェードアウトを開始(フェードアウトが完全に終わったらムービーが動いていない状態にする)
    }

    void Update()
    {
       UpdateState();
    }

    void UpdateState()//ムービーの再生状況の更新
    {
        if (_state == State_Movie.off|| _state == State_Movie.completed) return;//ムービーが動いていないまたは完了時は特に更新はしない

        switch(_state)
        {
            case State_Movie.playing://再生中

                //ムービーの時間の更新(時間になったら終了状態に入る)
                _currentMovieTime += Time.deltaTime;

                if(_currentMovieTime>=_movieTime)
                {
                    End();
                }

                break;


            case State_Movie.ending://終了中

                //フェードアウトが終わったらムービー完了状態に遷移
                if (_fadeOut.FadeState == State_Fade.completed)
                {
                    _fadeOut.ReturnDefault();
                    _movieCamera.enabled = false;//ムービーのカメラをオフにする
                    _playerInput.SwitchCurrentActionMap(_actionMapName_Original);//操作を元の操作に変更
                    if (_bgm != null) _bgm.Stop();//BGMを止める
                    _state = State_Movie.completed;
                }

                break;
        }
    }
}
