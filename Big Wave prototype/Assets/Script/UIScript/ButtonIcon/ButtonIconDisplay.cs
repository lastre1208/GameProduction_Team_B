using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIconDisplay : MonoBehaviour
{
    [Header("下ボタンのアイコン")]
    [SerializeField] GameObject icon_SouthButton;//下ボタンのアイコン
    [Header("右ボタンのアイコン")]
    [SerializeField] GameObject icon_EastButton;//右ボタンのアイコン
    [Header("左ボタンのアイコン")]
    [SerializeField] GameObject icon_WestButton;//左ボタンのアイコン
    [Header("上ボタンのアイコン")]
    [SerializeField] GameObject icon_NorthButton;//上ボタンのアイコン

    public void DisplayButton(TrickButton buttonDisplayed)//ボタン表示、何の(色の)ボタンを表示するかを引数に入れる
    {
        //指定されているボタンを表示
        for (int i = 0; i < Enum.GetNames(typeof(TrickButton)).Length; i++)
        {
            if ((TrickButton)i == buttonDisplayed)
            {
                ButtonIcon((TrickButton)i).SetActive(true);
            }
            else
            {
                ButtonIcon((TrickButton)i).SetActive(false);
            }
        }
    }

    public void HideButton()//ボタンを全て隠す
    {
        //全てのボタンを非表示
        for (int i = 0; i < Enum.GetNames(typeof(TrickButton)).Length; i++)
        {
            ButtonIcon((TrickButton)i).SetActive(false);
        }
    }


    GameObject ButtonIcon(TrickButton button)
    {
        switch (button)
        {
            case TrickButton.south: return icon_SouthButton;
            case TrickButton.east: return icon_EastButton;
            case TrickButton.north: return icon_NorthButton;
            case TrickButton.west: return icon_WestButton;
        }
        return null;
    }
}
