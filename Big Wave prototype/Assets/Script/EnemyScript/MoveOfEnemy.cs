using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOfEnemy : MonoBehaviour
{
    //☆塩が書いた
    [Header("▼敵の動く最小スピード")]
    [SerializeField] float speedMin = 15f;//敵の動く最小スピード
    [Header("▼敵の動く最大スピード")]
    [SerializeField] float speedMax = 20f;//敵の動く最大スピード
    [Header("▼寄っている方向と反対側方向に移動する確率(%)")]
    [SerializeField] float directionProbability = 60f;
    private bool moveNow=false;//今動いているか
    private bool isLeft = false;
    private float speed;//敵の動くスピード
    private Vector3 move;
    //MoveManager movemanager;

    public bool MoveNow
    {
        set { moveNow = value; }
        get { return moveNow; }
    }
    // Start is called before the first frame update
    void Start()
    {
        //MoveManagerからlimitrangeを取得し、ForwardMoveのlimitrangeに代入
        //movemanager = GameObject.FindWithTag("MoveManager").GetComponent<MoveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOnTheLeft();//今左側にいるか確認
        Move();// 敵の動き
    }

    public void ChangeMove()//動こうとしたときに必ず動きもランダムに変更する
    {
        //動く方向を変更
        float change;
        change= Random.Range(0, 100);
        if(isLeft)//左側にいる時
        {
            //左側にいる時右方向に移動しやすくする
            if(change<=directionProbability)
            {
                move = Vector3.right;
            }
            else
            {
                move = Vector3.left;
            }
        }
        else//右側にいる時
        {
            //右側にいる時左方向に移動しやすくする
            if (change <= directionProbability)
            {
                move = Vector3.left;
            }
            else
            {
                move = Vector3.right;
            }
        }

        //スピードを変更
        speed = Random.Range(speedMin, speedMax);
    }

    void CheckOnTheLeft()//今左側にいるか確認
    {
        Vector3 currentPos;//現在位置

        currentPos=gameObject.transform.position;

        if(currentPos.x<=0)//左側にいる
        {
            isLeft = true;
        }
        else//右側にいる
        {
            isLeft= false;
        }
    }

    //敵の動き
    void Move()
    {
       if(moveNow)
        {
           transform.Translate(move * speed * Time.deltaTime);
        }
    }
}
