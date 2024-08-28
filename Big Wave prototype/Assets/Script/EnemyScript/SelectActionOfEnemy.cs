using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//行動パターンを選んで返す

[System.Serializable]
class Form//形態
{
    [Header("▼この形態の行動パターン")]
    [SerializeField] ActionPattern[] actionPatterns;//行動とその行動確率とその行動の次に行動を始めるまでの時間
    private float actionProbabilitySum = 0;//行動確率(attackProbability)の合計、行動をランダムに決める時に使う

    public ActionPattern[] ActionPatterns
    {
        get { return actionPatterns; }
    }

    public float ActionProbabilitySum
    {
        get { return actionProbabilitySum; }
    }

    public void CalculateActionProbabilitySum()//行動確率の合計を求める
    {
        for (int i = 0; i < actionPatterns.Length; i++)
        {
            actionProbabilitySum += actionPatterns[i].ActionProbability;//この形態の全ての行動の行動確率を足す
        }
    }
}

[System.Serializable]

public class ActionPattern//行動とその行動確率とその行動の次に行動を始めるまでの時間
{
    [Header("▼行動")]
    [SerializeField] EnemyActionTypeBase[] action;//行動
    [Header("▼行動確率")]
    [SerializeField] float actionProbability;//行動確率
    [Header("▼行動時間")]
    [SerializeField] float actionTime;//行動時間

    public EnemyActionTypeBase[] Action
    {
        get { return action; }
    }

    public float ActionProbability
    {
        get { return actionProbability; }
    }

    public float ActionTime
    {
        get { return actionTime; }
    }
}

public class SelectActionOfEnemy : MonoBehaviour
{
    [Header("▼敵の形態ごとの行動")]
    [SerializeField] Form[] forms;//形態ごとの行動パターン
    [Header("▼現在の形態を返すコンポーネント")]
    [SerializeField] FormOfEnemyTypeBase formOfEnemy;//現在の形態を返すコンポーネント

    // Start is called before the first frame update
    void Start()
    {
        //全ての形態の行動確率の合計を算出
        for (int i = 0; i < forms.Length; i++)
        {
            forms[i].CalculateActionProbabilitySum();
        }
    }

    public ActionPattern SelectAction()//行動変更
    {
        int formNum = formOfEnemy.CurrentForm();//現在第何形態か、formsの要素番号値なのでに入れる要素例えば第二形態なら1が入る

        //行動をランダムで決定
        float actionPatternNumber = Random.Range(0, forms[formNum].ActionProbabilitySum);

        //どの行動パターンをするかの決定に使用
        int actionNum = 0;
        float actionNumProbabilitySum = 0f;

        //どの行動をするか決定するための処理
        for (int i = 0; i < forms[formNum].ActionPatterns.Length; i++)
        {
            //その攻撃パターンの確率を足す
            actionNumProbabilitySum += forms[formNum].ActionPatterns[i].ActionProbability;

            //ランダムで出した値がactionProbabilitySum未満であれば攻撃決定
            if (actionPatternNumber < actionNumProbabilitySum)
            {
                break;
            }

            //決まらなければ次の攻撃の判定へ
            actionNum++;
        }

        return forms[formNum].ActionPatterns[actionNum];
    }
}
