using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboCountDisplay : MonoBehaviour
{
    [Header("表示させるテキスト")]
    [SerializeField] TMP_Text comboCount_UI;//表示させるテキスト
    [SerializeField] CountTrickCombo countTrickCombo;

    void Update()
    {
        comboCount_UI.text=countTrickCombo.ComboCount.ToString("0");
    }
}
