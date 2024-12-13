using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//作成者:杉山
//トリックポイント
public class TrickPoint : MonoBehaviour
{
    [Header("1ゲージに入る最大トリックポイントの量")]
    [SerializeField] float trickPointMax = 50;//1ゲージに入る最大トリックポイント(全ゲージ同じ容量)
    [Header("トリックゲージの本数")]
    [SerializeField] int _trickGaugeNum;
    public event Action<int> FullEvent;//ゲージが満タンになった時に呼ぶイベント、引数には満タンのゲージの数が入る
    private int maxCount = 0;//満タンのトリックゲージの数
    private float[] _trickPoint;//トリックポイント(容量trickGaugeMaxのゲージがtrickGaugeNum個ある)

    public float this[int index]
    {
        get { return _trickPoint[index]; }
    }

    public float TrickPointMax//トリックゲージ1本に入るトリックの容量
    {
        get { return trickPointMax; }
    }

    public int TrickGaugeNum//トリックゲージの本数
    {
        get { return _trickGaugeNum; }
    }

    public int MaxCount//満タンのトリックゲージの本数
    {
        get { return maxCount; }
    }

    public bool Full//全てのゲージが満タンか
    {
        get { return maxCount == _trickGaugeNum; }
    }

    public void Charge(float charge)//トリックポイントのチャージ
    {
        if (maxCount == _trickPoint.Length)//全ゲージが満タンの時は処理しない
        {
            return;
        }

        for (int i = maxCount; i < _trickPoint.Length; i++)
        {
            _trickPoint[i] += charge;

            if (_trickPoint[i] >= trickPointMax)//今チャージしているゲージが満タンになったら
            {
                charge = _trickPoint[i] - trickPointMax;//次のゲージにチャージする分
                _trickPoint[i] = trickPointMax;//トリックポイントが限界突破しないように
                maxCount++;//満タンのトリックゲージの数を増やす
                FullEvent?.Invoke(maxCount);
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
                _trickPoint[maxCount - 1 - i] = 0;
            }


            if (!Full)
            {
                _trickPoint[maxCount - cost] = _trickPoint[maxCount];
                _trickPoint[maxCount] = 0;
            }

            //満タンのゲージの数を使った分減らす
            maxCount -= cost;

            return true;
        }
    }

    void Start()
    {
        //トリックゲージの本数分のトリックゲージを確保
        _trickPoint = new float[_trickGaugeNum];

        for (int i = 0; i < _trickPoint.Length; i++)
        {
            _trickPoint[i] = new float();
        }
    }
}
