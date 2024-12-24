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
    bool _isFirstClear = false;

    public bool IsFirstClear { get { return _isFirstClear; } }

    void Awake()
    {
        UpdateClearLevel();
        UpdateClearCount();
    }

    void UpdateClearLevel()//クリアレベルの更新
    {
        //現在のクリアレベルをセーブデータから取り出す
        int pastClearLevel=SaveData.GetClearLevel();
        //現在のクリアレベルと遊んだステージのレベルを比較する
        //遊んだステージのレベルの方が高かったらクリアレベルを更新
        if(_currentStageData.Level>pastClearLevel)
        {
            _isFirstClear = true;
            SaveData.SaveClearLevel(_currentStageData.Level);
            Debug.Log("初クリアおめでとうございます！現在のクリアレベルは"+ SaveData.GetClearLevel() +"です！");
        }
    }

    void UpdateClearCount()//クリア回数の更新
    {
        //現在のステージのクリア回数を増やす
        SaveData.AddClearCount(_currentStageData.StageID);
    }
}
