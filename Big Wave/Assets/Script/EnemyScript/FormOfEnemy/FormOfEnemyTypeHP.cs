using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//敵のHPから今が第何形態かを判断
public class FormOfEnemyTypeHP : FormOfEnemyTypeBase
{
    [Header("どの敵のHPを参照するか")]
    [SerializeField] HP enemy_Hp;//敵のHP
    [Header("形態ごとの突入条件HP")]
    [Tooltip("要素番号0が第一形態、要素番号1が第二形態...要素番号nが第n-1形態。この体力以下の時その形態突入する")]
    [SerializeField] float[] formHp;//指定形態突入条件体力(この体力以下の時その形態突入)
    const int _defaultFormNum = 0;//最初の形態番号(0に固定)

    void Start()
    {
        //形態番号0の突入条件HPを最大HPに設定(最初は第一形態からなので)
        formHp[_defaultFormNum] = enemy_Hp.HpMax;
    }

    public override int DefaultForm()//最初の形態はどの形態番号かを返す
    {
        return _defaultFormNum;
    }

    public override int CurrentForm()//現在が第何形態か、例えば今が第二形態なら1を返す
    {
        for (int i = formHp.Length - 1; 0 <= i; i--)//最終形態の条件から順に見ていく
        {
            if (enemy_Hp.Hp <= formHp[i])//現在の体力がその形態の突入条件HP以下ならその形態の番号を返す
            {
                return i;
            }
        }

        //例外
        Debug.Log("例外が起きています！");
        return _defaultFormNum;
    }
}
