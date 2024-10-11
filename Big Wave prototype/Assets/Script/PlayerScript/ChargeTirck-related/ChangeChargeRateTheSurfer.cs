using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//波に乗るほどチャージ倍率が上がっていく
public class ChangeChargeRateTheSurfer : MonoBehaviour
{
    [Header("最大までたまりやすくなった時の倍率(最大倍率)")]
    [SerializeField] float chargeRateMax = 3;//最大倍率
    [Header("最大倍率になるまでにかかる時間")]
    [SerializeField] float byMaxRateTime = 10;//最大倍率になるまでにかかる時間
    [Header("倍率が減る速度(倍率が増える時の速度を1として)")]
    [SerializeField] float minusChargeRateSpeed;//波に触れてないかつジャンプしていない時に倍率が減る速度
    [Header("必要なコンポーネント")]
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] JudgeTouchWave judgeTouchWave;

    private const float normalChargeRate = 1;//等倍
    private float currentChargeRate = normalChargeRate;//現在の倍率
    private float changeRatePerSecond;//1秒ごとに増える倍率量
    

    public float ChargeRateMax//最大チャージ倍率
    {
        get { return chargeRateMax; }
    }

    public float NormalChargeRate//等倍(初期状態)のチャージ倍率
    {
        get { return normalChargeRate; }
    }

    public float ChargeRate()//現在のチャージ倍率を返す
    {
        return currentChargeRate;
    }

    // Start is called before the first frame update
    void Start()
    {
        changeRatePerSecond = (chargeRateMax - normalChargeRate) / byMaxRateTime;//1秒ごとに増える倍率量を設定
    }

    // Update is called once per frame
    void Update()
    {
        ChangeChargeRate();
    }

    //チャージ倍率を変化させる
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

    bool ChangeChargeRateNow()//現在チャージ倍率が変化しているか
    {
        //現在ジャンプしているもしくは波に触れているとき、チャージ倍率が変化する
        bool chargeRateNow = (judgeJumpNow.JumpNow() || judgeTouchWave.TouchWaveNow);
        return chargeRateNow;
    }
}
