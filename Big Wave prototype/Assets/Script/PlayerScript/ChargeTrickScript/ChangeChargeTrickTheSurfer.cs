using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

//☆作成者:杉山
//波に乗るほどトリックのチャージ量が変化する
public class ChangeChargeTrickTheSurfer : MonoBehaviour
{
    [Header("最大までたまりやすくなった時の倍率(最大倍率)")]
    [SerializeField] float chargeRateMax=1;//最大倍率
    [Header("最大倍率になるまでにかかる時間")]
    [SerializeField] float byMaxRateTime=10;//最大倍率になるまでにかかる時間
    [Header("倍率が減る速度(倍率が増える時の速度を1として)")]
    [SerializeField] float minusChargeRateSpeed;//波に触れてないかつジャンプしていない時に倍率が減る速度
    private const float normalChargeRate = 1;//等倍
    private float currentChargeRate = normalChargeRate;//現在の倍率
    private float changeRatePerSecond;//1秒ごとに増える倍率量

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

    public float NormalChargeRate
    {
        get { return normalChargeRate; }
    }

    // Start is called before the first frame update
    void Start()
    {
        jumpControl = GetComponent<JumpControl>();
        judgeTouchWave = GetComponent<JudgeTouchWave>();

        changeRatePerSecond = (chargeRateMax - normalChargeRate) / byMaxRateTime;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeChargeRate();
    }

    bool ChangeChargeRateNow()//波に触れているかジャンプしている時に倍率が変化するようにする
    {
        if(jumpControl.JumpNow||judgeTouchWave.TouchWaveNow)
        {
            return true; 
        }
       
        return false;
    }

    void ChangeChargeRate()
    {
        //波に触れているかジャンプしている時、byRateMaxTimeかけてだんだん倍率が1倍からchargeRateMax倍まで変化する
        if (ChangeChargeRateNow())
        {
            currentChargeRate += changeRatePerSecond * Time.deltaTime;//1フレームごとに増える倍率量
        }
        //そうでない時、倍率が時間ごとに減っていく
        else
        {
            currentChargeRate -= minusChargeRateSpeed * changeRatePerSecond * Time.deltaTime;//1フレームごとに減る倍率量
        }

        currentChargeRate = Mathf.Clamp(currentChargeRate, 1, chargeRateMax);
    }
}
