using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//現在プレイしているステージデータ
[CreateAssetMenu(menuName = "ScriptableObjects/StageData/CurrentStageData")]
public class CurrentStageData : ScriptableObject
{
    StageData _currentStageData;//現在のステージデータ

    public int StageID { get { return _currentStageData.StageID; } }//ステージのID
    public int Level { get { return _currentStageData.Level; } }//ステージのレベル
    public string StageSceneName { get { return _currentStageData.StageSceneName; } }//ステージシーン名

    public void Rewrite(StageData stageData)//現在のステージの書き換え
    {
        _currentStageData=stageData;
    }

    public bool NullCheck()//nullチェック(nullの時はfalseを返す)
    {
        return _currentStageData!=null;
    }
}
