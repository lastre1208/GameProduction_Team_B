using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

//作成者:杉山
//ゲームスタートの判断
public class JudgeGameStart : MonoBehaviour
{
    public event Action StartGameAction;//ゲーム開始時に呼ぶ処理
    private bool isStarted = false;//ゲームが開始されたか(カウントダウンは終わったか)

    public bool IsStarted { get { return isStarted; } }

    public void GameStartTrigger()//ゲームスタートしたい時にこれを呼ぶ、一度スタートしたらこれを再度呼ぶことは出来ない
    {
        if (isStarted) return;

        isStarted = true;
        StartGameAction?.Invoke();
    }
}
