using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    //☆塩が書いた
    [SerializeField] float speedMin = 15f;//敵の動く最小スピード
    [SerializeField] float speedMax = 20f;//敵の動く最大スピード
    [SerializeField] float minChangeMoveTime = 0.1f;//敵の動きが変わる最小時間
    [SerializeField] float maxChangeMoveTime = 0.4f;//敵の動きが変わる最代時間
    private float speed;//敵の動くスピード
    private float moveChangeTime = 0f;//敵の動きが変わる時間
    private float moveTime = 0f;//敵の行動を管理する時間
    private int moveleft = 1;// 1が左、0が立ち止まる、-1が右
    MoveManager movemanager;
    // Start is called before the first frame update
    void Start()
    {
        //MoveManagerからlimitrangeを取得し、ForwardMoveのlimitrangeに代入
        movemanager = GameObject.FindWithTag("MoveManager").GetComponent<MoveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();// 敵の動き
    }

    //敵の動き
    //!!!!!要検討
    //
    void Move()
    {
        moveTime += Time.deltaTime;

        Vector3 currentpos = transform.position;

        if (moveTime > moveChangeTime || currentpos.x == movemanager.limitRange || currentpos.x == -movemanager.limitRange)
        {
            moveTime = 0;
            moveChangeTime = Random.Range(minChangeMoveTime, maxChangeMoveTime);
            moveleft = Random.Range(-1, 2);
            speed = Random.Range(speedMin, speedMax);
            //if(moveleft==0)
            //{
            //    moveleft = -1;
            //}
        }

        Vector3 move = Vector3.left;
        transform.Translate(move * speed * Time.deltaTime * moveleft);
    }
}
