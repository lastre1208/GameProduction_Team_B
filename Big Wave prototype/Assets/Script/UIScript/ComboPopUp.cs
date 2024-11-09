using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class ComboPopUp : MonoBehaviour
{
    [SerializeField] TMP_Text text_countPrefab;
    [SerializeField] RectTransform target;
    [SerializeField] Canvas canvas;
    [SerializeField] CountTrickCombo countTrickCombo;
   
    public void PopUp()
    {
        if(countTrickCombo.ContinueCombo)
        {
            int comboCount=countTrickCombo.ComboCount;
            text_countPrefab.text = (comboCount + ("COMBO!!"));
            Instantiate(text_countPrefab, target.position, target.rotation, canvas.transform);// Canvas の子要素としてtargetの位置にインスタンスを生成
        }
    }
}
