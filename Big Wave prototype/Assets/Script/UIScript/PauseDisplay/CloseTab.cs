using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CloseTab : MonoBehaviour
{
    [SerializeField] EventSystem _eventSystem;

    public void Close()
    {
        GameObject selectButton = _eventSystem.currentSelectedGameObject;//今選択しているボタン(Sliderとかでもいい)を取得

        //今選択してるボタンから親をたどってそのボタンの親のタブを見つける(親のタブにはCloseTabというタグがついている)
        //見つからなかったらここで処理を終了
        Transform closeTab=selectButton.transform.parent;

        while(closeTab!=null)
        {
            if(closeTab.gameObject.tag=="CloseTab")
            {
                break;
            }

            closeTab=closeTab.parent;
        }

        if(closeTab==null)
        {
            return;
        }


        Button[] buttons =closeTab.GetComponentsInChildren<Button>();

        for(int i=0; i<buttons.Length;i++)
        {
            if (buttons[i].tag=="CloseButton")
            {
                buttons[i].onClick.Invoke();
                return;
            }
        }


        //親のタブを取得出来たらその子の中から親のタブを閉じるボタンを探す(そのボタンにはCloseButtonタグがついている)
        //見つからなかったらここで処理を終了
        

        //その閉じるボタンからボタンコンポーネントを取得
        //取得出来なかったらここで処理を終了
        //取得出来たらそのコンポーネントのOnClickを発動
    }
}
