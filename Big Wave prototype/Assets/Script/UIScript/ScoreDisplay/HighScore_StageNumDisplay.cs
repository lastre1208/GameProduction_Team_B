using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//作成者:杉山
//指定ステージIDのハイスコアをテキストに出力
public class HighScore_StageNumDisplay : MonoBehaviour
{
    [Header("ハイスコア時に表示するテキスト")]
    [SerializeField] TMP_Text _highScoreText;

    public void Display(int stageID)
    {
        float highScore= SaveData.GetHighScore(stageID);

        _highScoreText.text=highScore.ToString("00000");
    }
}
