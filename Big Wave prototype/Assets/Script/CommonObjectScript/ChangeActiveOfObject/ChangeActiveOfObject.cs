using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//表示・非表示状態を時間をずらして変更する
[System.Serializable]
public class ChangeActiveOfObject
{
    [Header("表示状態を切り替えたいオブジェクトの設定")]
    [SerializeField] Element_ChangeActionOfObject[] _objects;
    const float _defaultCurrentChangeTime = 0;
    float _currentchangeTime;

    public ChangeActiveOfObject()//デフォルトコンストラクタ
    {
        _currentchangeTime = _defaultCurrentChangeTime;
    }

    public void Init()//初期化処理、(もう一度処理をしたい時に呼ぶ)
    {
        for(int i=0; i<_objects.Length;i++)
        {
            _objects[i].Changed = false;
        }

        _currentchangeTime=_defaultCurrentChangeTime;
    }

    public void UpdateActive()//更新処理
    {
        _currentchangeTime += Time.deltaTime;

        for (int i = 0; i<_objects.Length; i++)
        {
            Element_ChangeActionOfObject _obj = _objects[i];

            bool changeActive = !_obj.Changed && _currentchangeTime >= _obj.ChangeTime;//まだ切り替えてない かつ そのオブジェクトの遅延時間に達した時のみ切り替え

            if (changeActive)
            {
                //切り替え処理
                _obj.Object.SetActive(_obj.Active);
                _obj.Changed = true;
            }
        }
    }
}
