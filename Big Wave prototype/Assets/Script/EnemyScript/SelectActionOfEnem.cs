using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class Form//形態
{
    [Header("▼この形態の行動パターン")]
    [SerializeField] ActionPattern[] actionPatterns;//行動とその行動確率とその行動の次に行動を始めるまでの時間
    [Header("▼この形態の突入条件HP")]
    [SerializeField] float formHp;//指定形態突入条件体力(この体力以下の時その形態突入)
    private float actionProbabilitySum = 0;//行動確率(attackProbability)の合計、行動をランダムに決める時に使う

    public ActionPattern[] ActionPatterns
    {
        get { return actionPatterns; }
    }

    public float ActionProbabilitySum
    {
        set { actionProbabilitySum = value; }
        get { return actionProbabilitySum; }
    }

    public float FormHp
    {
        set { formHp = value; }
        get { return formHp; }
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

public class SelectActionOfEnem : MonoBehaviour
{
    [Header("▼敵の形態ごとの行動")]
    [SerializeField] Form[] forms;//形態ごとの行動パターン
    HP enemy_Hp;
    // Start is called before the first frame update
    void Start()
    {
        enemy_Hp = gameObject.GetComponent<HP>();
        //行動確率の合計を算出
        for (int i = 0; i < forms.Length; i++)
        {
            for (int j = 0; j < forms[i].ActionPatterns.Length; j++)
            {
                forms[i].ActionProbabilitySum += forms[i].ActionPatterns[j].ActionProbability;
            }
        }
        //第一形態突入条件HPを最大HPに設定(最初から第一形態なので)
        forms[0].FormHp = enemy_Hp.HpMax;
    }

    public ActionPattern SelectAction()//行動変更
    {
        int formNum = CurrentForm();//現在第何形態か、formsの要素番号値なのでに入れる要素例えば第二形態なら1が入る

        //行動をランダムで決定
        float actionPatternNumber = Random.Range(0, forms[formNum].ActionProbabilitySum);

        //どの行動パターンをするかの決定に使用
        int action = 0;
        float actionProbabilitySum = 0f;

        //どの行動をするか決定するための処理
        for (int i = 0; i < forms[formNum].ActionPatterns.Length; i++)
        {
            //その攻撃パターンの確率を足す
            actionProbabilitySum += forms[formNum].ActionPatterns[i].ActionProbability;

            //ランダムで出した値がactionProbabilitySum未満であれば攻撃決定
            if (actionPatternNumber < actionProbabilitySum)
            {
                break;
            }

            //決まらなければ次の攻撃の判定へ
            action++;
        }

        return forms[formNum].ActionPatterns[action];
    }

    int CurrentForm()//現在が第何形態か(formsの要素番号として入れられるように返すので例えば今が第二形態なら1を返す)を返す
    {
        for (int i = forms.Length - 1; 0 <= i; i--)//指定体力以下でその形態の行動をする(最終形態の条件から順に見ていく)
        {
            if (enemy_Hp.Hp <= forms[i].FormHp)//i+1形態目の条件を確認
            {
                return i;
            }
        }


        return 0;
    }
}
