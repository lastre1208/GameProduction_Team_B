using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者:杉山
//ジャンプ力をUIで表示
public class JumpPowerDisplay : MonoBehaviour
{
    [Header("ジャンプ力ゲージ")]
    [SerializeField] Image jumpPowerGauge;//ジャンプ力ゲージ
    [Header("ジャンプ力")]
    [SerializeField] JumpPower jumpPower;

    void Update()
    {
        JumpPowerGauge();
    }

    void JumpPowerGauge()//ジャンプ力ゲージの処理
    {
        float ratio = jumpPower.Ratio;
        jumpPowerGauge.fillAmount = ratio;
    }
}
