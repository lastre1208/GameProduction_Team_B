using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ステージごとのハイスコア関係のセーブデータ
public static partial class SaveData
{
    //ステージごとのハイスコア関係
    const string _saveDataName_HighScore = "HIGHSCORE_STAGE";//ハイスコアのセーブデータ名
    const float _defaultHighScore = 0;//ハイスコアの初期状態

    public static float GetHighScore(int stageID)//ハイスコアの取得
    {
        string str_stageID = stageID.ToString();
        return PlayerPrefs.GetFloat(_saveDataName_HighScore + str_stageID, _defaultHighScore);
    }

    public static void SaveHighScore(int stageID, float saveScore)//ハイスコアのセーブ
    {
        string str_stageID = stageID.ToString();
        PlayerPrefs.SetFloat(_saveDataName_HighScore + str_stageID, saveScore);
        PlayerPrefs.Save();
    }
}
