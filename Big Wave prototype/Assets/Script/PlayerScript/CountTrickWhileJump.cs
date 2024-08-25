using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTrickWhileJump : MonoBehaviour
{
    private int trickCount = 0;//一回のジャンプにしたトリックの回数
    JumpControl jumpcontrol;


    public int TrickCount
    {
        get { return trickCount; }
    }

    void Start()
    {
        jumpcontrol = gameObject.GetComponent<JumpControl>();
    }

    void Update()
    {
        ResetTrickCount();
    }

    void ResetTrickCount()//トリック回数をリセット(update)
    {
        if (!jumpcontrol.JumpNow())//着地したら(ジャンプしていないなら)
        {
            trickCount = 0;//1ジャンプ中のトリック回数をリセット
        }
    }

    public void AddTrickCount()//トリック回数の加算(1回ずつ)、トリック時にトリック回数を1回加算するようにする
    {
        trickCount++;
    }
}
