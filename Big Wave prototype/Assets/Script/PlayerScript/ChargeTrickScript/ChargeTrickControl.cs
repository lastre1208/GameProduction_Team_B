using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeTrickControl : MonoBehaviour
{
    //☆塩が書いた
    //波の内側に波乗りしているときはoutSideChargeTrick、inSideChargeTrickの合計分トリックが増える
    [Header("チャージ倍率(トリックゲージの個数分配列を用意してください)")]
    [SerializeField] float[] chargeRate;//チャージ倍率
    [Header("波の外側に波乗りした時に溜まるトリックの値")]
    [SerializeField] float outSideChargeTrick=1;//波の外側に波乗りした時に溜まるトリックの値
    [Header("波の内側(中央)に波乗りした時に溜まるトリックの値")]
    [SerializeField] float inSideChargeTrick=2;//波の内側(中央)に波乗りした時に溜まるトリックの値
    Player player;
    BuffOfPlayer buffOfPlayer;
    ProcessFeverMode processFeverPoint;
    ChangeChargeTrick changeChargeTrickOnWave;
    JudgeChargeNow judgeChargeNow;
  
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
        buffOfPlayer = gameObject.GetComponent<BuffOfPlayer>();
        processFeverPoint = gameObject.GetComponent<ProcessFeverMode>();
        changeChargeTrickOnWave=gameObject.GetComponent<ChangeChargeTrick>();
        judgeChargeNow=gameObject.GetComponent<JudgeChargeNow>();
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
        return b * buffOfPlayer.ChargeTrick.CurrentGrowthRate * processFeverPoint.CurrentChargeTrick_GrowthRate * chargeRate[player.MaxCount]*changeChargeTrickOnWave.CurrentChargeRate;
    }

    //波に触れてトリックをチャージするときの内部の処理
    //a(引数)にはinSideChargeTrickかoutSideChargeTrickを入れる(溜まるトリック量)
    void ProcessingChargeTrick(float a,Wave wave)
    {
        if(player.MaxCount!=player.TrickGaugeNum)
        {
            player.ChargeTrickPoint(ChargeTrickAmount(a));//トリックをチャージ
        }
        
        wave.IsTouched = true;//一度触れた波からはチャージできないようにする(触った判定にする)
        judgeChargeNow.ResetSinceLastChargedTime();//最後にチャージされてからの時間をリセット
    }
}





