using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//インプットシステム学習用メソッド
public class TestInput : MonoBehaviour
{
    bool isPressed=false;
    public void InputNothing()
    {
        Debug.Log("何にも設定されていない");
    }

    public void InputPerform(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Debug.Log("汎用");
    }

    public void InputEveryFrameTrue(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        isPressed = true;
    }

    public void InputEveryFrameFalse(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        isPressed = false;
    }

    void Update()
    {
        if(isPressed) Debug.Log("毎フレーム呼んでます");
    }
}
