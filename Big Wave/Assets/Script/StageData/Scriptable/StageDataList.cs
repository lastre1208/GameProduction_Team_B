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

    public StageData GetStageData(int dataID)//指定IDのステージデータまるごと取得
    {
        //範囲外の指定IDかを確認
        if(!CheckError(dataID)) return null;

        //特に不備が無ければデータを渡す
        return _stageDatas[dataID];
    }

    public int GetLevel(int dataID)//指定IDのステージのレベルのみ取得(範囲外のIDが入れられてた場合-1を返す)
    {
        //範囲外の指定IDかを確認
        if (!CheckError(dataID)) return -1;

        //特に不備が無ければデータを渡す
        return _stageDatas[dataID].Level;
    }

    public string GetStageSceneName(int dataID)//指定IDのステージのシーン名のみ取得(範囲外のIDが入れられてた場合nullを返す)
    {
        //範囲外の指定IDかを確認
        if (!CheckError(dataID)) return null;

        //特に不備が無ければデータを渡す
        return _stageDatas[dataID].StageSceneName;
    }

    public bool ExistStageData(int dataID)//指定されたIDのステージデータは存在するか
    {
        return 0 <= dataID && dataID < _stageDatas.Length;
    }

    bool CheckError(int dataID)//エラーコード(範囲外のIDに対して警告する)
    {
        //指定されたIDのステージデータは存在するかを確認
        //無い場合はそのデータがない旨を伝える
        if (!ExistStageData(dataID)) 
        {
            Debug.Log(dataID+"というIDのデータはリストにありません");
            return false;
        }

        //要素番号とIDがあってなかった場合デバッグログにリストに不備がある旨を伝える
        if (dataID != _stageDatas[dataID].StageID)
        {
            Debug.Log("要素番号とIDが合致しません！リストに不備があります！");
            return false;
        }

        return true;
    }
}
