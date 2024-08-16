using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTrickCombo : MonoBehaviour
{
    [Header("何秒経ったらコンボ回数をリセットするか")]
    [SerializeField] float resetTime;//何秒経ったらコンボ回数をリセットするか
    [Header("トリックのコンボ回数のスコア")]
    [SerializeField] Score_TrickCombo score_TrickCombo;//トリックのコンボ回数のスコア
    private float currentResetTime=0;//最後にトリックをしてから経った時間、ResetTimeになったらコンボ回数をリセット
    private int comboCount = 0;//コンボ回数
    private bool comboContinue = false;//コンボが続いているか

    public int ComboCount
    {
        get { return comboCount; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateResetTime();
    }

    public void AddCombo()//トリックをしたときにコンボ回数を増やす
    {
        comboCount++;
        comboContinue = true;//コンボが発生
        currentResetTime = 0;//最後にトリックをしてからの時間をリセット
    }

    void UpdateResetTime()//コンボのリセット時間の更新処理
    {
        currentResetTime += Time.deltaTime;

        //コンボが途切れたばかりでかつ最後にトリックをしてからresetTime秒、時間が経ったときtrue(リセット処理をする)
        bool reset = (comboContinue && currentResetTime >= resetTime);//コンボ回数をリセットするか

        if (reset)
        {
            ResetProcess();
        }
    }

    void ResetProcess()//リセット処理
    {
        score_TrickCombo.AddScore(comboCount);//コンボ回数分スコアを増やす
        comboContinue = false;//コンボが途切れた
        comboCount = 0; //コンボ回数をリセット
    }
}
