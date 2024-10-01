using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

//作成者:杉山
//ジャンプの処理
public class Jump : MonoBehaviour
{
    [SerializeField] float jumpPower=20f;//ジャンプ力
    Rigidbody rb;
    JudgeTouchWave touchWave;
    JudgeJumpNow judgeJumpNow;
    JudgeOnceReachedHighestPoint_Jumping judgeOnceReachedHighestPoint_Jumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        touchWave = gameObject.GetComponent<JudgeTouchWave>();
        judgeJumpNow= gameObject.GetComponent<JudgeJumpNow>();
        judgeOnceReachedHighestPoint_Jumping=GetComponent<JudgeOnceReachedHighestPoint_Jumping>();
    }

    public void JumpTrigger()//ジャンプ発動
    {
        if (touchWave.TouchWaveNow&&!judgeJumpNow.JumpNow())//波に触れている時かつジャンプしていない時のみジャンプ可能
        {
            judgeJumpNow.StartJump();
            judgeOnceReachedHighestPoint_Jumping.StartJump();
            this.rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);//ジャンプする高さは常に一定
        }
    }
}
