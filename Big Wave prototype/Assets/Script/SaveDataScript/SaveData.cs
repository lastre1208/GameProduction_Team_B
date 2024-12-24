using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//作成者:杉山
//セーブデータ
//・セーブデータ項目
//各種音量設定(マスターとBGMとSE)
//ステージごとのハイスコア・クリア回数
//クリアレベル
public static class SaveData
{
    const string _saveDataName_Audio = "AUDIOVOLUME";//音量のセーブデータ名
    const string _saveDataName_HighScore = "HIGHSCORE_STAGE";//ハイスコアのセーブデータ名
    const string _saveDataName_ClearCount = "CLEARCOUNT_STAGE";//クリア回数のセーブデータ名
    const string _saveDataName_ClearLevel = "CLEARLEVEL";//クリアレベルのセーブデータ名
    const float _defaultHighScore = 0;//ハイスコアの初期状態
    const int _defaultClearCount = 0;//クリア回数の初期状態
    const int _maxClearCount = 9999;//クリア回数の上限
    const int _defaultClearLevel = 0;//クリアレベルの初期状態


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
        return PlayerPrefs.GetFloat(_saveDataName_HighScore+str_stageID,_defaultHighScore);
    }

    public static void SaveHighScore(int stageID,float saveScore)//ハイスコアのセーブ
    {
        string str_stageID = stageID.ToString();
        PlayerPrefs.SetFloat(_saveDataName_HighScore + str_stageID, saveScore);
        PlayerPrefs.Save();
    }


    //クリア回数関係
    public static int GetClearCount(int stageID)//クリア回数の取得
    {
        string str_stageID = stageID.ToString();
        return PlayerPrefs.GetInt(_saveDataName_ClearCount + str_stageID, _defaultClearCount);
    }

    public static void AddClearCount(int stageID)//クリア回数を一回増やす
    {
        string str_stageID = stageID.ToString();

        //クリア回数を取得して一回増やしてから、セーブ
        int currentClearCount=GetClearCount(stageID);
        currentClearCount++;
        if (currentClearCount > _maxClearCount) currentClearCount = _maxClearCount;//上限を突破しないようにするための処理

        PlayerPrefs.SetInt(_saveDataName_ClearCount + str_stageID, currentClearCount);
        PlayerPrefs.Save();
    }


    //クリアレベル関係
    public static int GetClearLevel()//クリアレベルの取得
    {
        return PlayerPrefs.GetInt(_saveDataName_ClearLevel,_defaultClearLevel);
    }

    public static void SaveClearLevel(int saveLevel)//クリアレベルのセーブ
    {
        PlayerPrefs.SetInt(_saveDataName_ClearLevel, saveLevel);
        PlayerPrefs.Save();
    }
}
