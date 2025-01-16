using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーの水しぶきの動き
//ジャンプ時は消すようにする
public class WaterSplashEffect_Player : MonoBehaviour
{
    [SerializeField] JudgeJumpNow _judgeJumpNow;
    [Header("水しぶきのエフェクト")]
    [SerializeField] GameObject _waterSplashEffect;

    private void OnEnable()
    {
        _judgeJumpNow.SwitchJumpNowAction += Effect;
    }

    private void OnDisable()
    {
        _judgeJumpNow.SwitchJumpNowAction -= Effect;
        _waterSplashEffect.SetActive(false);//水しぶきを非表示に
    }

    void Effect(bool switchJumpNow)
    {
        _waterSplashEffect.SetActive(!switchJumpNow);//水しぶきをジャンプ開始時に消す、着地時に出す
    }
}
