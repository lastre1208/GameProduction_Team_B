using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickPoint : MonoBehaviour
{
    [Header("1ゲージに入る最大トリックポイントの量")]
    [SerializeField] float trickPointMax = 50;//1ゲージに入る最大トリックポイント(全ゲージ同じ容量)
    [Header("トリックゲージの数(本数)")]
    [SerializeField] int trickGaugeNum = 6;//トリックゲージの本数
    private float[] trickPoint;//トリックポイント(容量trickGaugeMaxのゲージがtrickGaugeNum個ある)
    private int maxCount = 0;//満タンのトリックゲージの数

    public float[] TrickPoint_
    {
        get { return trickPoint; }
    }

    public float TrickPointMax//トリックゲージ1本に入るトリックの容量
    {
        get { return trickPointMax; }
    }

    public int TrickGaugeNum//トリックゲージの本数
    {
        get { return trickGaugeNum; }
    }

    public int MaxCount//満タンのトリックゲージの本数
    {
        get { return maxCount; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //トリックの初期化
        trickPoint = new float[trickGaugeNum];
        for (int i = 0; i < trickPoint.Length; i++)
        {
            trickPoint[i] = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Charge(float charge)//トリックポイントのチャージ
    {
        if (maxCount == trickGaugeNum)//全ゲージが満タンの時は処理しない
        {
            return;
        }

        for (int i = maxCount; i < trickPoint.Length; i++)
        {
            trickPoint[i] += charge;

            if (trickPoint[i] >= trickPointMax)//今チャージしているゲージが満タンになったら
            {
                charge = trickPoint[i] - trickPointMax;//次のゲージにチャージする分
                trickPoint[i] = trickPointMax;//トリックポイントが限界突破しないように
                maxCount++;//満タンのトリックゲージの数を増やす
            }
            else//今チャージしているゲージが満タンにならなかったらチャージ処理を終える
            {
                break;
            }
        }
    }

    public bool Consume(int cost)//トリックポイントの消費(使うゲージ量を引数に入れる、使用ゲージが足りないとfalseを返されるのでそれでトリックポイントの足・不足を判断)
    {
        if (maxCount < cost)//使うゲージ量が足りなければ
        {
            return false;
        }

        else//足りれば
        {
            //使うゲージの中身を0にする
            for (int i = 0; i < cost; i++)
            {
                trickPoint[maxCount - 1 - i] = 0;
            }


            if (maxCount == trickGaugeNum)
            {

            }
            else
            {
                trickPoint[maxCount - cost] = trickPoint[maxCount];
                trickPoint[maxCount] = 0;
            }

            //満タンのゲージの数を使った分減らす
            maxCount -= cost;

            return true;
        }
    }
}
