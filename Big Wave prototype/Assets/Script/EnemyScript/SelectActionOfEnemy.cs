using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
//☆塩が書いた

enum ActionType//行動
{
    none,//何もしない
    shotStraight,//止まりながら直線状に撃つ
    shotHoming,//止まりながらホーミングしながら撃つ
    shotHighSlash,//止まりながら高い斬撃を撃つ
    shotWideWave,//止まりながら横に広い周波を撃つ
}

[System.Serializable]
class Form//形態
{
    [Header("▼この形態の行動パターン")]
    [SerializeField] ActionPattern[] actionPatterns;//行動とその行動確率とその行動の次に行動を始めるまでの時間
    [Header("▼この形態の突入条件HP")]
    [SerializeField] float formHp;//指定形態突入条件体力(この体力以下の時その形態突入)
    private float actionProbabilitySum = 0;//攻撃確率(attackProbability)の合計、攻撃をランダムに決める時に使う

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

class ActionPattern//行動とその行動確率とその行動の次に行動を始めるまでの時間
{
    [Header("▼行動")]
    [SerializeField] ActionType action;//行動
    [Header("▼動くか")]
    [SerializeField] bool move;
    [Header("▼行動確率")]
    [SerializeField] float actionProbability;//行動確率
    [Header("▼次に別の行動を始めるまでの時間")]
    [SerializeField] float nextBeginActTime;//次に行動を始めるまでの時間

    public ActionType Action
    {
        get { return action; }
    }

    public bool Move
    {
        get { return move; }
    }

    public float ActionProbability
    {
        get { return actionProbability; }
    }

    public float NextBeginActTime
    {
        get { return nextBeginActTime; }
    }
}

public class SelectActionOfEnemy : MonoBehaviour
{
    [Header("▼敵が最初に行動を始める時間")]
    [SerializeField] float firstBeginActTime = 5f;//敵が次に行動を始める時間(初回)
    [Header("▼敵の形態ごとの行動")]
    [SerializeField] Form[] forms;//形態ごとの行動パターン
    private bool stan = false;//動くことができるか 
    private float beginActTime;//敵が次に行動を始める時間
    private float actTime = 0f;//敵の行動を管理する時間
    //[SerializeField] Quaternion []attackRotation=new Quaternion [4];//横に広い周波の角度

    HP enemy_Hp;
    ActOfEnemy actOfEnemy;

　　public bool Stan
    {
        get { return stan; }
        set { stan = value; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        enemy_Hp = gameObject.GetComponent<HP>();
        actOfEnemy = gameObject.GetComponent<ActOfEnemy>();
        for (int i = 0; i < forms.Length; i++)
        {
            for (int j = 0; j < forms[i].ActionPatterns.Length; j++)
            {
                forms[i].ActionProbabilitySum += forms[i].ActionPatterns[j].ActionProbability;
            }
        }
        forms[0].FormHp = enemy_Hp.HpMax;
        beginActTime = firstBeginActTime;
    }

    // Update is called once per frame
    void Update()
    {
        ActTiming();
    }

    void ActTiming()//敵の攻撃タイミング
    {
        if(stan==false)//スタン状態じゃない時動ける
        {
            actTime += Time.deltaTime;

            if (actTime > beginActTime)
            {
                for (int i = forms.Length - 1; 0 <= i; i--)//指定体力以下でその形態の行動をする(最終形態の条件から順に見ていく)
                {
                    if (enemy_Hp.Hp <= forms[i].FormHp)//i+1形態目の条件を確認
                    {
                        actTime = 0f;
                        SelectAction(i + 1);
                        break;
                    }
                }
            }
        }
    }

    void SelectAction(int a)//攻撃を選択する、aは何形態目か
    {
        //攻撃をランダムで決定
        float attackPatternNumber = Random.Range(0, forms[a-1].ActionProbabilitySum);

        int action = 0;//敵の攻撃パターン、どの攻撃パターンをするか決定するときに使用
        float actionProbabilitySum = 0f;

        //どの攻撃をするか決定するための処理
        //
        //
        for (int i = 0; i < forms[a - 1].ActionPatterns.Length; i++)
        {
            //その攻撃パターンの確率を足す
            actionProbabilitySum += forms[a - 1].ActionPatterns[i].ActionProbability;

            //ランダムで出した値がattackSum未満であれば攻撃決定
            if (attackPatternNumber < actionProbabilitySum)
            {
                break;
            }

            //決まらなければ次の攻撃の判定へ
            action++;
        }
        //Debug.Log(enemy.Forms[a - 1].ActionProbabilitySum + ":::" + attackPatternNumber + ":::" + actionProbabilitySum);

        //行動
        switch (forms[a - 1].ActionPatterns[action].Action)
        {
            case ActionType.none: break;//何もしない
            case ActionType.shotStraight: actOfEnemy.ShotStraight(); break;//直線状に撃つ
            case ActionType.shotHoming: actOfEnemy.ShotHoming(); break;//ホーミングしながら撃つ
            case ActionType.shotHighSlash: actOfEnemy.ShotHighSlash(); break;//高い斬撃を撃つ
            case ActionType.shotWideWave: actOfEnemy.ShotWideWave(); break;//横に広い周波を撃つ
        }

        //動くか(trueなら動くようにする、falseなら止まるようにする)
        if(forms[a - 1].ActionPatterns[action].Move)//動く
        {
            actOfEnemy.Move();
        }
        else//止まる
        {
            actOfEnemy.Stop();
        }

        //beginActTime(敵が次に行動を始める時間)を更新
        beginActTime = forms[a - 1].ActionPatterns[action].NextBeginActTime;

    }
    
}
