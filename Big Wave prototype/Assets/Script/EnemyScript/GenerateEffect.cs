using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class GenerateEffect:MonoBehaviour
{
    [Header("エフェクト")]
    [SerializeField] GameObject effect;//エフェクト(のプレハブ)
    [Header("エフェクトの生成位置")]
    [SerializeField] Transform instantiatePos;//エフェクトの生成位置
    [Header("子オブジェクトとして生成するか")]
    [SerializeField] bool instantiateInOtherObject;//子オブジェクトとして生成するか
    [Header("生成時の親オブジェクト")]
    [SerializeField] GameObject parent;//生成時の親オブジェクト
    private float m_delayTime;//遅延時間
    private float currentDelayTime;//現在の遅延時間
    private bool instantiated=true;//エフェクトを出したか

    public void Generate(float delayTime)//エフェクトを呼び出したいタイミングで呼び出す、引数のdelayTimeには遅延させたい時間を入れる。
    {
        if(delayTime<0) delayTime = 0;//もし0未満の値が入力されていたら自動的に0(秒)にする
        m_delayTime = delayTime;//遅延時間の設定
        currentDelayTime = 0;//現在の遅延時間のリセット
        instantiated = false;//エフェクトを出したかをリセット
    }

    void Update()
    {
        UpdateCurrentDelayTime();

        DelayGenerate();
    }

    void UpdateCurrentDelayTime()//現在の遅延時間の更新
    {
        currentDelayTime += Time.deltaTime;
    }

    void DelayGenerate()//遅延時間分遅延させて生成
    {
        if (!instantiated && currentDelayTime >= m_delayTime)//まだエフェクトを置いていないかつ現在の遅延時間が設定された遅延時間に達した。 
        {
            instantiated = true;//エフェクトを出した。

            if (instantiateInOtherObject)//子オブジェクトとして生成するなら
            {
                Instantiate(effect, instantiatePos.transform.position, transform.rotation, parent.transform);//子オブジェクトとしてエフェクトを置く
            }
            else//そうでないなら
            {
                Instantiate(effect, instantiatePos.transform.position, transform.rotation);//直にエフェクトを置く
            }
        }
    }

    

}
