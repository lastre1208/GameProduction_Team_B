using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:桑原(コルーチン部分)
//一部杉山が改造
public class HoverJump : MonoBehaviour
{
    Rigidbody rb;
    //[Header("トリック使用時の滞空時間")]
    //[SerializeField] float hoverTime = 0.2f;//トリック使用時の滞空時間
    [Header("ジャンプの強さ")]
    [SerializeField] float jumpStrength = 5f;//ジャンプの強さ
                                                  //private Coroutine coroutine;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void HoverJumpTrigger()//ホバージャンプの発動
    {
        if(rb.velocity.y<=0) rb.velocity = Vector3.zero;//落ちている時は一旦落ちる速度を0にする

        rb.AddForce(Vector3.up*jumpStrength,ForceMode.Impulse);
        //rb.velocity += accelerationVector*Time.deltaTime;//加速
    }

    //IEnumerator HoverJumpCoroutine()//遅れてホバージャンプする
    //{
    //    rb.useGravity = false;
    //    rb.velocity = Vector3.zero;//重力とジャンプの運動を一時的に止める

    //    yield return new WaitForSeconds(hoverTime);

    //    rb.useGravity = true;
    //    rb.velocity = new(0, hoverJumpStrength, 0);
    //}
}
