using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIconDisplay : MonoBehaviour
{
    [Header("Aボタンのアイコン")]
    [SerializeField] GameObject icon_AButton;//Aボタンのアイコン
    [Header("Bボタンのアイコン")]
    [SerializeField] GameObject icon_BButton;//Bボタンのアイコン
    [Header("Xボタンのアイコン")]
    [SerializeField] GameObject icon_XButton;//Xボタンのアイコン
    [Header("Yボタンのアイコン")]
    [SerializeField] GameObject icon_YButton;//Yボタンのアイコン

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DisplayButton(Button buttonDisplayed)//ボタン表示、何の(色の)ボタンを表示するかを引数に入れる
    {
        //指定されているボタンを表示
        for (int i = 0; i < Enum.GetNames(typeof(Button)).Length; i++)
        {
            if ((Button)i == buttonDisplayed)
            {
                ButtonIcon((Button)i).SetActive(true);
            }
            else
            {
                ButtonIcon((Button)i).SetActive(false);
            }
        }
    }

    public void HideButton()//ボタンを全て隠す
    {
        //全てのボタンを非表示
        for (int i = 0; i < Enum.GetNames(typeof(Button)).Length; i++)
        {
            ButtonIcon((Button)i).SetActive(false);
        }
    }


    GameObject ButtonIcon(Button button)
    {
        switch (button)
        {
            case Button.A: return icon_AButton;
            case Button.B: return icon_BButton;
            case Button.Y: return icon_YButton;
            case Button.X: return icon_XButton;
        }
        return null;
    }
}
