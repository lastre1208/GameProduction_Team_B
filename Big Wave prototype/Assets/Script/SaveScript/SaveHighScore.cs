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
    const float _defaultHighScore = 0;//初期状態のハイスコア
    bool _updated = false;//ハイスコアを更新したか

    public bool Updated { get { return  _updated; } }

    void Start()
    {
        UpdateHighScore();//ハイスコアの更新処理
    }

    void UpdateHighScore()//ハイスコアの更新処理
    {
        //遊んだステージのハイスコアをセーブデータから取り出す
        string stageNum = _currentStageData.StageID.ToString();
        string highScoreName = "HIGHSCORE_STAGE"+stageNum;
        float pastHighScore=PlayerPrefs.GetFloat(highScoreName,_defaultHighScore);
        //今回のスコアと比較
        //もし今回のスコアの方が高ければハイスコア更新
        if(_score_Total_.Score>pastHighScore)
        {
            _updated = true;
            PlayerPrefs.SetFloat(highScoreName, _score_Total_.Score);  
            PlayerPrefs.Save();
            Debug.Log("ハイスコア更新！現在のハイスコアは"+ PlayerPrefs.GetFloat(highScoreName, _defaultHighScore)+"です！");
        }
    }
}
