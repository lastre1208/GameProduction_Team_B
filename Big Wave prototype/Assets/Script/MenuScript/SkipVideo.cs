using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class SkipVideo : MonoBehaviour
{
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] PlayerInput _playerInput;
    bool _skipped = false;
    const string _actionMapNameAfterSkip = "UI";

    public void Skip()
    {
        if(_skipped) return;

        _skipped = true;

        //動画をスキップさせる
        _videoPlayer.time = _videoPlayer.length-0.5; // 再生位置を終了時点に設定

        //操作をムービーのものからUIにする
        _playerInput.SwitchCurrentActionMap(_actionMapNameAfterSkip);
    }
}
