using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//インプットシステム学習用メソッド
public class TestInput : MonoBehaviour
{
    bool isPressed=false;

    public void InputNothingContext()
    {
        Debug.Log("何にも設定されていない");
    }
    public void InputNothing(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase+"呼ばれてるよ");
    }

    public void InputMoment(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log(context.phase + "呼ばれてるよ");
        }
    }

    public void InputEveryFrame(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        isPressed = !isPressed;
    }

    void Update()
    {
        if(isPressed) Debug.Log("毎フレーム呼んでます");
    }
}
