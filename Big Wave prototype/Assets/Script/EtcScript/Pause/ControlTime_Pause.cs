using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTime_Pause : MonoBehaviour
{
    JudgePauseNow judgePauseNow;

    void Start()
    {
        judgePauseNow = GetComponent<JudgePauseNow>();
    }

    public void ChangeTimeScale()//ポーズ状態によってゲーム時間の早さを変更
    {
        Time.timeScale = judgePauseNow.PauseNow ? 0 : 1;// ゲームの時間経過を制御する
    }
}
