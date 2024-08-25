using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class InstantiateEffect:MonoBehaviour
{
    [Header("エフェクトのオブジェクト")]
    [SerializeField] GameObject effect;//エフェクトのオブジェクト
    [Header("エフェクトの生成位置")]
    [SerializeField] Transform instantiatePos;//エフェクトの生成位置
    [Header("子オブジェクトとして生成するか")]
    [SerializeField] bool instantiateInOtherObject;//子オブジェクトとして生成するか
    [Header("生成時の親オブジェクト")]
    [SerializeField] GameObject parent;//生成時の親オブジェクト
    private float delayTime;//遅延時間
    private float currentDelayTime;//現在の遅延時間
    private bool instantiated=true;//エフェクトを出したか

    public void Instantiate(float delay)//エフェクトを呼び出したいタイミングで呼び出す、引数のdelayには遅延させたい時間を入れる。
    {
        delayTime = delay;//遅延時間の設定
        currentDelayTime = 0;//現在の遅延時間のリセット
        instantiated = false;//エフェクトを出したかをリセット
    }

    void Update()
    {
        currentDelayTime += Time.deltaTime;

        if (!instantiated&&currentDelayTime>=delayTime)//まだエフェクトを置いていないかつ現在の遅延時間が設定された遅延時間に達した。 
        {
            instantiated = true;//エフェクトを出した。

            if(instantiateInOtherObject)//子オブジェクトとして生成するなら
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
