using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_TrickCount : Score
{
    [Header("トリック一回ごとのスコア量")]
    [SerializeField] float scorePerOneTrick;//トリック一回ごとのスコア量
   
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void AddScore()//スコア加算(1回トリックをするごとに呼ぶ)
    {
        score += scorePerOneTrick;
    }

    public void ReflectScore()//トリック回数のスコアを反映
    {
        Score_TrickCount=score;
    }
}
