using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//行動時にエフェクトを出すコンポネントのエフェクトの設定項目
[System.Serializable]
public class Effects_GenerateEffect_Action
{
    [Header("遅延時間")]
    [SerializeField] float _delayTime;//遅延時間
    [Header("エフェクト")]
    [SerializeField] GameObject _effect;//エフェクト
    [Header("エフェクト生成位置")]
    [SerializeField] Transform _effectPos;//エフェクト生成位置
    bool _effected;//エフェクトを出したか

    public float DelayTime { get { return _delayTime; } }//遅延時間
    public GameObject Effect { get { return _effect; } }//エフェクト
    public Transform EffectPos { get { return _effectPos; } }//エフェクト生成位置
    public bool Effected//エフェクトを出したか
    {
        get { return _effected; }
        set { _effected = value; }
    }
}
