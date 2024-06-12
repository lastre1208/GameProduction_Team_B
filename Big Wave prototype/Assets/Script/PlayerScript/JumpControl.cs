using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    //☆塩が書いた
    [SerializeField] float jumpPower=9f;//ジャンプ力
    private bool jumpNow;//今ジャンプしているか
    //[SerializeField] float jumpPowerAdjustment = 60f;//ジャンプ力調整用、小さいほど最大トリック時のジャンプの高さが上がる
    Rigidbody rb;
    JudgeTouchWave touchWave;
    Player player;

    public bool JumpNow
    {
        get { return jumpNow; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        touchWave = gameObject.GetComponent<JudgeTouchWave>();
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Ground"))//床に触れた→ジャンプしていない
        {
            //player.ConsumeTRICK();
            jumpNow = false;
        }
    }

    public void Jump()//ジャンプ
    {
        if (touchWave.TouchWaveNow&&JumpNow==false)//ジャンプしていない時かつ波に触れているときのみジャンプ可能
        {
            //if (jumpNow == true) return;
            //this.rb.AddForce(transform.up * jumpPower * (1 + player.trick / jumpPowerAdjustment), ForceMode.Impulse);//!!!!!(要調整)
            this.rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);//ジャンプする高さは常に一定

            jumpNow = true;//ジャンプした
        }
      
    }
}
