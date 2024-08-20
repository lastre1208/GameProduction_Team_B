using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverMode : MonoBehaviour
{
    [Header("フィーバー状態のエフェクト")]
    [SerializeField] GameObject feverEffect;//フィーバー状態のエフェクト
    [Header("フィーバー状態の効果時間")]
    [SerializeField] float feverTime=20f;//フィーバー状態の効果時間
    private float remainingFeverTime = 0f;//フィーバー状態の残り効果時間
    [Header("フィーバー状態の攻撃力アップの増加率")]
    [SerializeField] float powerUp_GrowthRate = 1f;//フィーバー状態の攻撃力アップの増加率
    private float currentPowerUp_GrowthRate = 1f;//現在のフィーバー状態の攻撃力アップの増加率
    [Header("フィーバー状態のチャージトリック量アップの増加率")]
    [SerializeField] float chargeTrick_GrowthRate = 1f;//フィーバー状態のチャージトリック量アップの増加率
    private float currentChargeTrick_GrowthRate = 1f;//現在のフィーバー状態のチャージトリック量アップの増加率
    private bool feverNow=false;//今フィーバー状態か

    FEVERPoint player_FeverPoint;

    public float CurrentPowerUp_GrowthRate
    {
        get { return currentPowerUp_GrowthRate; }
    }

    public float CurrentChargeTrick_GrowthRate
    {
        get { return currentChargeTrick_GrowthRate; }
    }

    public bool FeverNow
    {
        get { return feverNow; }
    }

    // Start is called before the first frame update
    void Start()
    {
        feverEffect.SetActive(false);
        remainingFeverTime = 0f;
        currentPowerUp_GrowthRate = 1f;
        currentChargeTrick_GrowthRate = 1f;
        feverNow = false;
        player_FeverPoint = gameObject.GetComponent<FEVERPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeFeverMode();//フィーバー状態に移行

        ManageFeverTime();//フィーバー状態の残り時間を管理

        FeverModeEffect();//フィーバー状態の効果の処理
    }

    //まだフィーバー状態になっていないかつフィーバーポイントが満タンになったらフィーバー状態に移行
    void ChangeFeverMode()
    {
        if (feverNow == false && player_FeverPoint.FeverPoint >= player_FeverPoint.FeverPointMax)
        {
            feverNow = true;
            remainingFeverTime = feverTime;
        }
    }

    //フィーバー状態の残り時間を管理
    void ManageFeverTime()
    {
        remainingFeverTime -= Time.deltaTime;

        if(remainingFeverTime<=0f)//フィーバー状態の残り時間が0になったらフィーバー状態を解除
        {
            remainingFeverTime=0f;
            feverNow = false;
        }
    }

    //フィーバー状態の効果の処理
    void FeverModeEffect()
    {
        //フィーバー状態中は...
        //攻撃力とチャージトリック量がアップする
        //エフェクトが付く
        //フィーバーポイントが時間ごとに減っていく(フィーバー状態の残り時間を表している)
        if (feverNow)
        {
            currentPowerUp_GrowthRate = powerUp_GrowthRate;
            currentChargeTrick_GrowthRate=chargeTrick_GrowthRate;
            feverEffect.SetActive(true);
            float ratio = remainingFeverTime / feverTime;
            player_FeverPoint.FeverPoint = player_FeverPoint.FeverPointMax * ratio;
        }
        //フィーバー状態じゃない時は　
        //攻撃力とチャージトリック量が通常
        //エフェクトが非表示
        else
        {
            currentPowerUp_GrowthRate = 1f;
            currentChargeTrick_GrowthRate = 1f;
            feverEffect.SetActive(false);
        }    
    }
}
