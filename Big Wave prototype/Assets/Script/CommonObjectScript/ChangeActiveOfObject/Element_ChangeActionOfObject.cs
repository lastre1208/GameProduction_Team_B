using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//表示・非表示状態を時間をずらして変更するコンポーネントの要素
[System.Serializable]
public class Element_ChangeActionOfObject
{
    [Header("表示状態を切り替えるオブジェクト")]
    [SerializeField] GameObject _object;
    [Header("表示状態")]
    [SerializeField] bool _active;
    [Header("何秒後に表示状態を切り替えるか")]
    [SerializeField] float _changeTime;
    bool _changed = false;//変更したか

    public GameObject Object { get { return _object; } }

    public bool Active { get { return _active; } }

    public float ChangeTime { get { return _changeTime; } }

    public bool Changed
    { 
        get { return _changed; }
        set { _changed = value; }
    }
}
