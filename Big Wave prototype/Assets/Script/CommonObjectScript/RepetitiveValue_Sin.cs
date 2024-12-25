using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

//作成者:杉山
//時間ごとに反復する値(0～1の間で動く)
//周期に設定された時間ごとに0->1->0となっていく
[System.Serializable]
public class RepetitiveValue_Sin
{
    [Header("周期")]
    [SerializeField] float _cycle;//周期
    [Range(_timeResetMin,_timeResetMax)]
    [Header("リセット時の周期時間")]
    [Tooltip("0または1に設定すると値は0からのスタート、0.5に設定すれば値が1からのスタート")]
    [SerializeField] float _timeReset;//リセット時の時間、0または1に設定すると値が0からのスタート、0.5に設定すれば値が1からのスタート
    float _time;//現在の時間
    bool _isMaxValueReached = false;
    const float _correctedValue=3*Mathf.PI/2;//補正値、値にこれを足すことで0.5->1->0->0.5になるのを防ぎ、0->1->0にすることが出来る
    const float _timeResetMin = 0f;
    const float _timeResetMax = 1f;

    public float Value//値の取得
    {
        get {
            if (_isMaxValueReached)  return 1f;
            
            return MathfExtend.Sin01((2 * Mathf.PI * _time / _cycle) + _correctedValue); }
    }

    public float Cycle//周期の取得、変更
    {
        get { return _cycle; }
        set { _cycle = value; }
    }

    public float TimeReset//リセット時の値の取得、変更
    {
        get { return _timeReset; }
        set { _timeReset =Mathf.Clamp(value,_timeResetMin,_timeResetMax); }//変更時は0～1の値を入力、0または1に設定すると値が0からのスタート、0.5に設定すれば値が1からのスタート
    }

    //デフォルトコンストラクタ
    public RepetitiveValue_Sin()
    {
        _time = 0;
        _cycle = 0f;
        _timeReset = 0f;
    }
    //コンストラクタ
    public RepetitiveValue_Sin(float time,float cycle,float timeReset)
    {
        _time = time;
        _cycle = cycle;
        _timeReset = Mathf.Clamp(timeReset, _timeResetMin, _timeResetMax);
    }

    public void ResetCycle()//周期を初期化させる
    {
        _time = _timeReset*_cycle;
        _isMaxValueReached = false;
    }

    public void UpdateValue()//値の更新
    {
        if (_isMaxValueReached) return;

        
        _time += Time.deltaTime;
        if (Value >= 0.99f)//Sinの仕様上1の値を取る事が殆どない(0.99~までしかいかない場合が多い)ので近似値で代用
        {
            _isMaxValueReached = true;
        }
    }


}
