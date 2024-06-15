using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffOfPlayer : MonoBehaviour
{
    [Header("攻撃力アップのバフの効果時間(秒)")]
    [SerializeField] float powerUpBuffTime = 20f;//攻撃力アップのバフの効果時間(秒)
    [Header("攻撃力増加率(倍率)")]
    [SerializeField] float powerUpGrowthRate=1;//攻撃力増加率(倍率)
    [Header("攻撃力アップのバフ時のエフェクト")]
    [SerializeField] GameObject powerUpBuffEffect;//攻撃力アップのバフ時のエフェクト
    [Header("チャージトリック量増加のバフの効果時間(秒)")]
    [SerializeField] float chargeTrickBuffTime = 20f;//チャージトリック量増加のバフの効果時間(秒)
    [Header("チャージトリック量増加率(倍率)")]
    [SerializeField] float chargeTrickGrowthRate=1;//チャージトリック量増加率(倍率)
    [Header("チャージトリック量増加のバフのエフェクト")]
    [SerializeField] GameObject chargeTrickBuffEffect;//チャージトリック量増加のバフのエフェクト
    private float currentPowerUpGrowthRate = 1f;//現在の攻撃力増加率(倍率)、バフがかかってない時は1、かかっているときはpowerUpGrowthRateになる
    private float currentChargeTrickGrowthRate = 1f;//現在のチャージトリック量増加率(倍率)、バフがかかってない時は1、かかっているときはchargeTrickGrowthRateになる
    private float powerUpBuffRemainingTime = 0f;//攻撃力アップのバフ効果の残り時間(秒)
    private float chargeTrickBuffRemainingTime = 0f;//チャージトリック量増加のバフ効果の残り時間(秒)

    public float CurrentPowerUpGrowthRate
    {
        get { return currentPowerUpGrowthRate; }
    }

    public float CurrentChargeTrickGrowthRate
    {
        get {return currentChargeTrickGrowthRate; }
    }

    // Start is called before the first frame update
    void Start()
    {
        powerUpBuffEffect.SetActive(false);
        chargeTrickBuffEffect.SetActive(false);
        currentPowerUpGrowthRate = 1f;
        currentChargeTrickGrowthRate = 1f;
        powerUpBuffRemainingTime = 0f;
        chargeTrickBuffRemainingTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpBuffEffectTime();//攻撃力アップバフの時間と効果を管理

        ChargeTrickBuffEffectTime();//チャージトリック量増加バフの時間と効果を管理
    }

    void PowerUpBuffEffectTime()//攻撃力アップバフの時間と効果を管理
    {
        powerUpBuffRemainingTime -= Time.deltaTime;

        if(powerUpBuffRemainingTime>0)
        {
            currentPowerUpGrowthRate = powerUpGrowthRate;
            powerUpBuffEffect.SetActive(true);
        }
        else
        {
            currentPowerUpGrowthRate = 1;
            powerUpBuffEffect.SetActive(false);
        }
    }

    void ChargeTrickBuffEffectTime()//チャージトリック量増加バフの時間と効果を管理
    {
        chargeTrickBuffRemainingTime -= Time.deltaTime;

        if(chargeTrickBuffRemainingTime>0)
        {
            currentChargeTrickGrowthRate = chargeTrickGrowthRate;
            chargeTrickBuffEffect.SetActive(true);
        }
        else
        {
            currentChargeTrickGrowthRate= 1;
            chargeTrickBuffEffect.SetActive(false);
        }
    }

    public void PowerUpBuff()//攻撃力アップのバフをかける時に呼び出す
    {
        powerUpBuffRemainingTime = powerUpBuffTime;
    }

    public void ChargeTrickBuff()//チャージトリック量増加のバフをかける時に呼び出す
    {
        chargeTrickBuffRemainingTime= chargeTrickBuffTime;
    }
}
