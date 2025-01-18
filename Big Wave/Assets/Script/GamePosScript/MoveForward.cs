using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [Header("前方移動速度")]
    [SerializeField] float speed = 40f;//前方移動速度
   
    // Update is called once per frame
    public void Update()
    {
        Move();
    }
   

    //前方移動
    //speedの速さで前に進む
    void Move()
    {
        Vector3 move = Vector3.forward;
        transform.Translate(move * Time.deltaTime * speed);
    }
}
