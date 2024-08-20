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
    [SerializeField] internal ButtonIconDisplay criticalButtonDisplay;//表示されるボタン
}

public class ButtonIconChasingPlayer : MonoBehaviour
{
    [SerializeField] ButtonDisplays[] buttonDisplays;
    JumpControl jumpControl;
    TrickPoint player_TrickPoint;
    Critical critical;

    // Start is called before the first frame update
    void Start()
    {

        jumpControl = GameObject.FindWithTag("Player").GetComponent<JumpControl>();
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
        bool display = (jumpControl.JumpNow() && player_TrickPoint.MaxCount > 0);//ジャンプしている時かつ満タンのトリックゲージの数が1本以上あるとき表示

        if (display)
        {
            for(int i=0; i<buttonDisplays.Length;i++)
            {
                buttonDisplays[i].criticalButtonDisplay.DisplayButton(critical.CriticalButton[buttonDisplays[i].buttonNum]);
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
}
