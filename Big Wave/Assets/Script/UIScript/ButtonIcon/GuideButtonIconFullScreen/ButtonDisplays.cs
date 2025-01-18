using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ボタン表示設定
public partial class GuideButtonIconFullScreen
{
    [System.Serializable]
    struct ButtonDisplays
    {
        [Header("表示したいボタンの要素番号")]
        [Tooltip("現在指定されているボタンを表示したいなら0、二番目に指定されているボタンなら1...")]
        [SerializeField] public int buttonNum;//表示したいボタンの要素番号
        [Header("表示されるボタン")]
        [SerializeField] public ButtonIconDisplay criticalButtonDisplay;//表示されるボタン
    }
}
