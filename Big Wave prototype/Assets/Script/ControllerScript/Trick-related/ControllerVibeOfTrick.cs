using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//トリックの操作時のバイブ
public class ControllerVibeOfTrick : MonoBehaviour
{
    [Header("トリックを決めた時のバイブの速さ")]
    [Range(0, 1)]
    [SerializeField] float vibrationSpeed = 1f;//トリックを決めた時のバイブの速さ
    [Header("トリックを決めた時の振動の時間")]
    [SerializeField] float vibeTime = 0.2f;//トリックを決めた時の振動の時間
    private float remainingVibeTime = 0f;//トリックの振動の残り時間(内部用)
    private Gamepad gamepad = Gamepad.current;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VibrateController();
    }

    void VibrateController()//トリック時コントローラーがバイブする
    {
        remainingVibeTime -= Time.deltaTime;

        if (gamepad != null)
        {
            if (remainingVibeTime > 0)
            {
                gamepad.SetMotorSpeeds(vibrationSpeed, vibrationSpeed);//バイブさせる
            }
            else
            {
                gamepad.SetMotorSpeeds(0f, 0f);//バイブを止める
            }
        }
    }

    public void Vibe()//トリック時にバイブしてほしいときこれを呼ぶ
    {
        remainingVibeTime = vibeTime;
    }
}
