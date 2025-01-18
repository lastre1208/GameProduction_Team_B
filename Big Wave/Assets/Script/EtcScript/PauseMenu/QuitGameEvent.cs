using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

//作成者:杉山
//ゲームをリスタートする時に呼ぶ処理
public class QuitGameEvent : MonoBehaviour
{
    [Header("シーン移行コンポーネント")]
    [SerializeField] SceneController _sceneController;
    const float _defaultGameSpeed = 1;//等倍のゲームの速度

    public void Quit()//ゲーム中断時の処理
    {
        Time.timeScale = _defaultGameSpeed;//時間をもとの速度にする
        _sceneController.StageSelectScene();//ステージセレクトシーンに移行
    }
}
