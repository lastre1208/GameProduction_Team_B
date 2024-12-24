using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ステージごとのクリア回数関係のセーブデータ
public static partial class SaveData
{
    //ステージごとのクリア回数関係
    const string _saveDataName_ClearCount = "CLEARCOUNT_STAGE";//クリア回数のセーブデータ名
    const int _defaultClearCount = 0;//クリア回数の初期状態
    const int _maxClearCount = 9999;//クリア回数の上限

    public static int GetClearCount(int stageID)//クリア回数の取得
    {
        string str_stageID = stageID.ToString();
        return PlayerPrefs.GetInt(_saveDataName_ClearCount + str_stageID, _defaultClearCount);
    }

    public static void AddClearCount(int stageID)//クリア回数を一回増やす
    {
        string str_stageID = stageID.ToString();

        //クリア回数を取得して一回増やしてから、セーブ
        int currentClearCount = GetClearCount(stageID);
        currentClearCount++;
        if (currentClearCount > _maxClearCount) currentClearCount = _maxClearCount;//上限を突破しないようにするための処理

        PlayerPrefs.SetInt(_saveDataName_ClearCount + str_stageID, currentClearCount);
        PlayerPrefs.Save();
    }
}
