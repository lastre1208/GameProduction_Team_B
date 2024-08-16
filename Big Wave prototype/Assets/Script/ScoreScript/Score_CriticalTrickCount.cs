using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_CriticalTrickCount : Score
{
    [Header("1回のクリティカルごとのスコア量")]
    [SerializeField] float scorePerOneCritical;//1回のクリティカルごとのスコア量
    [Header("クリティカル連続ボーナスの増え幅")]
    [Tooltip("1回目は連続ボーナスなしですが、連続二回目のクリティカルからは1回のクリティカルごとのスコア量がこの値ずつ増えていきます")]
    [SerializeField] float plusContinueBonus;//クリティカル連続ボーナスの増え幅、1回目は連続ボーナスなしですが、連続二回目のクリティカルからは1回のクリティカルごとのスコア量がこの値ずつ増えていきます
    [Header("1回のクリティカルごとのスコア量の最大値")]
    [Tooltip("連続ボーナスで1回のクリティカルごとのスコア量が増えていきますがこの値以上は増えません")]
    [SerializeField] float scorePerOneCriticalMax;//1回のクリティカルごとのスコア量の最大値、連続ボーナスで1回のクリティカルごとのスコア量が増えていきますがこの値以上は増えません
    private static float score_CriticalTrickCount = 0;//クリティカル回数とクリティカル連続ボーナスのスコア
    private float currentScorePerOneCritical;//現在の1回のクリティカルごとのスコア量

    public static float ScoreCriticalTrickCount
    {
        get { return score_CriticalTrickCount; }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        currentScorePerOneCritical = scorePerOneCritical;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScoreWhenCritical(bool critical)//クリティカル時にスコアの加算をする、引数にはクリティカルだった場合はtrue、そうじゃなかったら(普通の攻撃だったら)falseを入れる
    {
        //クリティカルを連続でするほど(クリティカル二度目から)スコア上昇量が増えていく

        if(critical)//クリティカルだった
        {
            score += currentScorePerOneCritical;//スコア加算
            currentScorePerOneCritical += plusContinueBonus;//現在の1回のクリティカルごとのスコア量が上がる
            currentScorePerOneCritical = Mathf.Clamp(currentScorePerOneCritical, 0, scorePerOneCriticalMax);//スコア上昇量の制限、スコア上昇量がscorePerOneCriticalMaxより大きくならないようにする
        }
        else//クリティカルではなかった
        {
            currentScorePerOneCritical = scorePerOneCritical;//スコアの上昇量をもとに戻す
        }
    }

    public override void ReflectScore()//トリックボタン指定成功ボーナスのスコアを反映
    {
        score_CriticalTrickCount = score;
    }
}
