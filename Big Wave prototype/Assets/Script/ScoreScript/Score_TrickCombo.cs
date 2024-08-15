using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_TrickCombo : Score
{
    private static float score_TrickCombo = 0;//トリックのコンボのスコア

    public static float _Score_TrickCombo
    {
        get { return score_TrickCombo; }
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
    public void ReflectScore()//トリックコンボボーナスのスコアを反映
    {
        score_TrickCombo = score;
    }
}
