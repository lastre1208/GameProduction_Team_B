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

    void Update()
    {
        ChargeStandbyOn();
    }

    void ChargeStandbyOn()//波に触れてトリックがチャージできるようにする
    {
        //スペースキーやボタンを押している間は波に触れてチャージができるようになる
        if (Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space"))
        {
            chargeTrickPoint.ChargeStandby = true;
        }
        //押していない間は波に触れてもチャージされない
        else
        {
            chargeTrickPoint.ChargeStandby = false;
        }
    }

    
}
