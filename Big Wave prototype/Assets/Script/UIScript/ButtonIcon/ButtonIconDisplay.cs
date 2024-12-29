using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ボタンアイコンの表示の切り替え
public class ButtonIconDisplay : MonoBehaviour
{
    [Header("ボタンのアイコン")]
    [SerializeField] GetTrickButton<GameObject> icon_Button;//ボタンのアイコン

    public void DisplayButton(TrickButton buttonDisplayed)//ボタン表示、何の(色の)ボタンを表示するかを引数に入れる
    {
        //指定されているボタンを表示
        for (int i = 0; i < Enum.GetNames(typeof(TrickButton)).Length; i++)
        {
            bool display = (TrickButton)i == buttonDisplayed;//ボタンを表示するか

            GameObject icon = icon_Button.Get((TrickButton)i);//表示の切り替えをするボタンのアイコン

            icon.SetActive(display);
        }
    }

    public void HideButton()//ボタンを全て隠す
    {
        //全てのボタンを非表示
        for (int i = 0; i < Enum.GetNames(typeof(TrickButton)).Length; i++)
        {
            GameObject icon = icon_Button.Get((TrickButton)i);//表示の切り替えをするボタンのアイコン

            icon.SetActive(false);
        }
    }
}
