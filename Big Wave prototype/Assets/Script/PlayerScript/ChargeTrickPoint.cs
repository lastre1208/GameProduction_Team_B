using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

//作成者:杉山
//トリックのチャージ
public class ChargeTrickPoint : MonoBehaviour
{
    /////フィールド/////
    [Header("現在トリックをチャージしているかの判定")]
    [SerializeField] JudgeChargeNow judgeChargeNow;//現在トリックをチャージしているかの判定
    [Header("現在のトリック量によりチャージ倍率を変化させる機能")]
    [SerializeField] ChangeChargeRateTheCharger changeChargeRateTheCharger;//現在のトリック量によりチャージ倍率を変化させる
    [Header("波に乗るほどチャージ倍率を変化させる機能")]
    [SerializeField] ChangeChargeRateTheSurfer changeChargeRateTheSurfer;//波に乗るほどチャージ倍率を変化させる
    [Header("チャージ時のみエフェクトを表示する機能")]
    [SerializeField] DisplayChargeTrickEffect displayChargeTrickEffect;//チャージ時のみエフェクトを表示する
    [Header("波に乗るほどチャージ時のエフェクトの大きさが変化する機能")]
    [SerializeField] ChangeChargeTrickEffectTheSurfer changeChargeTrickEffectTheSurfer;//波に乗るほどチャージ時のエフェクトの大きさが変化する

    FeverMode feverMode;
    TrickPoint player_TrickPoint;
    JumpControl jumpControl;
    JudgeTouchWave judgeTouchWave;
    private bool chargeStandby = false;//これがtrueになっている時かつ波に触れている時のみトリックをチャージできる

    /////private(別クラスは使用不可)のメソッド/////
    void Start()
    {
        //別クラスの情報取得
        feverMode = GetComponent<FeverMode>();
        player_TrickPoint=GetComponent<TrickPoint>();
        jumpControl=GetComponent<JumpControl>();
        judgeTouchWave=GetComponent<JudgeTouchWave>();

        //内部クラスの各機能の最初のフレームの処理
        judgeChargeNow.StartSinceLastChargedTime();
        changeChargeRateTheSurfer.StartChangeRatePerSecond();
        displayChargeTrickEffect.StartChargeEffect();
        changeChargeTrickEffectTheSurfer.StartScale();
        changeChargeTrickEffectTheSurfer.StartChargeRate(changeChargeRateTheSurfer.NormalChargeRate,changeChargeRateTheSurfer.ChargeRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        //内部クラスの各機能の毎フレーム処理
        judgeChargeNow.UpdateSinceLastChargedTime();
        changeChargeRateTheSurfer.ChangeChargeRate();
        changeChargeRateTheSurfer.CheckJumpNow_TouchWaveNow(jumpControl.JumpNow(),judgeTouchWave.TouchWaveNow);
        displayChargeTrickEffect.Display(judgeChargeNow.ChargeNow());
        changeChargeTrickEffectTheSurfer.ChangeEffectScale(changeChargeRateTheSurfer.ChargeRate());
    }

    float ChargeTrickAmount(float chargeAmount)//チャージされるトリック量
    {
        float ret = chargeAmount;//通常時のチャージされるトリック量
        ret *= feverMode.CurrentChargeTrick_GrowthRate;//フィーバー状態のチャージ倍率
        ret *= changeChargeRateTheCharger.ChargeRate(player_TrickPoint.MaxCount,player_TrickPoint.TrickGaugeNum);//満タンのトリックゲージの数によるチャージ倍率
        ret *= changeChargeRateTheSurfer.ChargeRate();//波に乗っている時間によるチャージ倍率
        return ret;
    }





    /////public(別クラスも使用可能)のメソッド/////

    public bool ChargeStandby
    {
        get { return chargeStandby; }
        set { chargeStandby = value; }
    }

   
    public void Charge(float chargeAmount)//トリックのチャージ
    {
        if (chargeStandby)
        {
            player_TrickPoint.Charge(ChargeTrickAmount(chargeAmount));//トリックをチャージ
            judgeChargeNow.ResetSinceLastChargedTime();//最後にチャージされてからの時間をリセット
        }
    }

    public bool ChargeNow()//今チャージしているかの判定
    {
        return judgeChargeNow.ChargeNow();
    }







    /////内部クラス/////

    //現在トリックをチャージしているかの判定
    [System.Serializable]
    private class JudgeChargeNow
    {
        [Header("チャージしていない・しているの境界の時間")]
        [SerializeField] float chargedBorderTime = 0.1f;//チャージしていない・しているの境界の時間
        private float sinceLastChargedTime = 0.1f;//最後にチャージされてからの時間

        public void StartSinceLastChargedTime()//最後にチャージされてからの時間の初期化(start)
        {
            sinceLastChargedTime = chargedBorderTime;
        }

        public void UpdateSinceLastChargedTime()//最後にチャージされてからの時間の更新(start)
        {
            sinceLastChargedTime += Time.deltaTime;
        }

        public bool ChargeNow()//今チャージしているか
        {
            if (sinceLastChargedTime < chargedBorderTime)//最後にチャージしてからchargeBorderTime(秒)未満なら今チャージしてる判定
            {
                return true;
            }

            return false;
        }

        public void ResetSinceLastChargedTime()//最後にチャージされてからの時間をリセット
        {
            sinceLastChargedTime = 0;
        }
    }



    //現在のトリック量によりチャージ倍率を変化させる
    [System.Serializable]
    private class ChangeChargeRateTheCharger
    {
        [Header("チャージ倍率(トリックゲージの個数分配列を用意してください)")]
        [SerializeField] float[] chargeRate;//チャージ倍率

        //満タンのゲージの数に対応したチャージ倍率を返す
        //引数のmaxCountにはプレイヤーの満タンのトリックゲージの個数、引数のtrickGaugeNumにはプレイヤーのトリックゲージの個数を入れる
        public float ChargeRate(int maxCount,int trickGaugeNum)
        {
            maxCount = Mathf.Clamp(maxCount, 0, trickGaugeNum - 1);
            return chargeRate[maxCount];
        }
    }



    //波に乗るほどチャージ倍率を変化させる
    [System.Serializable]
    private class ChangeChargeRateTheSurfer
    {
        [Header("最大までたまりやすくなった時の倍率(最大倍率)")]
        [SerializeField] float chargeRateMax = 3;//最大倍率
        [Header("最大倍率になるまでにかかる時間")]
        [SerializeField] float byMaxRateTime = 10;//最大倍率になるまでにかかる時間
        [Header("倍率が減る速度(倍率が増える時の速度を1として)")]
        [SerializeField] float minusChargeRateSpeed;//波に触れてないかつジャンプしていない時に倍率が減る速度
        private const float normalChargeRate = 2;//等倍
        private float currentChargeRate = normalChargeRate;//現在の倍率
        private float changeRatePerSecond;//1秒ごとに増える倍率量
        private bool jumpNow;//現在ジャンプしているか
        private bool touchWaveNow;//現在波に触れているか

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

        public void StartChangeRatePerSecond()//1秒ごとに増える倍率量の初期化(start)
        {
            changeRatePerSecond = (chargeRateMax - normalChargeRate) / byMaxRateTime;//1秒ごとに増える倍率量を設定
        }

        //引数のjNには現在ジャンプしているか、tWNには現在波に触れているかを入れる(update)
        public void CheckJumpNow_TouchWaveNow(bool jN, bool tWN)
        {
            jumpNow = jN;
            touchWaveNow = tWN;
        }

        //チャージ倍率を変化させる(update)
        public void ChangeChargeRate()
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
            bool chargeRateNow = (jumpNow || touchWaveNow);
            return chargeRateNow;
        }
       
    }



    //チャージ時のみエフェクトを表示する
    [System.Serializable]
    private class DisplayChargeTrickEffect
    {
        [Header("チャージ時のエフェクト")]
        [SerializeField] GameObject chargeEffect;//チャージ時のエフェクト

        //チャージ時のエフェクトの初期化(start)
        public void StartChargeEffect()
        {
            chargeEffect.SetActive(false);//ゲーム開始時チャージ時のエフェクトを非表示
        }

        //トリックをチャージしている時のみチャージ時のエフェクトを表示(update)
        public void Display(bool chargeNow)
        {
            chargeEffect.SetActive(chargeNow);
        }
    }



    //波に乗るほどチャージ時のエフェクトの大きさが変化する
    [System.Serializable]
    private class ChangeChargeTrickEffectTheSurfer
    {
        [Header("チャージ時のエフェクト")]
        [SerializeField] GameObject chargeEffect;//チャージ時のエフェクト
        [Header("最大倍率時のチャージ時のエフェクトの大きさ(倍率)")]
        [SerializeField] float maxScaleRate;//最大倍率時のチャージ時のエフェクトの大きさ、初期の大きさから何倍の大きさか
        private Vector3 maxScale;//最大倍率時のエフェクトの大きさ
        private Vector3 normalScale;//通常時(初期)のエフェクトの大きさ
        private Vector3 currentScale;//現在のエフェクトの大きさ
        private float normalChargeRate;//等倍(初期状態)の波に乗ることによって変化するチャージ倍率
        private float chargeRateMax;//最大の波に乗ることによって変化するチャージ倍率

        //通常時、現在、最大時の大きさの値の初期化(start)
        public void StartScale()
        {
            normalScale = chargeEffect.transform.localScale;
            maxScale = normalScale * maxScaleRate;
            currentScale = normalScale;
        }

        //等倍(初期状態)、最大時の波に乗ることによって変化するチャージ倍率の初期化(start)
        public void StartChargeRate(float normal,float max)//引数のnormalには等倍(初期状態)、maxには最大時の波に乗ることによって変化するチャージ倍率を入れる
        {
            normalChargeRate = normal;
            chargeRateMax = max;
        }


        //エフェクトの大きさを現在の波に乗ることによって変化するチャージ倍率にあわせて変更(update)
        public void ChangeEffectScale(float currentChargeRate)//引数のcurrentChargeRateには現在の波に乗ることによって変化するチャージ倍率を入れる
        {
            if (chargeEffect.activeSelf)//チャージエフェクトがアクティブの時にエフェクトの大きさを変更
            {
                float current = currentChargeRate - normalChargeRate;//現在の倍率から通常の倍率(1)を引いたもの
                float max = chargeRateMax - normalChargeRate;//最大倍率から通常の倍率(1)を引いたもの
                float ratio = current / max;

                //エフェクトの現在の大きさの値を変更
                currentScale = normalScale + (maxScale - normalScale) * ratio;

                //現在の大きさをエフェクトの大きさに適用
                chargeEffect.transform.localScale = currentScale;
            }
        }
    }
}
