using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_TimeLimit : Score
{
    [Header("残り時間(1秒)ごとのスコア量")]
    [SerializeField] float score_TimeLimit;//残り時間(1秒)ごとのスコア量
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReflectScore(bool gameClear)//制限時間ボーナスのスコアを反映
    {
        if (gameClear)//クリア時
        {
            score = score_TimeLimit * TimeLimit.RemainingTime;
        }
        else//ゲームオーバー時
        {
            score = 0;
        }

        Score_TimeLimit = score;
    }
}
