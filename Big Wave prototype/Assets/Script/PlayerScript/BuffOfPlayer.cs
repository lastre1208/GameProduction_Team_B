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

    private float buffRemainingTime = 0f;//バフ効果の残り時間(秒)

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
        set { buffRemainingTime = value; }
    }
}

[System.Serializable]
public class UpBuff : Buff//増加系のバフ
{
    [Header("増加率(倍率)")]
    [SerializeField] float growthRate = 1;//増加率(倍率)
    private float currentGrowthRate = 1f;//現在の増加率

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
        powerUp.BuffEffect.SetActive(false);
        powerUp.CurrentGrowthRate = 1f;
        powerUp.BuffRemainingTime = 0f;

        chargeTrick.BuffEffect.SetActive(false);
        chargeTrick.CurrentGrowthRate = 1f;
        chargeTrick.BuffRemainingTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpBuffEffectTime(powerUp);//攻撃力アップバフの時間と効果を管理

        UpBuffEffectTime(chargeTrick);//チャージトリック量増加バフの時間と効果を管理
    }

    void UpBuffEffectTime(UpBuff upBuff)//増加系バフの時間と効果を管理
    {
        upBuff.BuffRemainingTime -= Time.deltaTime;

        if(upBuff.BuffRemainingTime>0)
        {
            upBuff.CurrentGrowthRate = upBuff.GrowthRate;
            upBuff.BuffEffect.SetActive(true);
        }
        else
        {
            upBuff.CurrentGrowthRate = 1;
            upBuff.BuffEffect.SetActive(false);
        }
    }

    public void PowerUpBuff()//攻撃力アップのバフをかける時に呼び出す
    {
        powerUp.BuffRemainingTime = powerUp.BuffTime;
    }

    public void ChargeTrickBuff()//チャージトリック量増加のバフをかける時に呼び出す
    {
        chargeTrick.BuffRemainingTime= chargeTrick.BuffTime;
    }
}
