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

    [Header("攻撃力アップのバフ")]
    [SerializeField] PowerUpBuff powerUpBuff;//攻撃力アップのバフ
    [Header("チャージトリック量アップのバフ")]
    [SerializeField] ChargeTrickBuff chargeTrickBuff;//攻撃力アップのバフ

    //[Header("フィーバー状態の攻撃力アップの増加率")]
    //[SerializeField] float powerUp_GrowthRate = 1f;//フィーバー状態の攻撃力アップの増加率
    //private float currentPowerUp_GrowthRate = 1f;//現在のフィーバー状態の攻撃力アップの増加率
    //[Header("フィーバー状態のチャージトリック量アップの増加率")]
    //[SerializeField] float chargeTrick_GrowthRate = 1f;//フィーバー状態のチャージトリック量アップの増加率
    //private float currentChargeTrick_GrowthRate = 1f;//現在のフィーバー状態のチャージトリック量アップの増加率
    private bool feverNow=false;//今フィーバー状態か

    FeverPoint player_FeverPoint;

    public float CurrentPowerUp_GrowthRate
    {
        get { return powerUpBuff.CurrentPowerUp_GrowthRate; }
    }

    public float CurrentChargeTrick_GrowthRate
    {
        get { return chargeTrickBuff.CurrentChargeTrick_GrowthRate; }
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
        feverNow = false;
        player_FeverPoint = gameObject.GetComponent<FeverPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeFeverMode();//フィーバー状態に移行

        UpdateFeverTime();//フィーバー状態の残り時間を管理

        FeverModeEffect();//フィーバー状態の効果の処理
    }

    //まだフィーバー状態になっていないかつフィーバーポイントが満タンになったらフィーバー状態に移行
    void ChangeFeverMode()
    {
        if (feverNow == false && player_FeverPoint.FeverPoint_ >= player_FeverPoint.FeverPointMax)
        {
            feverNow = true;
            remainingFeverTime = feverTime;
        }
    }

    //フィーバー状態の残り時間を更新
    void UpdateFeverTime()
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
            float ratio = remainingFeverTime / feverTime;
            player_FeverPoint.FeverPoint_ = player_FeverPoint.FeverPointMax * ratio;
        }

        powerUpBuff.ChangePowerUpGrowthRate(feverNow);//フィーバー時攻撃力が上がる
        chargeTrickBuff.ChangeChargeTrickGrowthRate(feverNow);//フィーバー時チャージトリック量が上がる
        feverEffect.SetActive(feverNow);//フィーバー時エフェクトを表示
    }



    /////内部クラス/////

    [System.Serializable]
    class PowerUpBuff
    {
        [Header("フィーバー状態の攻撃力アップの増加率")]
        [SerializeField] float powerUp_GrowthRate = 1f;//フィーバー状態の攻撃力アップの増加率
        private float currentPowerUp_GrowthRate = 1f;//現在のフィーバー状態の攻撃力アップの増加率

        public float CurrentPowerUp_GrowthRate
        {
            get { return currentPowerUp_GrowthRate; }
        }

        public void ChangePowerUpGrowthRate(bool feverNow)//攻撃力アップの増加率を変化させる
        {
            if(feverNow)//フィーバー中
            {
                currentPowerUp_GrowthRate = powerUp_GrowthRate;
            }
            else
            {
                currentPowerUp_GrowthRate = 1f;
            }
        }
    }

    [System.Serializable]
    class ChargeTrickBuff
    {
        [Header("フィーバー状態のチャージトリック量アップの増加率")]
        [SerializeField] float chargeTrick_GrowthRate = 1f;//フィーバー状態のチャージトリック量アップの増加率
        private float currentChargeTrick_GrowthRate = 1f;//現在のフィーバー状態のチャージトリック量アップの増加率

        public float CurrentChargeTrick_GrowthRate
        {
            get { return currentChargeTrick_GrowthRate; }
        }

        public void ChangeChargeTrickGrowthRate(bool feverNow)//チャージトリック量アップの増加率を変化させる
        {
            if (feverNow)//フィーバー中
            {
                currentChargeTrick_GrowthRate = chargeTrick_GrowthRate;
            }
            else
            {
                currentChargeTrick_GrowthRate = 1f;
            }
        }
    }
}
