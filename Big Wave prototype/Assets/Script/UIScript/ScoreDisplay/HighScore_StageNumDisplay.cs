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
    const float _seconds_1minute = 60;//1分を秒に直したときの値
    const int _displayDigit_BelowPoint = 2;//0.秒の表示する(小数第一位から)桁数

    public void Display(int stageID)
    {
        DisplayHighScore(stageID);
        DisplayClearCount(stageID);
        DisplayHighClearTime(stageID);
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

    void DisplayHighClearTime(int stageID)
    {
        float highClearTime=SaveData.GetHighClearTime(stageID);

        int minute = (int)(highClearTime / _seconds_1minute);//分
        int second = (int)(highClearTime % _seconds_1minute);//秒

        string text_minute = minute.ToString("00");//テキストに書く分の部分
        string text_second = second.ToString("00");//テキストに書く秒の部分

        string str_clearTime = highClearTime.ToString("F" + _displayDigit_BelowPoint.ToString());
        string text_pointSecond = str_clearTime.Split('.')[_displayDigit_BelowPoint - 1];//テキストに書く0.秒の部分

        _highClearTimeText.text = text_minute + ":" + text_second + ":" + text_pointSecond;//テキスト更新
    }
}
