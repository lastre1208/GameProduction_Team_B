using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIconOnTrickGauge : MonoBehaviour
{
    [Header("ボタンのアイコン")]
    [Tooltip("最初に溜まるゲージの上にあるアイコンを[0]に設定、二番目に溜まるゲージの上にあるアイコンを[1]に設定...してください")]
    [SerializeField] ButtonIconDisplay[] buttonIcon;//ボタンのアイコン
    [SerializeField] TrickPoint trickPoint;
    [SerializeField] Critical critical;

    void Update()
    {
        for(int i=0; i<buttonIcon.Length ;i++)//最初に溜まるゲージから最後に溜まるゲージまで順に見ていく
        {
            bool display = (i < trickPoint.MaxCount);//今見ているゲージの上にあるボタンアイコンを表示するか

            if(display)
            {
                int criticalButtonNum = trickPoint.MaxCount-1-i;//何番目に指定されているボタンを表示するか、要素番号を入れなければならないので例えば2番目に指定されているボタンを表示するなら(2-1)=1を入れる
                TrickButton buttonDisplayed = critical.CriticalButton[criticalButtonNum];//表示するボタン、criticalButtonNum+1番目(要素番号でいえばcriticalButtonNum)に指定されているボタンを設定
                buttonIcon[i].DisplayButton(buttonDisplayed);//ボタンアイコンを表示
            }
            else
            {
                buttonIcon[i].HideButton();//ボタンアイコンを非表示
            }
        }
    }
}
