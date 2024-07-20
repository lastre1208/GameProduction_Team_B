using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//☆作成者:杉山
//トリックのチャージ関連
public class ChargeTrick : MonoBehaviour
{
    //波の内側に波乗りしているときはoutSideChargeTrick、inSideChargeTrickの合計分トリックが増える
    [Header("波の外側に波乗りした時に溜まるトリックの値")]
    [SerializeField] float outSideChargeTrick=1;//波の外側に波乗りした時に溜まるトリックの値
    [Header("波の内側(中央)に波乗りした時に溜まるトリックの値")]
    [SerializeField] float inSideChargeTrick=2;//波の内側(中央)に波乗りした時に溜まるトリックの値
    JudgeChargeNow judgeChargeNow;
    Player player;
    ProcessFeverMode processFeverPoint;
    ChangeChargeTrickTheSurfer changeChargeTrickTheSurfer;
    ChangeChargeTrickTheCharger changeChargeTrickTheCharger;
  
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
        processFeverPoint = gameObject.GetComponent<ProcessFeverMode>();
        changeChargeTrickTheSurfer=gameObject.GetComponent<ChangeChargeTrickTheSurfer>();
        judgeChargeNow=gameObject.GetComponent<JudgeChargeNow>();
        changeChargeTrickTheCharger=gameObject.GetComponent<ChangeChargeTrickTheCharger>(); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    //波に触れてトリックをチャージ
    public void ChargeTrickTouchingWave(Collider wavePrefab)
    {
        Wave wave = wavePrefab.GetComponent<Wave>();//Waveの情報(isTouched)を取得

        //一度も触れていない内側の波からチャージする
        if (wavePrefab.CompareTag("InsideWave") && wave.IsTouched == false)
        {
            ProcessingChargeTrick(inSideChargeTrick,wave);
        }

        //一度触れていない外側の波からチャージする
        else if (wavePrefab.CompareTag("OutsideWave") && wave.IsTouched == false)
        {
            ProcessingChargeTrick(outSideChargeTrick, wave);
        }
    }

    float ChargeTrickAmount(float b)//チャージされるトリック量(bにはinSideChargeTrickかoutSideChargeTrickが入る)
    {
        float ret=b;
        ret *= processFeverPoint.CurrentChargeTrick_GrowthRate;//フィーバー状態のチャージ倍率
        ret *= changeChargeTrickTheCharger.ChargeRate();//満タンのトリックゲージの数によるチャージ倍率
        ret*= changeChargeTrickTheSurfer.CurrentChargeRate;//波に乗っている時間によるチャージ倍率
        return ret;
    }

    //波に触れてトリックをチャージするときの内部の処理
    //a(引数)にはinSideChargeTrickかoutSideChargeTrickを入れる(溜まるトリック量)
    void ProcessingChargeTrick(float a,Wave wave)
    {
        player.ChargeTrickPoint(ChargeTrickAmount(a));//トリックをチャージ
        wave.IsTouched = true;//一度触れた波からはチャージできないようにする(触った判定にする)
        judgeChargeNow.ResetSinceLastChargedTime();//最後にチャージされてからの時間をリセット
    }
}





