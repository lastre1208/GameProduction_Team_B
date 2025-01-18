using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//初クリア時に表示するメッセージの要素
//項目は、ステージID、それに対応する表示するオブジェクト
[System.Serializable]
public class Element_FirstClearMessageDisplay
{
    [Header("ステージID")]
    [Header("初クリア時にステージIDに対応したオブジェクトを表示させる")]
    [SerializeField] int _stageID;//ステージID
    [Header("表示させるオブジェクト")]
    [SerializeField] GameObject _object;//表示するオブジェクト

    public int StageID { get { return _stageID; } }

    public GameObject Object { get { return _object; } }

    Element_FirstClearMessageDisplay() { }//デフォルトコンストラクタ
}
