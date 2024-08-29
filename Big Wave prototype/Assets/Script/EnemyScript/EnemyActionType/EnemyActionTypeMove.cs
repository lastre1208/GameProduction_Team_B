using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//敵の横移動
public class EnemyActionTypeMove : EnemyActionTypeBase
{
    //☆塩が書いた
    [Header("▼動かしたいオブジェクト")]
    [SerializeField] GameObject moveObject;//動かしたいオブジェクト(敵)
    [Header("▼動く最小スピード")]
    [SerializeField] float speedMin = 15f;//動く最小スピード
    [Header("▼動く最大スピード")]
    [SerializeField] float speedMax = 20f;//動く最大スピード
    [Header("▼進行方向が変わる最小時間")]
    [SerializeField] float changeTimeMin;//進行方向が変わる最小時間
    [Header("▼進行方向が変わる最小時間")]
    [SerializeField] float changeTimeMax;//進行方向が変わる最大時間
    [Header("▼寄っている方向と反対側方向に移動する確率(%)")]
    [SerializeField] float directionProbability = 60f;
    private float speed;//動くスピード
    private float currentChangeTime=0;//これが進行方向変更する時間(changeTime)に達すると、進行方向を変更する
    private float changeTime;//進行方向変更時間
    private Vector3 move;

    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        ChangeMove();//動き方を変更する
    }

    public override void OnUpdate()
    {
        currentChangeTime += Time.deltaTime;

        bool moveChange = (currentChangeTime >= changeTime);//進行方向変更時間に達すると、進行方向を変更する

        if(moveChange)//進行方向変更
        {
            ChangeMove();//動き方を変更する
        }
        
        Move();//動く
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {
       
    }

    void ChangeMove()//動き方を変更する
    {
        //動く方向をランダム設定
        float change = Random.Range(0, 100);

        if (IsLeft())//左側にいる時
        {
            //左側にいる時右方向に移動しやすくする
            if (change <= directionProbability)
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

        //スピードをランダム設定
        speed = Random.Range(speedMin, speedMax);

        //進行方向変更時間をランダム設定
        changeTime = Random.Range(changeTimeMin, changeTimeMax);
        //currentChangeTimeをリセット
        currentChangeTime = 0;
    }

    bool IsLeft()//今左側にいるか確認
    {
        Vector3 currentPos;//現在位置

        currentPos = moveObject.transform.position;

        if (currentPos.x <= 0)//左側にいる
        {
            return true;
        }
        else//右側にいる
        {
            return false;
        }
    }

    //動く
    void Move()
    {
        moveObject.transform.Translate(move * speed * Time.deltaTime);
    }
}
