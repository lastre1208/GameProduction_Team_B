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
    bool _changed = false;//変更したか

    public ChangeActiveObject(GameObject gameObject,bool active,float changeTime)//コンストラクタ
    {
        _object = gameObject;
        _active = active;
        _changeTime = changeTime;
    }

    public ChangeActiveObject()//デフォルトコンストラクタ
    {
        _object = null;
        _active = false;
        _changeTime=0;
    }

    public void UpdateActive()
    {
        if(_changed) return;

        _currentchangeTime += Time.deltaTime;

        if(_currentchangeTime>=_changeTime)
        {
            _object.SetActive(_active);
            _changed = true;
        }
    }
}
