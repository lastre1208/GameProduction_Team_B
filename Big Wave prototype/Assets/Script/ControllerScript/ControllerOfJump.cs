using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//ì¬Ò:™R
//ƒWƒƒƒ“ƒv‚Ì‘€ì
public class ControllerOfJump : MonoBehaviour
{
    Jump jump;
    void Start()
    {
        jump = GameObject.FindWithTag("Player").GetComponent<Jump>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        jump.JumpTrigger();
    }
}
