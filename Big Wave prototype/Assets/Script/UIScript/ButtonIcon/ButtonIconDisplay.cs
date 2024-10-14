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
            case TrickButton.A: return icon_AButton;
            case TrickButton.B: return icon_BButton;
            case TrickButton.Y: return icon_YButton;
            case TrickButton.X: return icon_XButton;
        }
        return null;
    }
}
