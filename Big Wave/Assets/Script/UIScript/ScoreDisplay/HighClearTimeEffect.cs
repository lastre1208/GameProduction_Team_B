using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//作成者:杉山
//最速クリアタイムが出たら演出を出す(現在は文字を出すだけ)
public class HighClearTimeEffect : MonoBehaviour
{
    [SerializeField] SaveHighClearTime _saveHighClearTime;
    [Header("最速クリアタイム更新時に表示するテキスト")]
    [SerializeField] TMP_Text _highClearTimeText;

    private void Awake()
    {
        _saveHighClearTime.Action_NewRecord += Display;
    }

    public void Display(bool updated)
    {
        _highClearTimeText.enabled = updated;
    }
}
