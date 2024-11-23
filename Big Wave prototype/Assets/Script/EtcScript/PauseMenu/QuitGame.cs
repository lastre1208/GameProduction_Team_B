using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    [Header("ゲーム中断時に呼ぶイベント")]
    [SerializeField] UnityEvent quitEvents;
    [Header("シーン移行コンポーネント")]
    [SerializeField] SceneController _sceneController;

    public void Quit()//ゲーム中断時の処理
    {
        quitEvents.Invoke();
        _sceneController.MenuScene();//メニューシーンに移行
    }
}
