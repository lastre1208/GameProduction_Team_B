using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTrickWhileJump : MonoBehaviour
{
    private int trickCount = 0;//一回のジャンプにしたトリックの回数
    JudgeJumpNow judgeJumpNow;

    public int TrickCount
    {
        get { return trickCount; }
    }

    void Start()
    {
        judgeJumpNow=GetComponent<JudgeJumpNow>();
    }

    void Update()
    {
        ResetTrickCount();
    }

    void ResetTrickCount()//トリック回数をリセット(update)
    {
        if (!judgeJumpNow.JumpNow())//着地したら(ジャンプしていないなら)
        {
            trickCount = 0;//1ジャンプ中のトリック回数をリセット
        }
    }

    public void AddTrickCount()//トリック回数の加算(1回ずつ)、トリック時にトリック回数を1回加算するようにする
    {
        trickCount++;
    }
}
