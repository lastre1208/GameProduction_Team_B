using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    [HideInInspector] public bool jumpNow;//今ジャンプしているか
    [HideInInspector] public bool touchInsideWaveNow=false;//現在内側の波に触っているか
    [HideInInspector] public bool touchOutsideWaveNow = false;//現在外側の波に触っているか
    public float jumpPower=9f;//ジャンプ力
    //[SerializeField] float jumpPowerAdjustment = 60f;//ジャンプ力調整用、小さいほど最大トリック時のジャンプの高さが上がる
    Rigidbody rb;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(touchInsideWaveNow||touchOutsideWaveNow)//波に触れている間のみジャンプ可能
        {
            Jump();//ジャンプ
        }
        
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Ground"))//床に触れた→ジャンプしていない
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            //player.ConsumeTRICK();
            jumpNow = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("InsideWave"))//内側の波に触れている
        {
            touchInsideWaveNow = true;
        }

        else if(other.gameObject.CompareTag("OutsideWave"))//外側の波に触れている
        {
            touchOutsideWaveNow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("InsideWave"))//内側の波から出たら内側の波に触れていない(判定)
        {
            touchInsideWaveNow = false;
        }

        else if(other.gameObject.CompareTag("OutsideWave"))//外側の波から出たら外側の波に触れていない(判定)
        {
            touchOutsideWaveNow = false;
        }
    }

    void Jump()//ジャンプしてない時のみジャンプ可能(ジャンプしたらジャンプしてる判定にする)、ジャンプ時のトリックの値に応じてジャンプの高さが変化する
    {
        if (Input.GetKeyUp(KeyCode.JoystickButton5) || Input.GetKeyUp(KeyCode.JoystickButton4)||Input.GetKeyUp("space"))//スペースキーでジャンプする
        {
            if (jumpNow == true) return;//既にジャンプしていたらジャンプできない


            //this.rb.AddForce(transform.up * jumpPower * (1 + player.trick / jumpPowerAdjustment), ForceMode.Impulse);//!!!!!(要調整)
            this.rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);//ジャンプする高さは一定

            jumpNow = true;//ジャンプした
        }
      
    }
}
