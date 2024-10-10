using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

//作成者:杉山
//ジャンプの処理
public class Jump : MonoBehaviour
{
    [Header("ジャンプ力")]
    [SerializeField] float jumpPower=20f;//ジャンプ力
    [Header("必要なコンポーネント")]
    [SerializeField] Rigidbody rb;
    [SerializeField] JudgeTouchWave touchWave;
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] JudgeOnceReachedHighestPoint_Jumping judgeOnceReachedHighestPoint_Jumping;

    public void JumpTrigger()//ジャンプ発動
    {
        if (touchWave.TouchWaveNow&&!judgeJumpNow.JumpNow())//波に触れている時かつジャンプしていない時のみジャンプ可能
        {
            judgeJumpNow.StartJump();
            judgeOnceReachedHighestPoint_Jumping.StartJump();
            rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);//ジャンプする高さは常に一定
        }
    }
}
