using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_GameClear : Score
{
    [Header("ゲームクリア時のスコア量")]
    [SerializeField] float score_GameClearBonus;//ゲームクリア時のスコア量
    private static float score_GameClear = 0;//ゲームクリアボーナスのスコア

    public static float _Score_GameClear
    {
        get { return score_GameClear; }
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

    public void ReflectScore(bool gameClear)//クリア時にゲームクリアボーナスのスコアを反映
    {
        if(gameClear)//クリア時
        {
            score += score_GameClearBonus;
        }
        else//ゲームオーバー時
        {
            score = 0;
        }

        score_GameClear = score;
    }
}
