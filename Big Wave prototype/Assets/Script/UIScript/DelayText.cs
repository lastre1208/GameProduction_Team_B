using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:福島
//
public class DelayText : MonoBehaviour
{
    [Header("遅延時間")]
    [SerializeField] float _delayTime;//遅延時間
    [Header("表示時間")]
    [SerializeField] float _displayTime;//表示時間
    [Header("表示するオブジェクト")]
    [SerializeField] GameObject _delayObject;//表示するオブジェクト
    private bool _startDisplay;//表示時間の更新をするか
    private float count;//時間

    public bool _StartDisplay
    {
        get { return _startDisplay; }
        set { _startDisplay = value; }
    }

    void Start()
    {
        _startDisplay = false;
    }

    void Update()
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        if (!_startDisplay) return;

        count += Time.deltaTime;

        if (count > _delayTime)
        {
            _delayObject.SetActive(true);

            if (count > _displayTime)
            {
                _delayObject.SetActive(false);
                _startDisplay = false;
            }
        }
    }
}
