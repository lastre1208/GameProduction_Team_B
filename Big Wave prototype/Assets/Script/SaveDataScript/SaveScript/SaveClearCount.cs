using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//作成者:杉山
//ステージごとのクリア回数のセーブ・更新
public class SaveClearCount : MonoBehaviour
{
    [Header("ステージデータ")]
    [SerializeField] CurrentStageData _currentStageData;
    public event Action Action_BeforeUpdate;//クリア回数の更新の前に呼びたい処理
    public event Action<int> Action_ClearCount_BeforeUpdate;//クリア回数の更新の前に呼びたい処理(更新前のクリア回数を入れる)

    private void Start()
    {
        UpdateClearCount();
    }

    void UpdateClearCount()//クリア回数の更新
    {
        int beforeUpdatedClearCount = SaveData.GetClearCount(_currentStageData.StageID);//更新前のクリア回数

        //イベントを呼び出す
        Action_BeforeUpdate?.Invoke();
        Action_ClearCount_BeforeUpdate?.Invoke(beforeUpdatedClearCount);

        //現在のステージのクリア回数を増やす
        SaveData.AddClearCount(_currentStageData.StageID);
    }
}
