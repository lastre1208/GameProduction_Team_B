using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//作成者:杉山
//クリアタイムの表示
public class ClearTimeDisplay : MonoBehaviour
{
    [Header("00:00:00(分:秒:0.秒)の形式で表示")]
    [Header("クリアタイムを表示するテキスト")]
    [SerializeField] TMP_Text _clearTimeText;//クリアタイムを表示するテキスト
    [SerializeField] Score_TimeLimit _score_timeLimit;//クリアタイムを取得するためのコンポーネント
    const float _seconds_1minute=60;//1分を秒に直したときの値
    const int _displayDigit_BelowPoint = 2;//0.秒の表示する(小数第一位から)桁数

    void Update()
    {
        Display();
    }

    void Display()
    {
        float clearTime = _score_timeLimit.ClearTime;//クリアタイムを取得

        int minute = (int)(clearTime / _seconds_1minute);//分
        int second = (int)(clearTime % _seconds_1minute);//秒

        string text_minute = minute.ToString("00");//テキストに書く分の部分
        string text_second = second.ToString("00");//テキストに書く秒の部分

        string str_clearTime = clearTime.ToString("F" + _displayDigit_BelowPoint.ToString());
        string text_pointSecond = str_clearTime.Split('.')[_displayDigit_BelowPoint - 1];//テキストに書く0.秒の部分

        _clearTimeText.text = text_minute + ":" + text_second + ":" + text_pointSecond;//テキスト更新
    }
}
