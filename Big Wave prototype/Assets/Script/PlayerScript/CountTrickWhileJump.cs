using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ジャンプ中のトリック回数を数える
public class CountTrickWhileJump : MonoBehaviour
{
    private int trickCount = 0;//一回のジャンプにしたトリックの回数
    [Header("必要なコンポーネント")]
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] Critical critical;
    public int TrickCount
    {
        get { return trickCount; }
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
        if (critical.CriticalNow)
        {
            trickCount++;
        }
        else
        {
            trickCount = 0;
        }
    }
}
