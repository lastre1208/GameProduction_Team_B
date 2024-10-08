using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [Header("ゲームリスタート時に呼ぶイベント")]
    [SerializeField] UnityEvent restartEvents;

    public void Restart()//ゲームリスタート時の処理
    {
        restartEvents.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
