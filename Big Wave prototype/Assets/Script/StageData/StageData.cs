using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//
[System.Serializable]
public class StageData
{
    [Header("ステージID(一意にしてください)")]
    [SerializeField] int _stageID;//ステージのID
    [Header("レベル")]
    [SerializeField] int _level;//ステージのレベル
    [Header("ステージシーン名")]
    [SerializeField] string _stageSceneName;//ステージシーン名

    public int StageID { get { return _stageID; } }//ステージのID
    public int Level { get { return _level; } }//ステージのレベル
    public string StageSceneName { get { return _stageSceneName; } }//ステージシーン名

    public StageData()//コンストラクタ
    {

    }

    public StageData(int stageID,int level,string stageSceneName)//デフォルトコンストラクタ
    {
        _stageID = stageID;
        _level = level;
        _stageSceneName = stageSceneName;
    }
}
