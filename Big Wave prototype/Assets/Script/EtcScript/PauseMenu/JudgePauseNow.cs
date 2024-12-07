using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

//作成者:杉山
//ポーズの判断
public class JudgePauseNow : MonoBehaviour
{
    public event Action PauseAction;
    public event Action ResumeAction;
    public event Action<bool> SwitchPauseAction;//ポーズ状態になる時にtrue、ポーズ解除するときにfalse
    bool pauseNow = false;

    public bool PauseNow
    {
        get { return pauseNow; }
    }

    public void SwitchPause()//ポーズ状態を反転
    {
        pauseNow=!pauseNow;

        SwitchPauseAction?.Invoke(pauseNow);

        if(pauseNow)//ポーズ時
        {
            PauseAction?.Invoke();
        }
        else//再会時
        {
            ResumeAction?.Invoke();
        }
    }
}
