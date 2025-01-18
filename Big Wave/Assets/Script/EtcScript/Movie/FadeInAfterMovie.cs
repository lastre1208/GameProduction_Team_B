using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Video;

public class FadeInAfterMovie : MonoBehaviour
{
    [Header("動画再生後アクティブにする(再生中は非アクティブ)オブジェクト")]
    [SerializeField] GameObject[] _activeAfterMovieEndObjects;//動画再生後アクティブにする(再生中は非アクティブ)オブジェクト
    [Header("動画再生中にのみアクティブにするオブジェクト")]
    [SerializeField] GameObject[] _activeDuringMovieObjects;//動画再生中にのみアクティブにするオブジェクト
    [Header("動画再生中にのみアクティブだが、スキップされた瞬間非アクティブになるオブジェクト")]
    [SerializeField] GameObject[] _activeDuringMovie_SkippedDeactiveObjects;
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

    double SkipTime { get { return videoPlayer.length - _skipTimeBeforeEnd; } }//スキップでどの時間まで飛ばすか

    bool Skipable { get { return videoPlayer.time < SkipTime; } }//スキップ可能か(現在の再生箇所がスキップする箇所の前であればスキップ可能)

    public void Skip()
    {
        if (!Skipable) return;//ムービー出来ないなら無視

        //再生中アクティブ(スキップされた瞬間非アクティブ)にするオブジェクトを隠す
        SwitchActiveObject(_activeDuringMovie_SkippedDeactiveObjects, false);

        //動画をスキップさせる
        videoPlayer.time = SkipTime;
    }

    private void Awake()
    {
        videoPlayer.Stop();
        videoPlayer.frame = 0;
        videoPlayer.loopPointReached += MovieEndEvent;
    }
    void Start()
    {
        Trigger();
    }

    void Trigger()//ムービー開始のトリガー
    {
        //再生後アクティブにするオブジェクトを一旦隠す
        SwitchActiveObject(_activeAfterMovieEndObjects, false);

        //再生中アクティブにするオブジェクトを表示
        SwitchActiveObject(_activeDuringMovieObjects, true);

        //再生中アクティブ(スキップされた瞬間非アクティブ)にするオブジェクトを表示
        SwitchActiveObject(_activeDuringMovie_SkippedDeactiveObjects, true);
        
        //ムービーを流し始める
        videoPlayer.Play();
    }

    void MovieEndEvent(VideoPlayer vb)//ムービーが流れ終わった時に起こすイベント
    {
        //再生後アクティブにするオブジェクトを表示
        SwitchActiveObject(_activeAfterMovieEndObjects, true);

        //再生中アクティブにするオブジェクトを隠す
        SwitchActiveObject(_activeDuringMovieObjects, false);

        //再生中アクティブ(スキップされた瞬間非アクティブ)にするオブジェクトを隠す
        SwitchActiveObject(_activeDuringMovie_SkippedDeactiveObjects, false);

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

    void SwitchActiveObject(GameObject[] gameObjects,bool active)
    {
        for(int i=0; i<gameObjects.Length ;i++)
        {
            gameObjects[i].SetActive(active);
        }
    }
}
