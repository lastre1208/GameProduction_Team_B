using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//作成者:杉山
//セーブデータ
//・セーブデータ項目
//各種音量設定(マスターとBGMとSE)
//ステージごとのハイスコア
//クリアレベル
public static class SaveData
{
    const string _saveDataName_Audio = "AUDIOVOLUME";//音量のセーブデータ名
    const string _saveDataName_HighScore = "HIGHSCORE_STAGE";//ハイスコアのセーブデータ名
    const string _saveDataName_ClearLevel = "CLEARLEVEL";//クリアレベルのセーブデータ名
    const float defaultHighScore = 0;//ハイスコアの初期状態
    const int defaultClearLevel = 0;//クリアレベルの初期状態


    //音量関係
    public static float GetAudioVolume(AudioType audioType,float noSaveVal)//音量の取得
    {
        string audioVolumeType=audioType.ToString();
        return PlayerPrefs.GetFloat(_saveDataName_Audio + audioVolumeType, noSaveVal);
    }

    public static void SaveAudioVolume(AudioType audioType,float saveVolume)//音量のセーブ
    {
        string audioVolumeType = audioType.ToString();
        PlayerPrefs.SetFloat(_saveDataName_Audio + audioVolumeType, saveVolume);
        PlayerPrefs.Save();
    }

    //ハイスコア関係
    public static float GetHighScore(int stageID)//ハイスコアの取得
    {
        string str_stageID=stageID.ToString();
        return PlayerPrefs.GetFloat(_saveDataName_HighScore+str_stageID,defaultHighScore);
    }

    public static void SaveHighScore(int stageID,float saveScore)//ハイスコアのセーブ
    {
        string str_stageID = stageID.ToString();
        PlayerPrefs.SetFloat(_saveDataName_HighScore + str_stageID, saveScore);
        PlayerPrefs.Save();
    }

    //クリアレベル関係
    public static int GetClearLevel()//クリアレベルの取得
    {
        return PlayerPrefs.GetInt(_saveDataName_ClearLevel,defaultClearLevel);
    }

    public static void SaveClearLevel(int saveLevel)//クリアレベルのセーブ
    {
        PlayerPrefs.SetInt(_saveDataName_ClearLevel, saveLevel);
        PlayerPrefs.Save();
    }
}
