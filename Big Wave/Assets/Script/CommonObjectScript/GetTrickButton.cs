using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//受け取ったTrickButton(enum型)の値に対応したオブジェクトを返す
[System.Serializable]
public class GetTrickButton<T>
{
    [Header("東(右)")]
    [SerializeField] T _east;
    [Header("西(左)")]
    [SerializeField] T _west;
    [Header("南(下)")]
    [SerializeField] T _south;
    [Header("北(上)")]
    [SerializeField] T _north;

    public GetTrickButton() { }//デフォルトコンストラクタ

    public GetTrickButton(T east,T west,T south,T north)//コンストラクタ
    {
        _east = east;
        _west = west;
        _south = south;
        _north = north;
    }

    public T Get(TrickButton trickButton)//受け取ったTrickButton(enum型)の値に対応したオブジェクトを返す
    {
        switch (trickButton)
        {
            case TrickButton.east: return _east;
            case TrickButton.west: return _west;
            case TrickButton.south: return _south;
            case TrickButton.north: return _north;
        }

        //例外
        return default(T);
    }
}
