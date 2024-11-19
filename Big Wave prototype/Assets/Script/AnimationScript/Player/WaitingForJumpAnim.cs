using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ジャンプ待機モーションの遷移
public class WaitingForJumpAnim : MonoBehaviour
{
    [Header("必要なコンポーネント")]
    [SerializeField] Animator animator;
    [SerializeField] ControllerOfJump controllerOfJump;
    [SerializeField] Jump jump;

    void Update()
    {
        WaitingForJumpBool();
    }

    void WaitingForJumpBool()
    {
        //ジャンプできるかつジャンプのボタンを押してる時のみジャンプ準備モーションをする
        animator.SetBool("WaitingForJump", jump.Jumpable()&&controllerOfJump.Pushing);
    }
}
