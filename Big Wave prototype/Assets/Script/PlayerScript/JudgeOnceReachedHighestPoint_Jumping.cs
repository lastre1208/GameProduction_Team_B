using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ジャンプ後一度最高点に到達したかを返す
public class JudgeOnceReachedHighestPoint_Jumping : MonoBehaviour
{
    bool reached=false;//ジャンプ後1回は最高点に到達したか
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        JudgeFirstReachHighestPoint();
    }

    void JudgeFirstReachHighestPoint()
    {
        bool fallNow = (rb.velocity.y < 0);//落ちているか

        if(fallNow)//まだ最高点に到達してないかつ落ちている時に
        {
            reached = true;//ジャンプ後1回は最高点に到達したということにする
        }
    }

    public void StartJump()//ジャンプし始めに呼び出す
    {
        reached=false;//ジャンプ後1回も最高点に到達してないということにする
    }

    public bool Reached
    {
        get { return reached; }
    }

    
}
