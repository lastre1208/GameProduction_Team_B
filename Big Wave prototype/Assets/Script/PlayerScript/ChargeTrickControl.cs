using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeTrickControl : MonoBehaviour
{
    //☆塩が書いた
    //波の内側に波乗りしているときはoutSideChargeTrick、inSideChargeTrickの合計分トリックが増える
    [SerializeField] float outSideChargeTrick=1;//波の外側に波乗りした時に溜まるトリックの値
    [SerializeField] float inSideChargeTrick=2;//波の内側(中央)に波乗りした時に溜まるトリックの値
    [SerializeField] GameObject chargeSpark;//チャージ用の雷エフェクト
    [HideInInspector] public bool chargeNow=false;//今トリックをチャージしているか
    private float sinceLastChargeTime = 0.1f;//最後にチャージされてからの時間
    private float chargeBorderTime = 0.1f;//チャージしていない・しているの境界の時間
    JudgeTouchWave touchWave;
    Player player;
    Wave wave;
  //コントローラーの接続を確認
    // Start is called before the first frame update
    void Start()
    {
        touchWave = gameObject.GetComponent<JudgeTouchWave>();
        player = gameObject.GetComponent<Player>();
        chargeSpark.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayChargeSpark();//波に触っているかつトリックをチャージしている時のみチャージ用の雷エフェクトを表示

        JudgeChargeNow();//今チャージしているか判定
    }

    //波に触れてトリックをチャージ
    public void ChargeTrickTouchingWave(Collider wavePrefab)
    {
        wave = wavePrefab.GetComponent<Wave>();//Waveの情報(isTouched)を取得

        //一度も触れていない内側の波からチャージする
        if (wavePrefab.CompareTag("InsideWave") && wave.isTouched == false)
        {
            ProcessingChargeTrick(inSideChargeTrick);
        }

        //一度触れていない外側の波からチャージする
        else if (wavePrefab.CompareTag("OutsideWave") && wave.isTouched == false)
        {
            ProcessingChargeTrick(outSideChargeTrick);
        }
    }

    //波に触れてトリックをチャージするときの内部の処理
    //a(引数)にはinSideChargeTrickかoutSideChargeTrickを入れる(溜まるトリック量)
    void ProcessingChargeTrick(float a)
    {
        player.ChargeTRICK(a);//トリックをチャージ
        wave.isTouched = true;//一度触れた波からはチャージできないようにする(触った判定にする)
        sinceLastChargeTime = 0f;//今チャージしている判定にする
    }



    void JudgeChargeNow()//今チャージしているか判定
    {
        sinceLastChargeTime += Time.deltaTime;

        if (sinceLastChargeTime < chargeBorderTime)//最後にチャージしてからchargeBorderTime(秒)未満なら今チャージしてる判定
        {
            chargeNow = true;
        }
        else
        {
            chargeNow = false;
        }
    }



    void DisplayChargeSpark()//波に触っているかつトリックをチャージしている時のみチャージ用の雷エフェクトを表示
    {
        if(chargeNow&&touchWave.touchWaveNow)
        {
            chargeSpark.SetActive(true);
        }
        else
        {
            chargeSpark.SetActive(false);
        }
    }
}
