using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

//作成者:杉山
//現在ジャンプしているかの判定
public class JudgeJumpNow : MonoBehaviour
{
    public event Action<bool> SwitchJumpNowAction;//ジャンプ開始直後にtrue、着地直後にfalseを入れてそれぞれ一回だけ呼び出す
    public event Action LandAction;//着地時に呼ぶ
    public event Action StartJumpAction;//ジャンプ開始時に呼ぶ
    [SerializeField] OnCollisionActionEvent onCollisionActionEvent;
    private bool jumpNow = false;//現在ジャンプしているか

    private void Start()
    {
        onCollisionActionEvent.EnterAction += Landing;
    }

    public bool JumpNow()//現在ジャンプしているかを返す(しているならtrue)
    {
        return jumpNow;
    }

    public void StartJump()//ジャンプ開始
    {
        jumpNow = true;
        SwitchJumpNowAction?.Invoke(true);
        StartJumpAction?.Invoke();
    }

    public void Landing(Collision collision)//着地
    {
        if (collision.gameObject.CompareTag("Ground"))//触れているものが地面である
        {
            jumpNow = false;//現在ジャンプしているかの状態を変える
            SwitchJumpNowAction?.Invoke(false);
            LandAction?.Invoke();
        }
    }
}
