using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//押されたボタンから現在のトリックパターンを割り当てる、現在のトリックパターンの情報(効果音や消費トリックなど)と押されたボタンを返す
public class PushedButton_CurrentTrickPattern : MonoBehaviour
{
    [Header("設定したいトリックパターン")]
    [Tooltip("設定したいトリックパターンはボタンの種類の数の分だけ設定してください")]
    [SerializeField] TrickPattern[] trickPatterns;//設定したいトリックパターン
    TrickPattern currentTrickPattern;//現在のトリックパターン

    public Button PushedButton//押されたボタンを返す
    {
        get { return currentTrickPattern.Button; }
    }

    public int TrickCost//押したボタンに対応するトリックパターンの消費トリックを返す
    {
        get { return currentTrickPattern.TrickCost; }
    }

    public AudioClip SoundEffect//押したボタンに対応するトリックパターンの効果音を返す
    {
        get { return currentTrickPattern.SoundEffect; }
    }

    public float DamageAmount//押したボタンに対応するトリックパターンのダメージ量を返す
    {
        get { return currentTrickPattern.DamageAmount; }
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
