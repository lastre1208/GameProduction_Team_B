using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //☆塩が書いた
    //HP関係
    [Header("プレイヤーの最大体力")]
    [SerializeField] float hpMax = 100;//最大体力
    private float hp = 100;//現在の体力

    //トリックポイント関係
    [Header("プレイヤーの1ゲージに入る最大トリックポイントの量")]
    [SerializeField] float trickPointMax = 50;//1ゲージに入る最大トリックポイント(全ゲージ同じ容量)
    [Header("プレイヤーのトリックゲージの数(本数)")]
    [SerializeField] int trickGaugeNum=6;//トリックゲージの本数
    private float[] trickPoint;//トリックポイント(容量trickGaugeMaxのゲージがtrickGaugeNum個ある)
    private int maxCount=0;//満タンのトリックゲージの数

    //フィーバーポイント関係
    [Header("最大フィーバーポイント")]
    [SerializeField] float feverPointMax = 500f;//最大フィーバーポイント
    private float feverPoint=0f;//現在のフィーバーポイント

    SceneControlManager sceneControlManager;

    //HP関係
    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public float HpMax
    {
       get { return hpMax; }
    }

    //トリックポイント関係
    public float[] TrickPoint
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

    //フィーバーポイント関係
    public float FeverPoint
    {
        get { return feverPoint; }
        set { feverPoint = value; }
    }

    public float FeverPointMax
    {
        get { return feverPointMax; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Hpの初期化
        hp = hpMax;
        //トリックの初期化
        trickPoint = new float[trickGaugeNum];
        for(int i=0;i<trickPoint.Length ;i++)
        {
            trickPoint[i] = 0f;
        }
        //フィーバーポイントの初期化
        feverPoint = 0f;

        sceneControlManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneControlManager>();
    }

    // Update is called once per frame
    void Update()
    {
        hp=Mathf.Clamp(hp,0f,hpMax);//体力が限界突破しないように

        feverPoint = Mathf.Clamp(feverPoint, 0f, feverPointMax);//フィーバーポイントが限界突破しないように

        Dead();//敵プレイヤー死亡時ゲームオーバーシーンに移行
    }

    //トリックポイント関係のメソッド

    public void ChargeTrickPoint(float charge)//トリックポイントのチャージ
    {
        if(maxCount==trickGaugeNum)//全ゲージが満タンの時は処理しない
        {
            return;
        }

        for(int i=maxCount; i<trickPoint.Length;i++)
        {
            trickPoint[i] += charge;

            if (trickPoint[i]>=trickPointMax)//今チャージしているゲージが満タンになったら
            {
                charge = trickPoint[i]-trickPointMax;//次のゲージにチャージする分
                trickPoint[i] = trickPointMax;//トリックポイントが限界突破しないように
                maxCount++;//満タンのトリックゲージの数を増やす
            }
            else//今チャージしているゲージが満タンにならなかったらチャージ処理を終える
            {
                break;
            }
        }
    }

    public bool ConsumeTrickPoint(int cost)//トリックポイントの消費(使うゲージ量を引数に入れる、使用ゲージが足りないとfalseを返されるのでそれで処理の可・不可を判断)
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
                trickPoint[maxCount - 1 - i] = 0;
            }

            //
            if(maxCount==trickGaugeNum)
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

    //後で別のスクリプトに移すかも
    void Dead()//プレイヤー死亡時ゲームオーバーシーンに移行
    {
        if(hp <=0)
        {
            sceneControlManager.ChangeGameoverScene();
        }
    }
}
