using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeverPointDisplay : MonoBehaviour
{
    [Header("▼プレイヤーのフィーバーゲージ")]
    [SerializeField] Image feverGaugeOfPlayer;//プレイヤーのフィーバーゲージ
    [Header("▼通常状態のフィーバーゲージの色")]
    [SerializeField] Color feverGaugeNormalColor;//通常状態のフィーバーゲージの色
    [Header("▼フィーバー状態のフィーバーゲージの色")]
    [SerializeField] Color feverGaugeFeverModeColor;//フィーバー状態のフィーバーゲージの色
    [Header("プレイヤーのフィーバーポイント")]
    [SerializeField] FeverPoint player_FeverPoint;
    [Header("フィーバーモードのコンポーネント")]
    [SerializeField] FeverMode processFeverPoint;

    void Update()
    {
        FeverGaugeOfPlayer();//プレイヤーのフィーバーゲージの処理
    }

    void FeverGaugeOfPlayer()//プレイヤーのフィーバーゲージの処理
    {
        float feverRatio = player_FeverPoint.FeverPoint_ / player_FeverPoint.FeverPointMax;
        feverGaugeOfPlayer.fillAmount = feverRatio;
        //ゲージの色の変更
        feverGaugeOfPlayer.color = processFeverPoint.FeverNow ? feverGaugeFeverModeColor : feverGaugeNormalColor;
    }
}
