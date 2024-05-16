using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    public bool jumpNow;//今ジャンプしているか
    public float jumpPower=9f;//ジャンプ力
    [SerializeField] float jumpPowerAdjustment = 60f;//ジャンプ力調整用、小さいほど最大トリック時のジャンプの高さが上がる
    Rigidbody rb;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
            Jump();//ジャンプ
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Ground"))//床に触れた時ジャンプしてない判定にする
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            //player.ConsumeTRICK();
            jumpNow = false;
        }
    }

    void OnTriggerEnter(Collider t)
    {
        if ((Input.GetKey(KeyCode.JoystickButton5)||Input.GetKey(KeyCode.JoystickButton4)||Input.GetKey("space"))  && t.gameObject.CompareTag("Wave"))
        {
            player.ChargeTRICK();
        
        }
     
    }

    void Jump()//ジャンプしてない時のみジャンプ可能(ジャンプしたらジャンプしてる判定にする)、ジャンプ時のトリックの値に応じてジャンプの高さが変化する
    {
        if (Input.GetKeyUp(KeyCode.JoystickButton5) || Input.GetKeyUp(KeyCode.JoystickButton4)||Input.GetKeyUp("space"))//スペースキーでジャンプする
        {
            if (jumpNow == true) return;

            this.rb.AddForce(transform.up * jumpPower * (1 + player.trick / jumpPowerAdjustment), ForceMode.Impulse);//!!!!!(要調整)

            jumpNow = true;
        }
      
    }
}
