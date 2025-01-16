using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

//作成者:杉山
//ムービーの状態をリセットする
public class MovieReset : MonoBehaviour
{
    [SerializeField] VideoPlayer _videoPlayer;

    public void ResetMovie()
    {
        _videoPlayer.frame = 0;
        _videoPlayer.Pause();
    }
}
