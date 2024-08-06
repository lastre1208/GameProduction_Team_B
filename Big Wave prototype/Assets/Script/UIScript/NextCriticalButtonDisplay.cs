using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCriticalButtonDisplay : MonoBehaviour
{
    [Header("Aボタンのアイコン")]
    [SerializeField] GameObject icon_AButton;//Aボタンのアイコン
    [Header("Bボタンのアイコン")]
    [SerializeField] GameObject icon_BButton;//Bボタンのアイコン
    [Header("Xボタンのアイコン")]
    [SerializeField] GameObject icon_XButton;//Xボタンのアイコン
    [Header("Yボタンのアイコン")]
    [SerializeField] GameObject icon_YButton;//Yボタンのアイコン
    Critical critical;
    JumpControl jumpControl;
    TRICKPoint player_TrickPoint;
    // Start is called before the first frame update
    void Start()
    {
        critical = GameObject.FindWithTag("Player").GetComponent<Critical>();
        jumpControl = GameObject.FindWithTag("Player").GetComponent<JumpControl>();
        player_TrickPoint = GameObject.FindWithTag("Player").GetComponent<TRICKPoint>();
        //全てのボタンを非表示
        for (int i = 0; i < Enum.GetNames(typeof(Button)).Length; i++)
        {
            ButtonIcon((Button)i).SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DisplayButton();
    }

    void DisplayButton()//ボタン表示
    {
        //ジャンプしている時かつ満タンのトリックゲージの数が1本以上あるとき
        if (jumpControl.JumpNow && player_TrickPoint.MaxCount > 0)
        {
            Button nextCriricalButton = critical.CriticalButton[1];//次の指定されているボタン
            //指定されているボタンを表示
            for (int i = 0; i < Enum.GetNames(typeof(Button)).Length; i++)
            {
                if ((Button)i == nextCriricalButton)
                {
                    ButtonIcon((Button)i).SetActive(true);
                }
                else
                {
                    ButtonIcon((Button)i).SetActive(false);
                }
            }
        }
        else
        {
            //全てのボタンを非表示
            for (int i = 0; i < Enum.GetNames(typeof(Button)).Length; i++)
            {
                ButtonIcon((Button)i).SetActive(false);
            }
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
