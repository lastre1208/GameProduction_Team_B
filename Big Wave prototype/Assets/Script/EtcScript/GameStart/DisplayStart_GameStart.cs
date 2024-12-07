using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//作成者:杉山詩恩
//ゲームスタート時のスタートの瞬間の演出
public class DisplayStart_GameStart : MonoBehaviour
{
    [Header("効果音の設定")]
    [SerializeField] DelayPlaySound _sound;
    [Header("文字の設定")]
    [SerializeField] DisplayHideText _text;
    bool displayStart = false;//スタートの文字を表示するフラグ

    void Update()
    {
        DisplayGameStart();
    }

    public void DisplayTrigger()//ゲーム開始した瞬間に一度だけ呼ばれる処理
    {
        displayStart = true;//フラグをONにする
    }

    void DisplayGameStart()//ゲームが開始してからしばらくゲームスタートの文字を画面に表示する
    {
        if (!displayStart) return;//スタートの文字を表示しない間は無視

        _sound.Update();
        _text.Update();
    }
}
