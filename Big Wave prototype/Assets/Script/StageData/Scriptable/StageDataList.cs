using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ステージデータのリスト
[CreateAssetMenu(menuName = "ScriptableObjects/StageData/StageDataList")]
public class StageDataList : ScriptableObject
{
    [Header("ステージごとのデータ")]
    [Header("要素番号とステージのIDは合わせておいてください(IDの一意性を保つため)")]
    [SerializeField] StageData[] _stageDatas;//ステージごとのデータ

    public StageData Get(int dataID)
    {
        //要素番号が範囲外の場合リストにそのデータがない旨を伝える
        if(dataID<0||_stageDatas.Length<=dataID)
        {
            Debug.Log("そのIDのデータはリストにありません");
            return null;
        }

        //要素番号とIDがあってなかった場合デバッグログにリストに不備がある旨を伝える
        if (dataID != _stageDatas[dataID].StageID)
        {
            Debug.Log("要素番号とIDが合致しません！リストに不備があります！");
            return null;
        }

        //特に不備が無ければデータを渡す
        return _stageDatas[dataID];
    }
}
