using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_HP : Score
{
    [Header("最大HPに対しての残りHPの1%ごとのスコア量")]
    [SerializeField] float score_HP;//最大HPに対しての残りHPの1%ごとのスコア量
    HP player_HP;

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
    public void ReflectScore(bool gameClear)//残りHPボーナスのスコアを反映
    {
        if(gameClear)//クリア時
        {
            float hpRatio = player_HP.Hp / player_HP.HpMax * 100;//最大HPに対しての残りHPの割りあい(単位は%)
            score =score_HP*hpRatio;
        }
        else//ゲームオーバー時
        {
            score = 0;
        }

        Score_HP = score;
    }
}
