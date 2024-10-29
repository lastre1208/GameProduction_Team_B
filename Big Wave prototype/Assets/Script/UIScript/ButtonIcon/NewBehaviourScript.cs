using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
struct ButtonDisplayS
{
    [Header("表示したいボタンの要素番号")]
    [Tooltip("現在指定されているボタンを表示したいなら0、二番目に指定されているボタンなら1...")]
    [SerializeField] internal int buttonNum;//表示したいボタンの要素番号
    [Header("表示されるボタン")]
    [SerializeField] internal ButtonIconDisplay criticalButtonDisplay;//表示されるボタン

}

public class NewBehaviour : MonoBehaviour
{
    [SerializeField] ButtonDisplayS[] buttonDisplays;

    JudgeJumpNow judgeJumpNow;
    TrickPoint player_TrickPoint;
    Critical critical;


    // Start is called before the first frame update
    void Start()
    {
        judgeJumpNow = GameObject.FindWithTag("Player").GetComponent<JudgeJumpNow>();
        player_TrickPoint = GameObject.FindWithTag("Player").GetComponent<TrickPoint>();
        critical = GameObject.FindWithTag("Player").GetComponent<Critical>();


    }

    // Update is called once per frame
    void Update()
    {
        DisplayAndHideButton();
    }




    void DisplayAndHideButton()//ボタン表示と非表示
    {
        for (int i = 0; i < buttonDisplays.Length; i++)
        {
            //ジャンプしている時かつ満タンのトリックゲージの数が表示したいボタンの要素番号より多くあるとき表示
            bool display = (judgeJumpNow.JumpNow() && player_TrickPoint.MaxCount > buttonDisplays[i].buttonNum);

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
}
