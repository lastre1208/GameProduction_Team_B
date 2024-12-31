using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

//作成者:杉山
//ジャンプの処理
public class Jump : MonoBehaviour
{
    [Header("ジャンプ力")]
    [SerializeField] JumpPower jumpPower;
    [Header("ジャンプ関係のコントローラ操作")]
    [SerializeField] ControllerOfJump controllerOfJump;//ジャンプ関係のコントローラ操作
    [Header("必要なコンポーネント")]
    [SerializeField] Rigidbody rb;
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] JudgeOnceReachedHighestPoint_Jumping judgeOnceReachedHighestPoint_Jumping;
    [SerializeField] JudgeJumpable judgeJumpable;

    void Start()
    {
        controllerOfJump.ExitAction += JumpTrigger;
       
    }

    void JumpTrigger()//ジャンプ発動
    {
        if (judgeJumpable.Jumpable)//ジャンプできるか判定
        {
            //ジャンプする
            judgeJumpNow.StartJump();
            judgeOnceReachedHighestPoint_Jumping.StartJump();
            rb.AddForce(transform.up * jumpPower.Power, ForceMode.Impulse);
        }

        //ジャンプに成功しても失敗してもジャンプ力はリセットさせる
        jumpPower.ResetJumpPower();
    }
    
}
