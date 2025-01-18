using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//作成者:杉山
//遅延して文字を表示する
[System.Serializable]
public class DelayDisplayText
{
    [Header("表示する文字")]
    [SerializeField] TMP_Text _text;
    [Header("遅延時間")]
    [SerializeField] float _delayTime;
    [Header("表示時間")]
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

    void UpdateDisplayTiming()//表示するタイミングの更新
    {
        if (_displayed) return;

        _currentDelayTime += Time.deltaTime;

        if(_currentDelayTime>=_delayTime)
        {
            _displayed = true;
            if (_text != null) _text.enabled = true;
        }
    }

    void UpdateHideTiming()//表示してから文字を隠すタイミングの更新
    {
        if (_hided||!_displayed) return;

        _currentDisplayTime += Time.deltaTime;

        if(_currentDisplayTime>=_displayTime)
        {
            _hided = true;
            if (_text != null) _text.enabled = false;
        }
    }
}
