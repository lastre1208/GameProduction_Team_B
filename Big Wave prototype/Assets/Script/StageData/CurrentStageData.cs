using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//現在プレイしているステージデータ
public class CurrentStageData : MonoBehaviour
{
    [Header("ステージデータリスト")]
    [SerializeField] StageDataList _stageDataList;
    const string _stageID_Name = "STAGE_ID";//ステージIDを保存しているデータ名

    public int StageID
    {
        get { return PlayerPrefs.GetInt(_stageID_Name); }
    }

    public int Level
    {
        get { return _stageDataList.GetLevel(StageID); }
    }

    public string StageSceneName
    {
        get { return _stageDataList.GetStageSceneName(StageID); }
    }

    public void Rewrite(int dataID)//現在プレイ中のステージデータのIDの書き換え
    {
        PlayerPrefs.SetInt(_stageID_Name,dataID);//ステージIDの保存
        PlayerPrefs.Save();
    }
}
