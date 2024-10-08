using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ジャンプの操作
public class ControllerOfJump : MonoBehaviour
{
    Jump jump;
    JudgePauseNow judgePauseNow;
    void Start()
    {
        jump = GameObject.FindWithTag("Player").GetComponent<Jump>();
        judgePauseNow = GameObject.FindWithTag("PauseManager").GetComponent<JudgePauseNow>();
    }

    void Update()
    {
        if (judgePauseNow.PauseNow) return;//ポーズ中はジャンプできない

        //スペースキーかLBボタンかRBボタンでジャンプ
        if (Input.GetKeyUp(KeyCode.JoystickButton5) || Input.GetKeyUp(KeyCode.JoystickButton4) || Input.GetKeyUp("space"))
        {
            jump.JumpTrigger();
        }
    }
}
