using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//表示・非表示状態を時間をずらして変更する
[System.Serializable]
public class ChangeActiveObject
{
    [SerializeField] GameObject _object;
    [Header("表示状態")]
    [SerializeField] bool _active;
    [Header("何秒後に表示状態を切り替えるか")]
    [SerializeField] float _changeTime;
    float _currentchangeTime = 0;

    public void UpdateActive()
    {
        _currentchangeTime += Time.deltaTime;

        if(_currentchangeTime>=_changeTime)
        {
            _object.SetActive(_active);
        }
    }
}
