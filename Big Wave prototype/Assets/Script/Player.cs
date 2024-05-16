using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float hp = 100;//現在の体力
    public float hpMax = 100;//最大体力
    public float trick = 0;//現在のトリックゲージ
    public float trickMax = 50;//最大トリックゲージ
   
    
    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;//ステータス初期化
        trick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LimitHP();//体力が限界突破しないように

        LimitTRICK();//トリックが限界突破しないように
    }
    
    public void ChargeTRICK()//トリックを増やす
    {
        trick++;
    }

    public void ConsumeTRICK()//トリックを0にする
    {
        trick = 0;
    }

    void LimitHP()//体力が限界突破しないように
    {
        if (hp > hpMax)
        {
            hp = hpMax;
        }
    }

    void LimitTRICK()//トリックが限界突破しないように
    {
        if (trick > trickMax)
        {
            trick = trickMax;
        }
    }

    
}
