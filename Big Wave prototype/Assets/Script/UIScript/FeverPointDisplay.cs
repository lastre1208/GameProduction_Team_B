using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeverPointDisplay : MonoBehaviour
{
    [Header("▼プレイヤーのフィーバーゲージ")]
    [SerializeField] GameObject feverGaugeOfPlayer;//プレイヤーのフィーバーゲージ
    [Header("▼通常状態のフィーバーゲージの色")]
    [SerializeField] Color feverGaugeNormalColor;//通常状態のフィーバーゲージの色
    [Header("▼フィーバー状態のフィーバーゲージの色")]
    [SerializeField] Color feverGaugeFeverModeColor;//フィーバー状態のフィーバーゲージの色

    FEVERPoint player_FeverPoint;
    ProcessFeverMode processFeverPoint;
    // Start is called before the first frame update
    void Start()
    {
        player_FeverPoint = GameObject.FindWithTag("Player").GetComponent<FEVERPoint>();
        processFeverPoint = GameObject.FindWithTag("Player").GetComponent<ProcessFeverMode>();
    }

    // Update is called once per frame
    void Update()
    {
        FeverGaugeOfPlayer();//プレイヤーのフィーバーゲージの処理
    }

    void FeverGaugeOfPlayer()//プレイヤーのフィーバーゲージの処理
    {
        float feverRatio = player_FeverPoint.FeverPoint / player_FeverPoint.FeverPointMax;
        feverGaugeOfPlayer.GetComponent<Image>().fillAmount = feverRatio;
        //ゲージの色の変更
        if (processFeverPoint.FeverNow)//フィーバー状態の時
        {
            feverGaugeOfPlayer.GetComponent<Image>().color = feverGaugeFeverModeColor;
        }
        else//通常時
        {
            feverGaugeOfPlayer.GetComponent<Image>().color = feverGaugeNormalColor;
        }
    }
}
