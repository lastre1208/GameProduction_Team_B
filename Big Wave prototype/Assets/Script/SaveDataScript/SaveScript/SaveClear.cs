using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//クリア状況(クリアレベル)をセーブする
public class SaveClear : MonoBehaviour
{
    [Header("ステージデータ")]
    [SerializeField] CurrentStageData _currentStageData;
    bool _isFirstClear = false;

    public bool IsFirstClear { get { return _isFirstClear; } }

    void Start()
    {
        UpdateClearLevel();
    }

    void UpdateClearLevel()//クリアレベルの更新
    {
        //現在のクリアレベルをセーブデータから取り出す
        int pastClearLevel=SaveData.GetClearLevel();
        //現在のクリアレベルと遊んだステージのレベルを比較する
        //遊んだステージのレベルの方が高かったらクリアレベルを更新(同時に初クリアということ)
        if(_currentStageData.Level>pastClearLevel)
        {
            _isFirstClear = true;
            SaveData.SaveClearLevel(_currentStageData.Level);
            Debug.Log("初クリアおめでとうございます！現在のクリアレベルは"+ SaveData.GetClearLevel() +"です！");
        }

    }
}
