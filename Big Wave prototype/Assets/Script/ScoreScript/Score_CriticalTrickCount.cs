using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_CriticalTrickCount : Score
{
    private static float score_CriticalTrickCount = 0;//クリティカル回数とクリティカル連続ボーナスのスコア

    public static float _Score_CriticalTrickCount
    {
        get { return score_CriticalTrickCount; }
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

    public void ReflectScore()//トリックボタン指定成功ボーナスのスコアを反映
    {
        score_CriticalTrickCount = score;
    }
}
