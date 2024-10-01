using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JudgePauseNow : MonoBehaviour
{
    [SerializeField] UnityEvent switchPauseEvents;
    bool pauseNow = false;

    public bool PauseNow
    {
        get { return pauseNow; }
    }

    public void SwitchPause()//É|Å[ÉYèÛë‘ÇîΩì]
    {
        pauseNow=!pauseNow;
        switchPauseEvents.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
