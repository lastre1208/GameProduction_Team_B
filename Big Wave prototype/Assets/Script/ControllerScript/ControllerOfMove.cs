using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerOfMove : MonoBehaviour
{
    MoveLeftAndRight moveLeftAndRight;

    void Start()
    {
        moveLeftAndRight = GameObject.FindWithTag("Player").GetComponent<MoveLeftAndRight>();
    }

    public void GettInputVector(InputAction.CallbackContext context)//コントローラの入力方向を受け取る
    {
        Vector2 getVec = context.ReadValue<Vector2>();//入力方向を受け取る
        moveLeftAndRight.GetMoveVector(getVec);//プレイヤーの移動コンポーネントに入力方向を渡す
    }
}
