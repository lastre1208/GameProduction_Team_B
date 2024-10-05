using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JudgePauseNow : MonoBehaviour
{
    [SerializeField] UnityEvent pauseEvents;
    [SerializeField] UnityEvent resumeEvents;
    bool pauseNow = false;

    public bool PauseNow
    {
        get { return pauseNow; }
    }

    public void SwitchPause()//ポーズ状態を反転
    {
        pauseNow=!pauseNow;

        if(pauseNow)//ポーズ時
        {
            pauseEvents.Invoke();
        }
        else//再会時
        {
            resumeEvents.Invoke();
        }
    }
}
