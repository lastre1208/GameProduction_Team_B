using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[System.Serializable]
class ScoreTypeDisplay
{
    [Header("表示するスコアの種類")]
    [SerializeField] ScoreType scoreType;//表示するスコアの種類
    [Header("表示させるテキスト")]
    [SerializeField] TMP_Text score_UI;//表示させるテキスト
    private float scoreValue=0;//表示するスコアの値

    enum ScoreType//表示するスコアの種類
    {
        trickCount,//トリック回数スコア
        criticalTrickCount,//クリティカルトリックボーナス
        trickCombo,//トリックコンボボーナス
        gameClear,//ゲームクリアボーナス
        timeLimit,//残り時間ボーナス
        hp,//残りHPボーナス
        total//スコア合計、これをenum型の最後に置く
    }

    internal void ScoreValueSet()//表示するスコアの値を設定
    {
        //表示するスコアの種類によって表示するスコアの値を設定
        //スコア合計の場合scoreValue(表示するスコアの値)に全ての種類のスコアを加算する
       for(int i=0; i< Enum.GetValues(typeof(ScoreType)).Length-1; i++)
       {
            if(scoreType==(ScoreType)i||scoreType==ScoreType.total)
            {
                scoreValue += ScoreTypeValue((ScoreType)i);//指定のスコアの種類のスコア量を加算

                if(scoreType != ScoreType.total)//スコア合計ではないならここで処理は終わり、スコア合計なら全ての種類のスコアを足すために処理が最後まで続く
                {
                    break;
                }
            }
       }
    }

    float ScoreTypeValue(ScoreType type)//スコアの種類を指定することでそれぞれのスコアが返ってくる
    {
        switch(type)
        {
            case ScoreType.trickCount: return Score_TrickCount.ScoreTrickCount;//トリック回数ボーナスのスコアを返す
            case ScoreType.criticalTrickCount: return Score_CriticalTrickCount.ScoreCriticalTrickCount;//クリティカルトリックボーナスのスコアを返す
            case ScoreType.trickCombo: return Score_TrickCombo.ScoreTrickCombo;//トリックコンボボーナスのスコアを返す
            case ScoreType.gameClear: return Score_GameClear.ScoreGameClear;//ゲームクリアボーナスのスコアを返す
            case ScoreType.timeLimit: return Score_TimeLimit.ScoreTimeLimit;//残り時間ボーナスのスコアを返す
            case ScoreType.hp: return Score_HP.ScoreHP;//残りHPボーナスのスコアを返す
        }
        return 0;
    }

    internal void Display()//スコアの表示
    {
        score_UI.text = scoreValue.ToString("0");
    }
}

public class ResultDisplay : MonoBehaviour
{

    [SerializeField] ScoreTypeDisplay[] scoreTypeDisplays;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<scoreTypeDisplays.Length ;i++)
        {
            scoreTypeDisplays[i].ScoreValueSet();
            scoreTypeDisplays[i].Display();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
