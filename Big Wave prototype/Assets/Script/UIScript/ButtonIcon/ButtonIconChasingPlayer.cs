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
[System.Serializable]
struct Guide
{
    public float Delay;
    public float MoveSpeed;
}
public class ButtonIconChasingPlayer : MonoBehaviour
{
    [SerializeField] ButtonDisplays[] buttonDisplays;
    [SerializeField] Guide Guide;
    JudgeJumpNow judgeJumpNow;
    TrickPoint player_TrickPoint;
    Critical critical;
    private float elapsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        judgeJumpNow= GameObject.FindWithTag("Player").GetComponent<JudgeJumpNow>();
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
        if (judgeJumpNow.JumpNow() == false)
        {
            elapsedTime = 0;
        }
        for(int i=0;i<buttonDisplays.Length ;i++)
        {
            //ジャンプしている時かつ満タンのトリックゲージの数が表示したいボタンの要素番号より多くあるとき表示
            bool display = (judgeJumpNow.JumpNow() && player_TrickPoint.MaxCount > buttonDisplays[i].buttonNum);

            if(display)//表示する時
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime > Guide.Delay * i)
                {
                    Vector3 moveDirection= Vector3.zero;
                    buttonDisplays[i].criticalButtonDisplay.DisplayButton(critical.CriticalButton[buttonDisplays[i].buttonNum]);
                    switch (critical.CriticalButton[buttonDisplays[i].buttonNum])
                    {
                        case TrickButton.south:
                            {
                                moveDirection= Vector3.down;
                                break;
                            }
                        case TrickButton.west:
                            {
                                moveDirection = Vector3.left;
                                break;
                            }
                        case TrickButton.north:
                            {
                                moveDirection=-Vector3.up;
                                break;
                            }
                        case TrickButton.east:
                            {
                                moveDirection=Vector3.right;
                                break;
                            }
                    }
                    buttonDisplays[i].criticalButtonDisplay.transform.position += moveDirection * Time.deltaTime * Guide.MoveSpeed;
                }
            }
            else//非表示する時
            {
                buttonDisplays[i].criticalButtonDisplay.HideButton();
            }
        }
    }
}
