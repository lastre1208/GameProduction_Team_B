using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_HP : Score
{
    [Header("最大HPに対しての残りHPの1%ごとのスコア量")]
    [SerializeField] float scorePerOnePercent;//最大HPに対しての残りHPの1%ごとのスコア量
    private static float score_HP = 0;//残りHPのスコア
    HP player_HP;

    public static float ScoreHP
    {
        get { return score_HP; }
    }

    // Start is called before the first frame update
    void Start()
    {
        player_HP = GameObject.FindWithTag("Player").GetComponent<HP>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override  void ReflectScore(bool gameClear)//残りHPボーナスのスコアを反映
    {
        if(gameClear)//クリア時
        {
            float hpRatio = player_HP.Hp / player_HP.HpMax * 100;//最大HPに対しての残りHPの割りあい(単位は%)
            score =scorePerOnePercent*hpRatio;
        }
        else//ゲームオーバー時
        {
            score = 0;
        }

        score_HP = score;
    }
}
