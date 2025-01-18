using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//クリアレベル関係のセーブデータ
public static partial class SaveData
{
    //クリアレベル関係
    const string _saveDataName_ClearLevel = "CLEARLEVEL";//クリアレベルのセーブデータ名
    const int _defaultClearLevel = 0;//クリアレベルの初期状態

    public static int GetClearLevel()//クリアレベルの取得
    {
        return PlayerPrefs.GetInt(_saveDataName_ClearLevel, _defaultClearLevel);
    }

    public static void SaveClearLevel(int saveLevel)//クリアレベルのセーブ
    {
        PlayerPrefs.SetInt(_saveDataName_ClearLevel, saveLevel);
        PlayerPrefs.Save();
    }
}
