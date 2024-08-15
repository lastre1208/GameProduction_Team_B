using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightRoad : RoadBase
{
    [Header("前方移動速度")]
    [SerializeField] float speed = 40f;//前方移動速度
    [SerializeField] GameObject target;
    // Update is called once per frame
   
    public override void OnUpdate()
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
