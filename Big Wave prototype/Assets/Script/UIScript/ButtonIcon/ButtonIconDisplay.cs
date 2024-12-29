using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIconDisplay : MonoBehaviour
{
    [Header("ボタンのアイコン")]
    [SerializeField] GetTrickButton<GameObject> icon_Button;//ボタンのアイコン

    public void DisplayButton(TrickButton buttonDisplayed)//ボタン表示、何の(色の)ボタンを表示するかを引数に入れる
    {
        //指定されているボタンを表示
        for (int i = 0; i < Enum.GetNames(typeof(TrickButton)).Length; i++)
        {
            if ((TrickButton)i == buttonDisplayed)
            {
                icon_Button.Get((TrickButton)i).SetActive(true);
            }
            else
            {
                icon_Button.Get((TrickButton)i).SetActive(false);
            }
        }
    }

    public void HideButton()//ボタンを全て隠す
    {
        //全てのボタンを非表示
        for (int i = 0; i < Enum.GetNames(typeof(TrickButton)).Length; i++)
        {
            icon_Button.Get((TrickButton)i).SetActive(false);
        }
    }
}
