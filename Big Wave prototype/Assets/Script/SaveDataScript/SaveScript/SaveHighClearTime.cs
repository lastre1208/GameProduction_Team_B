using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ステージごとの最速クリアタイムのセーブ・更新
public class SaveHighClearTime : MonoBehaviour
{
    [Header("初クリアであることを判定するコンポーネント")]//初クリアであることを判定するコンポーネント
    [SerializeField] JudgeFirstClear _judgeFirstClear;
    [Header("ステージデータ")]
    [SerializeField] CurrentStageData _currentStageData;
    [Header("クリアタイムを取得するためのコンポーネント")]
    [SerializeField] Score_TimeLimit _score_timelimit;

    private void Awake()
    {
        _judgeFirstClear.Action_FirstClear += UpdateHighClearTime;
    }

    void UpdateHighClearTime(bool isFirstClear)//最速クリアタイムの更新
    {
        float currentHighClearTime = SaveData.GetHighClearTime(_currentStageData.StageID);//現在の最速クリアタイムを取得
        float thisClearTime = _score_timelimit.ClearTime;//現在のクリアタイムを取得

        bool fasterThis = currentHighClearTime > thisClearTime;//今回の方が早いか

        //最速クリアタイムの更新(初クリアであれば確定で更新、またクリアタイムが今回の方がはやければ更新)
        if (isFirstClear || fasterThis)
        {
            SaveData.SaveHighClearTime(_currentStageData.StageID, thisClearTime);
        }
    }
}
