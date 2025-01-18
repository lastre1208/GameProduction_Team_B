using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//作成者:杉山
//ハイスコアが出たら演出を出す(現在は文字を出すだけ)
public class HighScoreEffect : MonoBehaviour
{
    [SerializeField] SaveHighScore _saveHighScore;
    [Header("ハイスコア時に表示するテキスト")]
    [SerializeField] TMP_Text _highScoreText;

    private void Awake()
    {
        _saveHighScore.Action_HighScore += Display;
    }

    public void Display(bool updated)
    {
        _highScoreText.enabled = updated;
    }
}
