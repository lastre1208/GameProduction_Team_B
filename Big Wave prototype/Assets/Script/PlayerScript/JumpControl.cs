using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    //☆塩が書いた
    [SerializeField] float jumpPower=20f;//ジャンプ力
    [SerializeField] JudgeJumpNow judgeJumpNow;//現在ジャンプしているかを判定する
    Rigidbody rb;
    JudgeTouchWave touchWave;

    public bool JumpNow()
    {
        return judgeJumpNow.JumpNow();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        touchWave = gameObject.GetComponent<JudgeTouchWave>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        judgeJumpNow.ChangeJumpNowStatus(collision, false);//着地した
    }

    private void OnCollisionExit(Collision collision)
    {
        judgeJumpNow.ChangeJumpNowStatus(collision, true);//ジャンプした
    }

    public void Jump()//ジャンプ
    {
        if (touchWave.TouchWaveNow&&!judgeJumpNow.JumpNow())//波に触れている時かつジャンプしていない時のみジャンプ可能
        {
            this.rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);//ジャンプする高さは常に一定

            //jumpNow = true;//ジャンプした
        }
    }



    /////内部クラス/////

    [System.Serializable]
    private class JudgeJumpNow
    {
        private bool jumpNow=false;//現在ジャンプしているか

        public bool JumpNow()//現在ジャンプしているかを返す(しているならtrue)
        {
            return jumpNow;
        }

        //地面に触れた(着地した)時、ジャンプしていない判定にする(OnCollisionEnter)、引数のotherには触れたオブジェクトの情報をjumpにはfalseを入れる
        //地面から離れた時、ジャンプした判定にする(OnCollisionExit)、引数のotherには触れたオブジェクトの情報をjumpにはtrueを入れる
        //JumpControlクラス以外にはこのメソッドを使わせないようにする
        public void ChangeJumpNowStatus(Collision collison,bool jump)
        {
            if (collison.gameObject.CompareTag("Ground"))//触れているものが地面である
            {
                jumpNow = jump;//現在ジャンプしているかの状態を変える
            }
        }
    }
}
