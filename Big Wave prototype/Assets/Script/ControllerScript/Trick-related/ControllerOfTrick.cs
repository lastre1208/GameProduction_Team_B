using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//トリックの操作
public class ControllerOfTrick : MonoBehaviour
{
    Trick trick;
    PushedButton_CurrentTrickPattern pushedButton_TrickPattern;

    void Start()
    {
        trick = GameObject.FindWithTag("Player").GetComponent<Trick>();
        pushedButton_TrickPattern = GameObject.FindWithTag("Player").GetComponent<PushedButton_CurrentTrickPattern>();
    }

    void Trick_Process(TrickButton button)
    {
        pushedButton_TrickPattern.SetTrickPattern(button);//押されたボタンの種類を設定
        trick.TrickTrigger();//トリック
    }

    public void Trick_Y(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Trick_Process(TrickButton.Y);
    }

    public void Trick_X(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Trick_Process(TrickButton.X);
    }

    public void Trick_B(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Trick_Process(TrickButton.B);
    }

    public void Trick_A(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Trick_Process(TrickButton.A);
    }
}
