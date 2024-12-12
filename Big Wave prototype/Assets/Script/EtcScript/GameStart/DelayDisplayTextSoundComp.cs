using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//作成者:杉山
//遅延して音と文字を出すコンポーネント
public class DelayDisplayTextSoundComp : MonoBehaviour
{
    [Header("効果音の設定")]
    [SerializeField] DelayPlaySound[] _sound;
    [Header("文字の設定")]
    [SerializeField] DelayDisplayText[] _text;
    bool displayStart = false;//

    void Update()
    {
        UpdateDisplay();
    }

    public void DisplayTrigger()//ゲーム開始した瞬間に一度だけ呼ばれる処理
    {
        displayStart = true;//フラグをONにする
        Debug.Log(name);
    }

    void UpdateDisplay()//ゲームが開始してからしばらくゲームスタートの文字を画面に表示する
    {
        if (!displayStart) return;//スタートの文字を表示しない間は無視

        for(int i=0;i<_sound.Length;i++)
        {
            _sound[i].Update();
        }

        for(int i=0;i<_text.Length;i++)
        {
            _text[i].Update();
        }
        
    }
}
