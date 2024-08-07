using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct ButtonDisplays
{
    [Header("表示したいボタンの要素番号")]
    [Tooltip("現在指定されているボタンを表示したいなら0、二番目に指定されているボタンなら1...")]
    [SerializeField] internal int buttonNum;//表示したいボタンの要素番号
    [Header("表示されるボタン")]
    [SerializeField] internal CriticalButtonDisplay criticalButtonDisplay;//表示されるボタン
}

public class ChasePlayerButton : MonoBehaviour
{
    [SerializeField] ButtonDisplays[] buttonDisplays;
    JumpControl jumpControl;
    TRICKPoint player_TrickPoint;
    // Start is called before the first frame update
    void Start()
    {

        jumpControl = GameObject.FindWithTag("Player").GetComponent<JumpControl>();
        player_TrickPoint = GameObject.FindWithTag("Player").GetComponent<TRICKPoint>();
        AssignButtonNum();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAndHideButton();
    }

    void DisplayAndHideButton()//ボタン表示と非表示
    {
        if (jumpControl.JumpNow && player_TrickPoint.MaxCount > 0)//ジャンプしている時かつ満タンのトリックゲージの数が1本以上あるとき
        {
            for(int i=0; i<buttonDisplays.Length;i++)
            {
                buttonDisplays[i].criticalButtonDisplay.DisplayButton();
            }
        }
        else
        {
            for (int i = 0; i < buttonDisplays.Length; i++)
            {
                buttonDisplays[i].criticalButtonDisplay.HideButton();
            }
        }
            
    }

    void AssignButtonNum()//設定した全てのボタンに表示したいボタンの要素番号の割り当て
    {
        for (int i = 0; i < buttonDisplays.Length; i++)
        {
            buttonDisplays[i].criticalButtonDisplay.CriticalButtonNum = buttonDisplays[i].buttonNum;//表示したいボタンの要素番号の割り当て
        }
    }
}
