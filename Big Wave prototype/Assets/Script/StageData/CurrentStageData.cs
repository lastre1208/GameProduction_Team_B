using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//現在プレイしているステージデータ
public class CurrentStageData : MonoBehaviour
{
    const string _stageID_Name = "STAGE_ID";//ステージIDを保存しているデータ名
    const string _level_Name = "STAGE_LEVEL";//レベルを保存しているデータ名
    const string _stageSceneName_Name = "STAGE_SCENENAME";//ステージシーン名を保存しているデータ名

    public int StageID
    {
        get { return PlayerPrefs.GetInt(_stageID_Name); }
    }

    public int Level
    {
        get { return PlayerPrefs.GetInt(_level_Name); }
    }

    public string StageSceneName
    {
        get { return PlayerPrefs.GetString(_stageSceneName_Name); }
    }

    public void Rewrite(StageData stageData)//書き換え
    {
        PlayerPrefs.SetInt(_stageID_Name,stageData.StageID);//ステージIDの保存
        PlayerPrefs.SetInt(_level_Name,stageData.Level);//レベルの保存
        PlayerPrefs.SetString(_stageSceneName_Name,stageData.StageSceneName);//ステージシーン名の保存
        PlayerPrefs.Save();
    }
}
