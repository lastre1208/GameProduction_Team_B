using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayText : MonoBehaviour
{

    [SerializeField] float _delayTime;
    [SerializeField] float _displayTime;
    [SerializeField] GameObject _delayObject;
    private bool _startDisplay;
    private float count;
    public bool _StartDisplay
    {
        get
        { return _startDisplay; }

        set { _startDisplay = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        _startDisplay = false;
    }

    // Update is called once per frame
    void Update()
    {
     if( _startDisplay )
        {
            count += Time.deltaTime;

            if( count > _delayTime )
            {
                _delayObject.SetActive(true) ;
                if( count >_displayTime)
                {
                    _delayObject.SetActive(false);
                    _startDisplay=false;
                }
            }

        }   
    }
}
