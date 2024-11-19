using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//ジャンプの操作
public class ControllerOfJump : MonoBehaviour
{
    Jump jump;
    bool pushing=false;

    public bool Pushing { get { return pushing; }  }

    void Start()
    {
        jump = GameObject.FindWithTag("Player").GetComponent<Jump>();
    }

    public void PrepareJump(InputAction.CallbackContext context)//押し始めに設定
    {
        if (!context.performed) return;

        pushing = true;
    }

    public void Jump(InputAction.CallbackContext context)//離した瞬間に設定
    {
        if (!context.performed) return;

        pushing = false;
        jump.JumpTrigger();
    }
}
