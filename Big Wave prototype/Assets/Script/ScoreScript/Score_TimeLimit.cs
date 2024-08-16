using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_TimeLimit : Score
{
    [Header("残り時間(1秒)ごとのスコア量")]
    [SerializeField] float scorePerSecond;//残り時間(1秒)ごとのスコア量
    private static float score_TimeLimit = 0;//残り時間のスコア

    public static float ScoreTimeLimit
    {
        get { return score_TimeLimit; }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ReflectScore(bool gameClear)//制限時間ボーナスのスコアを反映
    {
        if (gameClear)//クリア時
        {
            score = scorePerSecond * TimeLimit.RemainingTime;
        }
        else//ゲームオーバー時
        {
            score = 0;
        }

        score_TimeLimit = score;
    }
}
