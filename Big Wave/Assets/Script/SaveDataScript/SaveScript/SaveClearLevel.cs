using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//クリアレベルのセーブ・更新
public class SaveClearLevel : MonoBehaviour
{
    [Header("ステージデータ")]
    [SerializeField] CurrentStageData _currentStageData;

    private void Start()
    {
        UpdateClearLevel();
    }

    void UpdateClearLevel()//クリアレベルの更新
    {
        //現在のクリアレベルをセーブデータから取り出す
        int pastClearLevel = SaveData.GetClearLevel();
        //クリアレベルの更新
        if (_currentStageData.Level > pastClearLevel)
        {
            SaveData.SaveClearLevel(_currentStageData.Level);
        }
    }
}
