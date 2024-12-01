using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//クリア状況(クリアレベル)をセーブする
public class SaveClear : MonoBehaviour
{
    [Header("ステージデータ")]
    [SerializeField] CurrentStageData _currentStageData;
    const int _defaultClearLevel = 0;//初期状態のクリアレベルは0
    bool _isFirstClear = false;

    public bool IsFirstClear { get { return _isFirstClear; } }

    void Start()
    {
        UpdateClearLevel();
    }

    void UpdateClearLevel()//クリアレベルの更新
    {
        //現在のクリアレベルをセーブデータから取り出す
        string clearLevelName = "CLEARLEVEL";
        int pastClearLevel=PlayerPrefs.GetInt(clearLevelName,_defaultClearLevel);
        //現在のクリアレベルと遊んだステージのレベルを比較する
        //遊んだステージのレベルの方が高かったらクリアレベルを更新(同時に初クリアということ)
        if(_currentStageData.Level>pastClearLevel)
        {
            _isFirstClear = true;
            PlayerPrefs.SetInt(clearLevelName,_currentStageData.Level);
            PlayerPrefs.Save();
            Debug.Log("初クリアおめでとうございます！現在のクリアレベルは"+ PlayerPrefs.GetInt(clearLevelName, _defaultClearLevel)+"です！");
        }

    }
}
