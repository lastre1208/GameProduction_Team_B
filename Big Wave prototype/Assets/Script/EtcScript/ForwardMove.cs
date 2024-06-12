using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMove : MonoBehaviour
{
    //☆塩が書いた
    MoveManager movemanager;
    // Start is called before the first frame update
    void Start()
    {
        movemanager = GameObject.FindWithTag("MoveManager").GetComponent<MoveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();//前方移動
    }

    //前方移動
    //MoveManagerのforwardspeedの速さで前に進む
    void Move()
    {
        Vector3 move = Vector3.forward;
        transform.Translate(move * Time.deltaTime * movemanager.ForwardSpeed);
    }
}
