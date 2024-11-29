using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//画面上にガイドボタンアイコンを表示する
public partial class GuideButtonIconFullScreen : MonoBehaviour
{
    [Header("ボタン表示設定")]
    [SerializeField] ButtonDisplays[] buttonDisplays;
    [Header("表示の遅延時間")]
    [SerializeField] float delay;//表示の遅延時間
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] TrickPoint player_TrickPoint;
    [SerializeField] Critical critical;
    private float elapsedTime = 0f;//経過時間(遅延時間と比較)

    void Update()
    {
        UpdateElapsedTime();
        DisplayAndHideButton();
    }

    void DisplayAndHideButton()//ボタン表示・非表示
    {
        for (int i = 0; i < buttonDisplays.Length; i++)
        {
            //ジャンプしている時かつ、満タンのトリックゲージの数が表示したいボタンの要素番号より多くあるときかつ、指定時間遅延した時表示
            bool display = (judgeJumpNow.JumpNow() && player_TrickPoint.MaxCount > buttonDisplays[i].buttonNum && elapsedTime > delay * i);

            if (display)//表示する時
            {
                buttonDisplays[i].criticalButtonDisplay.DisplayButton(critical.CriticalButton[buttonDisplays[i].buttonNum]);
            }
            else//非表示する時
            {
                buttonDisplays[i].criticalButtonDisplay.HideButton();
            }
        }
    }

    void UpdateElapsedTime()
    {
        if(!judgeJumpNow.JumpNow())//ジャンプしていなかったら0秒にする
        {
            elapsedTime = 0;
            return;
        }

        elapsedTime += Time.deltaTime;
    }
}
