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
    [SerializeField] RectTransform target;
    [SerializeField] Canvas canvas;
    [SerializeField] CountTrickCombo countTrickCombo;
    [SerializeField] float ScaleLimit;
    [SerializeField] float StartSize;
    private float DefaultSize;
    public void Start()
    {
        DefaultSize = StartSize;
        text_countPrefab.fontSize = DefaultSize;
    }
    public void PopUp()
    {
        if (countTrickCombo.ContinueCombo)
        {
            int comboCount = countTrickCombo.ComboCount;
            if (ScaleLimit >= countTrickCombo.ComboCount)
            {
                text_countPrefab.fontSize += comboCount;
            }
               
                text_countPrefab.text = (comboCount + ("COMBO!!"));
                Instantiate(text_countPrefab, target.position, target.rotation, canvas.transform);// Canvas の子要素としてtargetの位置にインスタンスを生成
            
        }
        else
        {
            text_countPrefab.fontSize = DefaultSize;
        }
    }
    
}
