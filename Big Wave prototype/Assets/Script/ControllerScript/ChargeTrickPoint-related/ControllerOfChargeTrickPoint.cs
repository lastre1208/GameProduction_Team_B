using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//トリックポイントのチャージの操作
public class ControllerOfChargeTrickPoint : MonoBehaviour
{
    ChargeTrickPoint chargeTrickPoint;

    void Start()
    {
        chargeTrickPoint = GameObject.FindWithTag("Player").GetComponent<ChargeTrickPoint>();
    }

    //public void ChargeStandby_On(InputAction.CallbackContext context)
    //{
    //    if (!context.performed) return;

    //    chargeTrickPoint.ChargeStandby = true;
    //}

    //public void ChargeStandby_Off(InputAction.CallbackContext context)
    //{
    //    if (!context.performed) return;

    //    chargeTrickPoint.ChargeStandby = false;
    //}
}
