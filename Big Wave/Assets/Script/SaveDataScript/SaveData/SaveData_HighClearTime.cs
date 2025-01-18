using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ステージごとの最速クリアタイム関係のセーブデータ
public static partial class SaveData
{
    //ステージごとの最速クリアタイム関係
    const string _saveDataName_HighClearTime = "HIGHCLEARTIME_STAGE";//最速クリアタイムのセーブデータ名
    const float _defaultHighClearTime = 0;//最速クリアタイムの初期状態(秒)

    public static float GetHighClearTime(int stageID)//最速クリアタイムの取得
    {
        string str_stageID = stageID.ToString();
        return PlayerPrefs.GetFloat(_saveDataName_HighClearTime + str_stageID, _defaultHighClearTime);
    }

    public static void SaveHighClearTime(int stageID,float clearTime)//最速クリアタイムのセーブ
    {
        string str_stageID = stageID.ToString();
        PlayerPrefs.SetFloat(_saveDataName_HighClearTime + str_stageID, clearTime);
        PlayerPrefs.Save();
    }
}
