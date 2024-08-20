using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:桑原
public class HoverJump : MonoBehaviour
{
    [Header("トリック使用時の滞空時間")]
    [SerializeField] float hoverTime = 0.2f;//トリック使用時の滞空時間
    [Header("滞空終了時に起こるジャンプの強さ")]
    [SerializeField] float hoverJumpStrength = 5f;//滞空終了時に起こるジャンプの強さ
    //private Coroutine coroutine;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void HoverDelayJump()//hoverTime秒ホバーした後ジャンプする
    {
        StartCoroutine(HoverJumpCoroutine());
    }

    IEnumerator HoverJumpCoroutine()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;//重力とジャンプの運動を一時的に止める

        yield return new WaitForSeconds(hoverTime);

        rb.useGravity = true;
        rb.velocity = new(0, hoverJumpStrength, 0);
    }
}
