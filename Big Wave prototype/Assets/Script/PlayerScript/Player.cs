using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //☆塩が書いた
    private float hp = 100;//現在の体力
    [Header("プレイヤーの最大体力")]
    [SerializeField] float hpMax = 100;//最大体力
    
    [Header("プレイヤーの1ゲージの最大トリック")]
    [SerializeField] float trickGaugeMax = 50;//1ゲージに入る最大トリック(全ゲージ同じ容量)
    [Header("プレイヤーのトリックゲージの数(本数)")]
    [SerializeField] int trickGaugeNum=6;//トリックゲージの本数
    private bool barrier = false;//無敵状態か(trueの時無敵になる)
    private float[] trick;//トリックゲージ(容量trickMaxのゲージがtrickGaugeNum個ある)
    private int maxCount=0;//満タンのトリックゲージの量
    SceneControlManager sceneControlManager;

    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public float HpMax
    {
       get { return hpMax; }
    }

    public float[] Trick
    {
        get { return trick; }
    }

    public float TrickMax
    {
        get { return trickGaugeMax; }
    }

    public int TrickGaugeNum
    {
        get { return trickGaugeNum; }
    }

    public int MaxCount
    {
        get { return maxCount; }
    }

    public bool Barrier
    {
        get { return barrier; }
        set { barrier = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Hpの初期化
        hp = hpMax;
        //トリックの初期化
        trick = new float[trickGaugeNum];
        for(int i=0;i<trick.Length ;i++)
        {
            trick[i] = 0;
        }

        sceneControlManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneControlManager>();
    }

    // Update is called once per frame
    void Update()
    {
        hp=Mathf.Clamp(hp,0,hpMax);//体力が限界突破しないように

        Dead();//敵プレイヤー死亡時ゲームオーバーシーンに移行
    }

    public void ChargeTrick(float charge)//トリックのチャージ
    {
        if(maxCount==trickGaugeNum)//どのゲージも満タンの時は処理しない
        {
            return;
        }

        for(int i=maxCount; i<trick.Length;i++)
        {
            trick[i] += charge;

            if (trick[i]>=trickGaugeMax)//今チャージしているゲージが満タンになったら
            {
                charge = trick[i]-trickGaugeMax;//次のゲージにチャージする分
                trick[i] = trickGaugeMax;//トリックが限界突破しないように
                maxCount++;//満タンのトリックゲージの数を増やす
            }
            else//今チャージしているゲージが満タンにならなかったらチャージ処理を終える
            {
                break;
            }
        }
    }

    public bool ConsumeCharge(int cost)//トリックの消費(使うゲージ量を引数に入れる、使用ゲージが足りないとfalseを返されるのでそれで処理の可・不可を判断)
    {
        if(maxCount<cost)//使うゲージ量が足りなければ
        {
            return false;
        }

        else//足りれば
        {
            //使うゲージの中身を0にする
            for(int i=0; i<cost;i++)
            {
                trick[maxCount - 1 - i] = 0;
            }

            //
            if(maxCount==trickGaugeNum)
            {

            }
            else
            {
                trick[maxCount - cost] = trick[maxCount];
                trick[maxCount] = 0;
            }
            
            //満タンのゲージの数を使った分減らす
            maxCount -= cost;

            return true;
        }
    }

    void Dead()//プレイヤー死亡時ゲームオーバーシーンに移行
    {
        if(hp <=0)
        {
            sceneControlManager.ChangeGameoverScene();
        }
    }
}
