using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_TrickCombo : Score
{
    [Header("コンボ一回ごとのスコア")]
    [SerializeField] float scorePerOneCombo;//コンボ一回ごとのスコア
    private static float score_TrickCombo = 0;//トリックのコンボのスコア

    public static float ScoreTrickCombo
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

    public void AddScore(int comboCount)//コンボ回数分スコアを加算
    {
        score += scorePerOneCombo * comboCount;
    }

    public override void ReflectScore()//(ゲーム終了時に)トリックコンボボーナスのスコアを反映
    {
        score_TrickCombo = score;
    }
}
