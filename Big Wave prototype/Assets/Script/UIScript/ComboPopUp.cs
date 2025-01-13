using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class ComboPopUp : MonoBehaviour
{
    public TMP_Text text_countPrefab;
    [SerializeField] string[] PopUpTexts;
    [SerializeField] RectTransform target;
    [SerializeField] Transform parent;
    [SerializeField] CountTrickCombo countTrickCombo;
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] float ScaleText;
    [SerializeField] float StartSize;
    private float DefaultSize;
    private int comboCount = 0;

   

    public void Start()
    {
        DefaultSize = StartSize;
        text_countPrefab.fontSize = DefaultSize;
        judgeJumpNow.StartJumpAction+=ResetCombo;
    }
    public void PopUp()
    {
        if (countTrickCombo.ContinueCombo)
        {

            if (comboCount > PopUpTexts.Length)
            {
                comboCount = PopUpTexts.Length;
            }
            
                text_countPrefab.fontSize += ScaleText;
            

            text_countPrefab.text = PopUpTexts[comboCount];
            Instantiate(text_countPrefab, target.position, target.rotation, parent);// Canvas の子要素としてtargetの位置にインスタンスを生成
            comboCount++;
        }
        else
        {

            ResetCombo();
        }
    }
    void ResetCombo()
    {
        text_countPrefab.fontSize = DefaultSize;
        comboCount = 0;
    }
}
