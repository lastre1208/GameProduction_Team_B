using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//クリア時にのみセーブするもの
//クリアレベル・ステージごとのクリア回数・最速クリアタイムをセーブ・更新する、初クリアであれば知らせる
public class SaveClear : MonoBehaviour
{
    [Header("ステージデータ")]
    [SerializeField] CurrentStageData _currentStageData;
    [Header("クリアタイムを取得するためのコンポーネント")]
    [SerializeField] Score_TimeLimit_ _score_timelimit;
    const int _judgeFirstClear_ClearCount = 0;//初クリアと判定するクリア回数(0回であれば、初クリアとなる)
    bool _isFirstClear = false;

    public bool IsFirstClear { get { return _isFirstClear; } }

    void Awake()
    {
        JudgeFirstClear();
        UpdateClearLevel();
        UpdateClearCount();
        UpdateHighClearTime();
    }

    void JudgeFirstClear()//初クリアか判定
    {
        //更新前のステージのクリア回数が0回であれば初クリアということ
        int currentClearCount = SaveData.GetClearCount(_currentStageData.StageID);

        _isFirstClear = (currentClearCount == _judgeFirstClear_ClearCount);

        if(_isFirstClear) Debug.Log("初クリアおめでとうございます！");
    }

    void UpdateClearLevel()//クリアレベルの更新
    {
        //現在のクリアレベルをセーブデータから取り出す
        int pastClearLevel=SaveData.GetClearLevel();
        //クリアレベルの更新
        if(_currentStageData.Level>pastClearLevel)
        {
            SaveData.SaveClearLevel(_currentStageData.Level);
        }
    }

    void UpdateClearCount()//クリア回数の更新
    {
        //現在のステージのクリア回数を増やす
        SaveData.AddClearCount(_currentStageData.StageID);
    }

    void UpdateHighClearTime()//最速クリアタイムの更新
    {
        float currentHighClearTime = SaveData.GetHighClearTime(_currentStageData.StageID);//現在の最速クリアタイムを取得
        float thisClearTime = _score_timelimit.ClearTime;//現在のクリアタイムを取得

        bool fasterThis = currentHighClearTime > thisClearTime;//今回の方が早いか

        //最速クリアタイムの更新(初クリアであれば確定で更新、またクリアタイムが今回の方がはやければ更新)
        if(_isFirstClear||fasterThis)
        {
            SaveData.SaveHighClearTime(_currentStageData.StageID, thisClearTime);
        }
    }
}
