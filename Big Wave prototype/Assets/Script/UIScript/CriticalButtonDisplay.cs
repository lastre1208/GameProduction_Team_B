using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalButtonDisplay : MonoBehaviour
{
    [Header("Aボタンのアイコン")]
    [SerializeField] GameObject icon_AButton;//Aボタンのアイコン
    [Header("Bボタンのアイコン")]
    [SerializeField] GameObject icon_BButton;//Bボタンのアイコン
    [Header("Xボタンのアイコン")]
    [SerializeField] GameObject icon_XButton;//Xボタンのアイコン
    [Header("Yボタンのアイコン")]
    [SerializeField] GameObject icon_YButton;//Yボタンのアイコン
    private int criticalButtonNum;//表示するボタンの要素番号、このクラスを使う時はまず最初にこれに値を代入する
    Critical critical;
    

     public int CriticalButtonNum
    {
        get { return criticalButtonNum; }
        set { criticalButtonNum = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        critical = GameObject.FindWithTag("Player").GetComponent<Critical>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DisplayButton()//ボタン表示
    {
        Button DisplayCriricalButton = critical.CriticalButton[criticalButtonNum];//表示するボタン

        //指定されているボタンを表示
        for (int i = 0; i < Enum.GetNames(typeof(Button)).Length; i++)
        {
            if ((Button)i == DisplayCriricalButton)
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
