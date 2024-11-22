using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

//作成者:杉山
//ジャンプの操作
public class ControllerOfJump : MonoBehaviour
{
    public event Action EnterAction;
    public event Action ExitAction;
    bool pushing=false;

    public bool Pushing { get { return pushing; }  }

    public void PrepareJump(InputAction.CallbackContext context)//押し始めに設定
    {
        if (!context.performed) return;

        pushing = true;
        EnterAction?.Invoke();
    }

    public void Jump(InputAction.CallbackContext context)//離した瞬間に設定
    {
        if (!context.performed) return;

        pushing = false;
        ExitAction?.Invoke();
    }
}
