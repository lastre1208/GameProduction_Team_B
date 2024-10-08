using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//トリックポイントのチャージの操作時のバイブ
public class ControllerVibeOfChargeTrickPoint : MonoBehaviour
{
    [Header("トリックをチャージしている時のバイブの速さ")]
    [Range(0, 1)]
    [SerializeField] float vibrationSpeed = 1f;//トリックをチャージしている時のバイブの速さ
    JudgeChargeTrickPointNow judgeChargeTrickPointNow;
    JudgePauseNow judgePauseNow;
    private Gamepad gamepad = Gamepad.current;

    // Start is called before the first frame update
    void Start()
    {
        judgeChargeTrickPointNow = GameObject.FindWithTag("Player").GetComponent<JudgeChargeTrickPointNow>();
        judgePauseNow = GameObject.FindWithTag("PauseManager").GetComponent<JudgePauseNow>();
    }

    // Update is called once per frame
    void Update()
    {
        VibrateController();
    }

    void VibrateController()//チャージしている間コントローラが振動
    {
        if (gamepad != null)
        {
            if (judgeChargeTrickPointNow.ChargeNow()&&!judgePauseNow.PauseNow)//チャージ時かつポーズしていない時
            {
                gamepad.SetMotorSpeeds(vibrationSpeed, vibrationSpeed);//バイブさせる
            }
            else//チャージしていない時
            {
                gamepad.SetMotorSpeeds(0f, 0f);//バイブを止める
            }
        }
    }
}
