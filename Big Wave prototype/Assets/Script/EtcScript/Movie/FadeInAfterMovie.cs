using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Video;

public class FadeInAfterMovie : MonoBehaviour
{
    [Header("動画再生後アクティブにする(再生中は非アクティブ)オブジェクト")]
    [SerializeField] GameObject[] _activeAfterMovieEnd;//動画再生後アクティブにする(再生中は非アクティブ)オブジェクト
    [Header("動画再生中にのみアクティブにするオブジェクト")]
    [SerializeField] GameObject[] _activeDuringMovieObject;//動画再生中にのみアクティブにするオブジェクト
    [SerializeField] FadeIn_RawImage _fadeIn;
    [SerializeField] VideoPlayer videoPlayer;
    [Header("音関係")]
    [Header("どちらかを空にすれば再生終了時に音が鳴らないようになる")]
    [SerializeField] AudioClip _se;
    [SerializeField] AudioSource _audioSource;
    [Header("操作関係")]
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] string _actionMapNameAfterMovie;
    [Header("スキップ時に動画終了の何秒前まで飛ばすか")]
    [Header("0にしてしまうと動画が最後まで再生されないことがあります")]
    [SerializeField] double _skipTimeBeforeEnd;

    bool _movieEnded=false;//ムービーが終了したか

    public void Skip()
    {
        if (_movieEnded) return;//ムービーが既に終了してるならスキップ

        _movieEnded = true;

        //動画をスキップさせる
        videoPlayer.time = videoPlayer.length- _skipTimeBeforeEnd;
    }

    void Start()
    {
        Trigger();
    }

    void Trigger()//ムービー開始のトリガー
    {
        //再生後アクティブにするオブジェクトを一旦隠す
        for(int i=0; i<_activeAfterMovieEnd.Length ;i++)
        {
            _activeAfterMovieEnd[i].SetActive(false);
        }

        //再生中アクティブにするオブジェクトを表示
        for(int i=0; i<_activeDuringMovieObject.Length ;i++)
        {
            _activeDuringMovieObject[i].SetActive(true);
        }


        //ムービーを流し始める
        videoPlayer.Play();
        videoPlayer.loopPointReached += MovieEndEvent;
    }

    void MovieEndEvent(VideoPlayer vb)//ムービーが流れ終わった時に起こすイベント
    {
        _movieEnded = true;

        //再生後アクティブにするオブジェクトを表示
        for (int i = 0; i < _activeAfterMovieEnd.Length; i++)
        {
            _activeAfterMovieEnd[i].SetActive(true);
        }

        //再生中アクティブにするオブジェクトを隠す
        for (int i = 0; i < _activeDuringMovieObject.Length; i++)
        {
            _activeDuringMovieObject[i].SetActive(false);
        }

        //フェードイン開始
        _fadeIn.StartTrigger();

        //操作をムービーのものからUIにする
        _playerInput.SwitchCurrentActionMap(_actionMapNameAfterMovie);

        //音を出す
        if(_audioSource!=null&&_se!=null)
        {
            _audioSource.PlayOneShot(_se);
        }
        
    }
}
