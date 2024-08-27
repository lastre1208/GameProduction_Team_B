using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ジャンプの操作
public class ControllerOfJump : MonoBehaviour
{
    Jump jump;
    void Start()
    {
        jump = GameObject.FindWithTag("Player").GetComponent<Jump>();
    }

    void Update()
    {
        //スペースキーかLBボタンかRBボタンでジャンプ
        if (Input.GetKeyUp(KeyCode.JoystickButton5) || Input.GetKeyUp(KeyCode.JoystickButton4) || Input.GetKeyUp("space"))
        {
            jump.JumpTrigger();
        }
    }
}
