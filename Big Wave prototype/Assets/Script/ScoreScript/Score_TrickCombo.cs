using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_TrickCombo : Score
{
    
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
        Score_TrickCombo = score;
    }
}
