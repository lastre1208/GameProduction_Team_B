using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Score : MonoBehaviour
{
    protected float score=0;//スコア、シーン遷移する直前に以下のstatic変数のどれかにscoreの値を代入

    private static float score_TrickCount=0;//トリック回数のスコア
    private static float score_CriticalTrickCount=0;//クリティカル回数とクリティカル連続ボーナスのスコア
    private static float score_TrickCombo = 0;//トリックのコンボのスコア
    private static float score_GameClear = 0;//ゲームクリアボーナスのスコア
    private static float score_TimeLimit = 0;//残り時間のスコア
    private static float score_HP = 0;//残りHPのスコア

    public float Score_
    {
        get { return score; }
    }



    public static float Score_TrickCount
    {
        get { return score_TrickCount; }
        protected set { score_TrickCount = value;}
    }

    public static float Score_CriticalTrickCount
    {
        get { return score_CriticalTrickCount; }
        protected set { score_CriticalTrickCount = value;}
    }

    public static float Score_TrickCombo
    {
        get { return score_TrickCombo;}
        protected set { score_TrickCombo = value;}
    }

    public static float Score_GameClear
    {
        get { return score_GameClear; }
        protected set { score_GameClear = value;}
    }

    public static float Score_TimeLimit
    {
        get { return score_TimeLimit; }
        protected set { score_TimeLimit = value;}
    }

    public static float Score_HP
    {
        get { return score_HP; }
        protected set { score_HP = value;}
    }
}
