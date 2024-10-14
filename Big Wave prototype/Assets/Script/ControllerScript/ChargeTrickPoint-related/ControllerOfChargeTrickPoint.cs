using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//トリックポイントのチャージの操作
public class ControllerOfChargeTrickPoint : MonoBehaviour
{
    ChargeTrickPoint chargeTrickPoint;
    JudgePauseNow judgePauseNow;

    void Start()
    {
        chargeTrickPoint = GameObject.FindWithTag("Player").GetComponent<ChargeTrickPoint>();
        judgePauseNow=GameObject.FindWithTag("PauseManager").GetComponent<JudgePauseNow>();
    }

    void Update()
    {
        //ChargeStandbyOn();
    }

    //void ChargeStandbyOn()//波に触れてトリックがチャージできるようにする
    //{
    //    if (judgePauseNow.PauseNow) return;//ポーズ中はチャージできない

    //    //スペースキーやボタンを押している間は波に触れてチャージができるようになる
    //    if (Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space"))
    //    {
    //        chargeTrickPoint.ChargeStandby = true;
    //    }
    //    //押していない間は波に触れてもチャージされない
    //    else
    //    {
    //        chargeTrickPoint.ChargeStandby = false;
    //    }
    //}

    public void ChargeStandby_On(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        chargeTrickPoint.ChargeStandby = true;
    }

    public void ChargeStandby_Off(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        chargeTrickPoint.ChargeStandby = false;
    }
}
