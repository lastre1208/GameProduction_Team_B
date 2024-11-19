using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//コントローラをバイブさせる
public class StopVibeWhenGameSet : MonoBehaviour
{
    [Header("ゲーム終了を判断するコンポーネント")]
    [SerializeField] JudgeGameSet judgeGameSet;//ゲーム終了を判断するコンポーネント
    const float stopSpeed = 0;
    private Gamepad gamepad = Gamepad.current;

    private void Start()
    {
        judgeGameSet.GameSetCommonAction += StopVibe;
    }

    public void StopVibe()
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(stopSpeed, stopSpeed);
        }
    }
}
