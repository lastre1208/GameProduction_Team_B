using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//形態ごとにランダムで行動パターンを選ぶ
public class SelectActionOfEnemyTypeFormRandom : SelectActionOfEnemyTypeBase
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

    public override ActionPattern SelectAction()//次にやる行動を返す
    {
        int formNum = formOfEnemy.CurrentForm();//現在第何形態か、formsの要素番号値なのでに入れる要素例えば第二形態なら1が入る

        return forms[formNum].Get();
    }
}
