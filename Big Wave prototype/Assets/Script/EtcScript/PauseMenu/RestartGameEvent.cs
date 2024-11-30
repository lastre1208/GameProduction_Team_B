using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

//作成者:杉山
//ゲームをリスタートする時に呼ぶ処理
public class RestartGameEvent : MonoBehaviour
{
    const float _defaultGameSpeed = 1;//等倍のゲームの速度
    public void Restart()//ゲームリスタート時の処理
    {
        Time.timeScale = _defaultGameSpeed;//時間をもとの速度にする
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//今のシーンを初期の状態にする
    }
}
