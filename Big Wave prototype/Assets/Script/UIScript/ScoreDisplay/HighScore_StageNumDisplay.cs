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
    [Header("クリア回数を表示するテキスト")]
    [SerializeField] TMP_Text _clearCountScoreText;
    [Header("最速クリア時間を表示するテキスト")]
    [SerializeField] TMP_Text _highClearTimeText;

    public void Display(int stageID)
    {
        DisplayHighScore(stageID);
        DisplayClearCount(stageID);
    }

    void DisplayHighScore(int stageID)//ハイスコアの表示
    {
        float highScore = SaveData.GetHighScore(stageID);

        _highScoreText.text = highScore.ToString("0");
    }

    void DisplayClearCount(int stageID)//クリア回数の表示
    {
        int clearCount=SaveData.GetClearCount(stageID);

        _clearCountScoreText.text = clearCount.ToString("0");
    }

    void DisplayHighClearCount(int stageID)
    {

    }
}
