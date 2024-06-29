using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buff//バフ(基本的にこれを継承してバフを作る)
{
    //[Header("効果時間(秒)")]
    //[SerializeField] float buffTime = 5f;//バフの効果時間(秒)
    [Header("バフの最大ストック数")]
    [SerializeField] int buffStockMax = 6;//バフの最大ストック数
    [Header("バフのエフェクト")]
    [SerializeField] GameObject effect;//バフのエフェクト
    [Header("バフのエフェクトを表示するか")]
    [SerializeField] bool effectShow = true;
    //private float buffRemainingTime = 0f;//バフの残り効果時間(秒)、これが0秒以下になったらバフの効果が切れるようにする
    private int buffStockCount = 0;//バフの残りストック数
    protected bool activateNow = false;//バフ効果発動中か

    /*public float BuffTime
    {
        get { return buffTime; }
    }*/

    public int BuffStockMax
    {
        get { return buffStockMax; }
    }

    public GameObject Effect
    {
        get { return effect; }
    }

    /*public float BuffRemainingTime
    {
        get { return buffRemainingTime; }
    }*/

    public int BuffStockCount
    {
        get { return buffStockCount; }
    }

    public bool ActivateNow
    {
        get { return activateNow; }
    }

    public Buff()
    {
        //buffRemainingTime = 0f;
        buffStockCount = 0;
        activateNow = false;
    }

    //バフの残り効果時間の処理とバフ効果の処理
    public void ProcessBuffEffect()
    {
        //BuffEffectTime();
        BuffEffectCount();
        BuffEffect();
    }

    //バフの残り効果時間の処理
    /*void BuffEffectTime()
    {
        buffRemainingTime-=Time.deltaTime;

        if(buffRemainingTime<=0f)//バフ効果切れ
        {
            activateNow = false;
        }
    }*/

    void BuffEffectCount()
    {
        if(buffStockCount <= 0)//ストックがないなら
        {
            activateNow = false;
        }
    }

    //バフ効果の処理
    protected virtual void BuffEffect()
    {
        if (activateNow)//発動中
        {
            //upBuff.CurrentGrowthRate = upBuff.GrowthRate;
            if(effectShow) effect.SetActive(true);
        }
        else//発動していない時
        {
            //upBuff.CurrentGrowthRate = 1f;
            effect.SetActive(false);
        }
    }


    //バフを発動させる(バフがかかった)時にこれを呼ぶ
    public void Activate()
    {
        activateNow=true;//バフ効果発動中にする
        //buffRemainingTime = buffTime;
    }

    //バフを消す
    public void Deactivate()
    {
        activateNow=false;
        //buffRemainingTime = 0f;
    }

    public void IncreaseBuffStock()
    {
        if(buffStockCount < buffStockMax)//バフストック数が最大値未満なら
        {
            buffStockCount++;//バフストックを1増やす
        }

        else
        {
            return;
        }
    }

    public void DecrementBuffStock()
    {
        if(buffStockCount > 0)//バフストックがあるなら
        {
            buffStockCount--;//バフストックを1減らす
        }

        else
        {
            return;
        }
    }
}

[System.Serializable]
public class UpBuff : Buff//増加系のバフ
{
    [Header("増加率(倍率)")]
    [SerializeField] float growthRate = 1;//増加率(倍率)
    private float currentGrowthRate = 1f;//現在の増加率

    public UpBuff()
    {
        currentGrowthRate = 1f;
    }

    protected override void BuffEffect()
    {
        base.BuffEffect();

        if (activateNow)//発動中
        {
            currentGrowthRate = growthRate;
        }
        else//発動していない時
        {
            currentGrowthRate = 1f;
        }
    }

    public float GrowthRate
    {
        get { return growthRate; }
    }

    public float CurrentGrowthRate
    {
        get { return currentGrowthRate; }
        set { currentGrowthRate = value; }
    }
}

public class BuffOfPlayer : MonoBehaviour
{
    /*[Header("攻撃力アップのバフ")]
    [SerializeField] UpBuff powerUp;//攻撃力アップのバフ
    [Header("チャージトリック増加のバフ")]
    [SerializeField] UpBuff chargeTrick;//チャージトリック増加のバフ*/
    [Header("トリック強化のバフ")]
    [SerializeField] UpBuff trickBoost;//トリック強化のバフ

    /*public UpBuff PowerUp
    {
        get { return powerUp; }
    }

    public UpBuff ChargeTrick
    {
        get { return chargeTrick; }
    }*/

    public UpBuff TrickBoost
    {
        get { return trickBoost; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //powerUp.Effect.SetActive(false);
        //chargeTrick.Effect.SetActive(false);
        trickBoost.Effect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*//攻撃力アップバフ
        powerUp.ProcessBuffEffect();

        //チャージトリック量増加バフ
        chargeTrick.ProcessBuffEffect();*/

        trickBoost.ProcessBuffEffect();
    }

   
}
