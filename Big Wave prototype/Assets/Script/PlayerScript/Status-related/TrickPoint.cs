using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//作成者:杉山
//トリックポイント
public class TrickPoint : MonoBehaviour
{
    [System.Serializable]
    class A_TrickPoint
    {
        [Header("満タンになった時に呼ぶイベント")]
        [SerializeField] UnityEvent fullEvent;
        private float trickPoint=0;//トリックポイント

        public A_TrickPoint()
        {
            trickPoint = 0;
        }

        public float TrickPoint
        {
            get { return trickPoint; } 
            set {  trickPoint = value; }
        }

        public void FullTrigger()//満タンになった直後に呼ぶ処理
        {
            fullEvent.Invoke();
        }
    }

    [Header("1ゲージに入る最大トリックポイントの量")]
    [SerializeField] float trickPointMax = 50;//1ゲージに入る最大トリックポイント(全ゲージ同じ容量)
    [Header("トリックゲージの本数分要素を作ってください")]
    [SerializeField] A_TrickPoint[] trickPoint;//トリックポイント(容量trickGaugeMaxのゲージがtrickGaugeNum個ある)
    private int maxCount = 0;//満タンのトリックゲージの数

    public float this[int index]
    {
        get { return trickPoint[index].TrickPoint; }
    }

    public float TrickPointMax//トリックゲージ1本に入るトリックの容量
    {
        get { return trickPointMax; }
    }

    public int TrickGaugeNum//トリックゲージの本数
    {
        get { return trickPoint.Length; }
    }

    public int MaxCount//満タンのトリックゲージの本数
    {
        get { return maxCount; }
    }

    public bool Full//全てのゲージが満タンか
    {
        get { return maxCount == trickPoint.Length; }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void Charge(float charge)//トリックポイントのチャージ
    {
        if (maxCount == trickPoint.Length)//全ゲージが満タンの時は処理しない
        {
            return;
        }

        for (int i = maxCount; i < trickPoint.Length; i++)
        {
            trickPoint[i].TrickPoint += charge;

            if (trickPoint[i].TrickPoint >= trickPointMax)//今チャージしているゲージが満タンになったら
            {
                charge = trickPoint[i].TrickPoint - trickPointMax;//次のゲージにチャージする分
                trickPoint[i].TrickPoint = trickPointMax;//トリックポイントが限界突破しないように
                trickPoint[i].FullTrigger();
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
                trickPoint[maxCount - 1 - i].TrickPoint = 0;
            }


            if (maxCount != trickPoint.Length)
            {
                trickPoint[maxCount - cost].TrickPoint = trickPoint[maxCount].TrickPoint;
                trickPoint[maxCount].TrickPoint = 0;
            }

            //満タンのゲージの数を使った分減らす
            maxCount -= cost;

            return true;
        }
    }
}
