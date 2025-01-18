using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//音量設定のセーブデータ(マスターとBGMとSE)
public static partial class SaveData
{
    //音量関係
    const string _saveDataName_Audio = "AUDIOVOLUME";//音量のセーブデータ名

    public static float GetAudioVolume(AudioType audioType, float noSaveVal)//音量の取得
    {
        string audioVolumeType = audioType.ToString();
        return PlayerPrefs.GetFloat(_saveDataName_Audio + audioVolumeType, noSaveVal);
    }

    public static void SaveAudioVolume(AudioType audioType, float saveVolume)//音量のセーブ
    {
        string audioVolumeType = audioType.ToString();
        PlayerPrefs.SetFloat(_saveDataName_Audio + audioVolumeType, saveVolume);
        PlayerPrefs.Save();
    }
}
