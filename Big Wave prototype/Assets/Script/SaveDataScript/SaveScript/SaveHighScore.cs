using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ハイスコアをセーブする
public class SaveHighScore : MonoBehaviour
{
    [Header("スコア合計")]
    [SerializeField] Score_Total_ _score_Total_;
    [Header("ステージデータ")]
    [SerializeField] CurrentStageData _currentStageData;
    bool _updated = false;//ハイスコアを更新したか

    public bool Updated { get { return  _updated; } }

    void Awake()
    {
        UpdateHighScore();//ハイスコアの更新処理
    }

    void UpdateHighScore()//ハイスコアの更新処理
    {
        //遊んだステージのハイスコアをセーブデータから取り出す
        float pastHighScore=SaveData.GetHighScore(_currentStageData.StageID);
        //今回のスコアと比較
        //もし今回のスコアの方が高ければハイスコア更新
        if(_score_Total_.Score>pastHighScore)
        {
            _updated = true;
            SaveData.SaveHighScore(_currentStageData.StageID, _score_Total_.Score);
            Debug.Log("ハイスコア更新！現在のハイスコアは"+ SaveData.GetHighScore(_currentStageData.StageID) + "です！");
        }
    }
}
