using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessFeverPoint : MonoBehaviour
{
    [Header("回数ごとの溜まるフィーバーポイントの値")]
    [Header("注意:トリックゲージの個数分配列を用意してください")]
    [SerializeField] float[] chargeFeverPoint;//回数ごとの溜まるフィーバーポイントの値
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
    [SerializeField] bool feverNow=false;//今フィーバー状態か

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        feverEffect.SetActive(false);
        remainingFeverTime = 0f;
        currentPowerUp_GrowthRate = 1f;
        currentChargeTrick_GrowthRate = 1f;
        feverNow = false;
        player = gameObject.AddComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Method1();

        Method2();

        Method3();
    }

    //フィーバー状態でない時フィーバーポイント加算(トリックするごとに加算するようにする)、countは1回のジャンプ中のトリック回数
    public void ChargeFeverPoint(int count)
    {
        if (feverNow == false)
        {
            player.FeverPoint += chargeFeverPoint[count-1];
        }
    }

    //まだフィーバー状態になっていないかつフィーバーポイントが満タンになったらフィーバー状態に移行
    void Method1()
    {
        if(feverNow==false&&player.FeverPoint>=player.FeverPointMax)
        {
            feverNow = true;
            remainingFeverTime = feverTime;
        }
    }

    //フィーバー状態の残り時間を管理
    void Method2()
    {
        remainingFeverTime -= Time.deltaTime;

        if(remainingFeverTime<=0f)//フィーバー状態の残り時間が0になったらフィーバー状態を解除
        {
            remainingFeverTime=0f;
            feverNow = false;
        }
    }

    void Method3()
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
            player.FeverPoint=player.FeverPointMax*ratio;
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
