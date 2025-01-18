using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//チャージ中はずっと出すエフェクト
public class ChargeTrickEffect_WhileCharge : MonoBehaviour
{
    [Header("チャージ判定")]
    [SerializeField] JudgeChargeTrickPointNow _judgeChargeTrickPointNow;
    [Header("チャージエフェクト")]
    [SerializeField] GameObject _chargeEffect;
    [Header("チャージの効果音")]
    [SerializeField] AudioClip _chargeSE;
    [SerializeField] AudioSource _audioSource;
    bool _switch = true;//これがfalseの時はチャージ状態になってもエフェクトを出さなくなる

    public bool Switch
    {
        get { return _switch; }
        set { _switch = value; }
    }

    void Start()
    {
        _judgeChargeTrickPointNow.SwitchChargeAction += Effect;
    }

    void Update()
    {
        if(!_switch)
        {
            _chargeEffect.SetActive(false);
        }
    }

    void Effect(bool chargeNow)
    {
        _chargeEffect.SetActive(_switch ? chargeNow:false);//エフェクトの表示・非表示

        if (!_switch) return;

        if(chargeNow)
        {
            _audioSource.PlayOneShot(_chargeSE);//効果音を鳴らす
        }
    }
}
