using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者:杉山
//ジャンプ力をUIで表示
public class JumpPowerDisplay : MonoBehaviour
{
    [Header("ジャンプ力ゲージ(非チャージ時に隠す部分)")]
    [SerializeField] GameObject main_jumpPowerGauge;//ジャンプ力ゲージ(非チャージ時に隠す部分)
    [Header("ジャンプ力ゲージ可変部分")]
    [SerializeField] Image jumpPowerGauge;//ジャンプ力ゲージ可変部分
    [Header("ジャンプ力")]
    [SerializeField] JumpPower jumpPower;

    void Update()
    {
        Display();
        JumpPowerGauge();
    }

    void JumpPowerGauge()//ジャンプ力ゲージの処理
    {
        if (!main_jumpPowerGauge.activeSelf) return;//ジャンプ力ゲージが非表示の時は以下の処理をしない

        float ratio = jumpPower.Ratio;
        jumpPowerGauge.fillAmount = ratio;
    }

    void Display()//チャージ中のみ表示させる
    {
        main_jumpPowerGauge.SetActive(jumpPower.ChargeNow);
    }
}
