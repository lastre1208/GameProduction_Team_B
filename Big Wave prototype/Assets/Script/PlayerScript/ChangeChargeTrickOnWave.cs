using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChargeTrickOnWave : MonoBehaviour
{
    [Header("最大までたまりやすくなった時の倍率(最大倍率)")]
    [SerializeField] float chargeRateMax=1;//最大倍率
    [Header("最大倍率になるまでにかかる時間")]
    [SerializeField] float byRateMaxTime=10;//最大倍率になるまでにかかる時間
    [Header("チャージ時のエフェクト")]
    [SerializeField] GameObject chargeEffect;//チャージ時のエフェクト
    [Header("最大倍率時のチャージ時のエフェクトの大きさ")]
    [SerializeField] float maxScale;//チャージ時のエフェクト
    private float currentChargeRate=1f;//現在の倍率
    private bool changeChargeRateNow=false;//倍率が今変化しているか
    private float curremtChangeChargeRateTime=0;//倍率が変化している時間
    private Vector3 normalScale;
    private Vector3 currentScale;

    JumpControl jumpControl;
    JudgeTouchWave judgeTouchWave;

    public float CurrentChargeRate
    {
        get { return currentChargeRate; }
    }

    public float ChargeRateMax
    {
        get { return chargeRateMax; }
    }


    // Start is called before the first frame update
    void Start()
    {
        jumpControl = GetComponent<JumpControl>();
        judgeTouchWave = GetComponent<JudgeTouchWave>();
        normalScale=chargeEffect.transform.localScale;
        currentScale = normalScale;
    }

    // Update is called once per frame
    void Update()
    {
        Method1();
        Method2();
    }

    void Method1()//波に触れているかジャンプしている時に倍率が変化するようにする
    {
        if(jumpControl.JumpNow||judgeTouchWave.TouchWaveNow)
        {
            changeChargeRateNow = true; 
        }
        else
        {
            changeChargeRateNow = false;
        }
    }

    void Method2()
    {
        //波に触れているかジャンプしている時、byRateMaxTimeかけて倍率が1倍からchargeRateMax倍まで変化する
        if (changeChargeRateNow)
        {
            curremtChangeChargeRateTime += Time.deltaTime;
            curremtChangeChargeRateTime = Mathf.Clamp(curremtChangeChargeRateTime, 0, byRateMaxTime);

            currentChargeRate = 1 + (chargeRateMax - 1) / byRateMaxTime * curremtChangeChargeRateTime;
            currentChargeRate = Mathf.Clamp(currentChargeRate,1,chargeRateMax);
            
            //エフェクトの大きさを変更
            float effectScale=normalScale.x+(maxScale-normalScale.x)/byRateMaxTime* curremtChangeChargeRateTime;
            currentScale = new Vector3(effectScale,effectScale,effectScale);

            chargeEffect.transform.localScale = currentScale;
        }
        //そうでない時、倍率が等倍に戻る
        else
        {
            curremtChangeChargeRateTime = 0;
            currentChargeRate = 1f;
            //エフェクトの大きさをもとの大きさに
            currentScale = normalScale;
        }
    }
}
