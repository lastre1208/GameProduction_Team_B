using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ポーズ(画面)の操作
public class ControllerOfPause : MonoBehaviour
{
    JudgePauseNow judgePauseNow;

    private void Start()
    {
        judgePauseNow = GameObject.FindWithTag("PauseManager").GetComponent<JudgePauseNow>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Pause")) // Pキーが押されたら
        {
            judgePauseNow.SwitchPause();// ポーズの切り替え
        }
    }
}
