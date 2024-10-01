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

    
    //地面に触れた(着地した)時、ジャンプしていない判定にする、引数のcollisionには触れたオブジェクトの情報をjumpにはfalseを入れる
    //地面から離れた(ジャンプした)時、ジャンプした判定にする、引数のsollisionには触れたオブジェクトの情報をjumpにはtrueを入れる
    void ChangeJumpNowStatus(Collision collison, bool jump)
    {
        if (collison.gameObject.CompareTag("Ground"))//触れているものが地面である
        {
            jumpNow = jump;//現在ジャンプしているかの状態を変える
        }
    }
}
