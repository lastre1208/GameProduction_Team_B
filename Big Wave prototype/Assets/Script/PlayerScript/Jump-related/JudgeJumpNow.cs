using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//現在ジャンプしているかの判定
public class JudgeJumpNow : MonoBehaviour
{
    private bool jumpNow = false;//現在ジャンプしているか

    public bool JumpNow()//現在ジャンプしているかを返す(しているならtrue)
    {
        return jumpNow;
    }

    public void StartJump()//現在のジャンプしている状態にする
    {
        jumpNow = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))//触れているものが地面である
        {
            jumpNow = false;//現在ジャンプしているかの状態を変える
        }
    }
}
