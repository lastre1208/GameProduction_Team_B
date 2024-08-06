using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    //☆塩が書いた
    [SerializeField] float jumpPower=9f;//ジャンプ力
    private bool jumpNow;//今ジャンプしているか
    Rigidbody rb;
    JudgeTouchWave touchWave;

    public bool JumpNow
    {
        get { return jumpNow; }
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

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Ground"))//床に触れた→ジャンプしていない
        {
            jumpNow = false;
        }
    }

    public void Jump()//ジャンプ
    {
        if (touchWave.TouchWaveNow&&JumpNow==false)//ジャンプしていない時かつ波に触れているときのみジャンプ可能
        {
            this.rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);//ジャンプする高さは常に一定

            jumpNow = true;//ジャンプした
        }
      
    }
}
