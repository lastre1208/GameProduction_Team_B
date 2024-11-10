using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//作成者:杉山
//ゲーム中のチャージ時間のスコアを表示
public class ChargeTimeScoreDisplay : MonoBehaviour
{
    [Header("スコア表示する文字")]
    [SerializeField] TMP_Text m_scoreText;
    [Header("チャージ時間のスコアを計測するコンポーネント")]
    [SerializeField] ScoreGameScene_ChargeTime score_ChargeTime;

    void Update()
    {
        Display();
    }

    void Display()//表示する
    {
        m_scoreText.text=score_ChargeTime.Score.ToString("0");
    }
}
