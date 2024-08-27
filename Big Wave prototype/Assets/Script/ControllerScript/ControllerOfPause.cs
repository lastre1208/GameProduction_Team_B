using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ポーズ(画面)の操作
public class ControllerOfPause : MonoBehaviour
{
    [Header("ポーズ画面")]
    [SerializeField] PauseControl pauseControl;//ポーズ画面

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Pause")) // Pキーが押されたら
        {
            pauseControl.TogglePause(); // ポーズの切り替え
        }
    }
}
