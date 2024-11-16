using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//行動パターンを選んで返す

[System.Serializable]
public class ActionPattern//行動とその行動確率とその行動の次に行動を始めるまでの時間
{
    [Header("▼行動")]
    [SerializeField] EnemyActionTypeBase[] action;//行動
    [Header("▼行動時間")]
    [SerializeField] float actionTime;//行動時間

    public EnemyActionTypeBase[] Action
    {
        get { return action; }
    }

    public float ActionTime
    {
        get { return actionTime; }
    }
}

public class SelectActionOfEnemy : MonoBehaviour
{
    [Header("▼敵の形態ごとの行動")]
    [SerializeField] ProbabilityGet<ActionPattern>[] forms;//形態ごとの行動パターン
    [Header("▼現在の形態を返すコンポーネント")]
    [SerializeField] FormOfEnemyTypeBase formOfEnemy;//現在の形態を返すコンポーネント

    void Start()
    {
        //全ての形態の行動確率の合計を算出
        for (int i = 0; i < forms.Length; i++)
        {
            forms[i].Start();
        }
    }

    public ActionPattern SelectAction()//行動変更
    {
        int formNum = formOfEnemy.CurrentForm();//現在第何形態か、formsの要素番号値なのでに入れる要素例えば第二形態なら1が入る

        return forms[formNum].Get();
    }
}
