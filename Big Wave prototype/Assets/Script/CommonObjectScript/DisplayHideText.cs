using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class DisplayHideText
{
    [Header("•\Ž¦‚·‚é•¶Žš")]
    [SerializeField] TMP_Text _text;
    [Header("’x‰„ŽžŠÔ")]
    [SerializeField] float _delayTime;
    [Header("•\Ž¦ŽžŠÔ")]
    [SerializeField] float _displayTime;
    float _currentDelayTime = 0;
    float _currentDisplayTime = 0;
    bool _displayed = false;
    bool _hided = false;

    public void Update()
    {
        UpdateDisplayTiming();
        UpdateHideTiming();
    }

    void UpdateDisplayTiming()
    {
        if (_displayed) return;

        _currentDelayTime += Time.deltaTime;

        if(_currentDelayTime>=_delayTime)
        {
            _displayed = true;
            _text.enabled = true;
        }
    }

    void UpdateHideTiming()
    {
        if (_hided||!_displayed) return;

        _currentDisplayTime += Time.deltaTime;

        if(_currentDisplayTime>=_displayTime)
        {
            _text.enabled = false;
        }
    }
}
