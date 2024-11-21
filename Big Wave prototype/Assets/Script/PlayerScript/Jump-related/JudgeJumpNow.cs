using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//作成者:杉山
//現在ジャンプしているかの判定
public class JudgeJumpNow : MonoBehaviour
{
    [Header("ジャンプし始めの時に呼ぶイベント")]
    [SerializeField] UnityEvent startJumpEvent;
    [Header("着地時に呼ぶイベント")]
    [SerializeField] UnityEvent landEvent;
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

    public void StartJump()//現在のジャンプしている状態にする
    {
        jumpNow = true;
        startJumpEvent.Invoke();
    }

    public void Landing(Collision collision)//着地
    {
        if (collision.gameObject.CompareTag("Ground"))//触れているものが地面である
        {
            jumpNow = false;//現在ジャンプしているかの状態を変える
            landEvent.Invoke();
        }
    }
}
