using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//作成者:杉山
//簡単にメニュー・サブメニューが閉じれるようにする
//使い方
//メニュー・サブメニューを開く時にOpenNewMenuを呼ぶ(引数には開くメニュー内の閉じるボタンを入れる
//閉じるボタンを押すときにCloseMenu_ButtonOnScreenを呼び出すようにする
//コントローラのボタンからすぐ閉じれるようにするには任意のAction(InputSystemの)にCloseMenu_InputActionを入れる
public class CloseMenuEasily : MonoBehaviour
{
    Stack<Button> _quitButton=new Stack<Button>();

    public void OpenNewMenu(Button quitButton)//新しく開いたメニューの閉じるボタンを登録する、nullを入れればボタンを押さないと閉じれないようにすることが出来る
    {
        _quitButton.Push(quitButton);
    }
    
    public void CloseMenu_InputAction(InputAction.CallbackContext context)//入力(Bボタンなど)の時に呼ぶ
    {
        if (!context.performed) return;
        if (_quitButton.Count == 0) return;//何も入ってないなら無視
        if (_quitButton.Peek() == null) return;//nullが入ってた場合も無視

        //閉じるボタンのクリック動作を呼ぶ
        Button quitButton = _quitButton.Peek();
        quitButton.onClick.Invoke();
    }

    public void CloseMenu_ButtonOnScreen()//画面上のボタンを押すときに呼ぶ
    {
        if (_quitButton.Count == 0) return;//何も入ってないなら無視

        //閉じるボタンを取り出す
        Button quitButton = _quitButton.Pop();
    }
}
