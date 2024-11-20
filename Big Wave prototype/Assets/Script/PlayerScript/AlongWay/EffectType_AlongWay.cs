using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//作成者:杉山
//ロープを伝うエフェクトの設定
[System.Serializable]
public class EffectType_AlongWay
{
    [Header("伝導時のエフェクト")]
    [SerializeField] GameObject passEffect;//伝導時のエフェクト
    [Header("着弾時のエフェクト")]
    [SerializeField] GameObject landEffect;//着弾時のエフェクト
    public event Action LandAction;//着弾時に呼ぶイベント
    public event Action PassAction;//伝導時に呼ぶイベント
    
    public EffectType_AlongWay()//コンストラクタ
    {
       
    }

    public GameObject PassEffect()//伝導エフェクトを出すときに呼ぶ
    {
        PassAction?.Invoke();
        return passEffect;
    }

    public GameObject LandEffect()//着弾エフェクトを出すときに呼ぶ
    {
        LandAction?.Invoke();
        return landEffect;
    }
}
