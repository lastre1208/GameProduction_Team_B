using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//押されたボタンから現在のトリックパターンを割り当てる、現在のトリックパターンの情報(消費トリックやトリックの効果など)と押されたボタンを返す
public class PushedButton_CurrentTrickPattern : MonoBehaviour
{
    [Header("設定したいトリックパターン")]
    [Tooltip("設定したいトリックパターンはボタンの種類の数の分だけ設定してください")]
    [SerializeField] TrickPatternTypeBase[] trickPatterns;//設定したいトリックパターン
    TrickPatternTypeBase currentTrickPattern;//現在のトリックパターン

    public Button PushedButton//押されたボタンを返す
    {
        get { return currentTrickPattern.Button; }
    }

    public int TrickCost//押したボタンに対応するトリックパターンの消費トリックを返す
    {
        get { return currentTrickPattern.TrickCost; }
    }

    public void TrickEffect()//トリックの効果
    {
        currentTrickPattern.TrickEffect();//現在のトリックの効果
    }


    public void SetTrickPattern(Button button)//受け取ったボタンの種類に応じて現在のトリックパターンを設定(割り当てる)
    {
        for(int i=0; i< trickPatterns.Length; i++)
        {
            if (button == trickPatterns[i].Button)//指定したボタンとトリックパターンに設定されているボタンが一致したら
            {
                currentTrickPattern = trickPatterns[i];//現在のトリックパターンをそのトリックパターンに設定する
                return;
            }
        }
    }
}
