using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buff//バフ
{
    [Header("効果時間(秒)")]
    [SerializeField] float buffTime = 5f;//バフの効果時間(秒)
    [Header("バフのエフェクト")]
    [SerializeField] GameObject buffEffect;//バフのエフェクト

    private float buffRemainingTime = 0f;//バフの残り効果時間(秒)、これが0秒以下になったらバフの効果が切れるようにする
    private bool activateNow = false;//バフ効果発動中か

    public float BuffTime
    {
        get { return buffTime; }
    }

    public GameObject BuffEffect
    {
        get { return buffEffect; }
    }

    public float BuffRemainingTime
    {
        get { return buffRemainingTime; }
    }

    public bool ActivateNow
    {
        get { return activateNow; }
    }

    public virtual void Buff_Start()//Startで呼ぶ処理
    {
        buffRemainingTime = 0f;
        activateNow = false;
    }
    
    //バフの残り効果時間の管理
    public void EffectTime()
    {
        buffRemainingTime-=Time.deltaTime;

        if(buffRemainingTime<=0f)//バフ効果切れ
        {
            activateNow = false;
        }
    }

    //バフを発動させる(バフがかかった)時にこれを呼ぶ
    public void Activate()
    {
        activateNow=true;//バフ効果発動中にする
        buffRemainingTime = buffTime;
    }

    //バフを消す
    public void Deactivate()
    {
        activateNow=false;
        buffRemainingTime = 0f;
    }
}

[System.Serializable]
public class UpBuff : Buff//増加系のバフ
{
    [Header("増加率(倍率)")]
    [SerializeField] float growthRate = 1;//増加率(倍率)
    private float currentGrowthRate = 1f;//現在の増加率

    public override void Buff_Start()
    {
        base.Buff_Start();
        currentGrowthRate = 1f;
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
    [Header("攻撃力アップのバフ")]
    [SerializeField] UpBuff powerUp;//攻撃力アップのバフ
    [Header("チャージトリック増加のバフ")]
    [SerializeField] UpBuff chargeTrick;//チャージトリック増加のバフ

    public UpBuff PowerUp
    {
        get { return powerUp; }
    }

    public UpBuff ChargeTrick
    {
        get { return chargeTrick; }
    }

    // Start is called before the first frame update
    void Start()
    {
        powerUp.Buff_Start();
        chargeTrick.Buff_Start();
    }

    // Update is called once per frame
    void Update()
    {
        //攻撃力アップバフ
        powerUp.EffectTime();
        UpBuffEffect(powerUp);

        //チャージトリック量増加バフ
        chargeTrick.EffectTime();
        UpBuffEffect(chargeTrick);
    }

    void UpBuffEffect(UpBuff upBuff)//アップ系のバフの発動中の効果
    {
        if(upBuff.ActivateNow)//発動中
        {
            upBuff.CurrentGrowthRate=upBuff.GrowthRate;
            upBuff.BuffEffect.SetActive(true);
        }
        else//発動していない時
        {
            upBuff.CurrentGrowthRate = 1f;
            upBuff.BuffEffect.SetActive(false);
        }
    }

}
