using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushedButton_TrickPattern : MonoBehaviour
{
    [Header("設定したいトリックパターン")]
    [Tooltip("設定したいトリックパターンはボタンの種類の数の分だけ設定してください")]
    [SerializeField] TrickPattern[] trickPatterns;//設定したいトリックパターン
    TrickPattern currentTrickPattern;//現在のトリックパターン

    public TrickPattern CurrentTrickPattern
    {
        get { return currentTrickPattern; }
    }

    public void SetTrickPattern(Button button)//受け取ったボタンの種類に応じて現在のトリックパターンを設定
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
