using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//初クリア時に表示するメッセージ
public class FirstClearMessageDisplay : MonoBehaviour
{
    [Header("初クリア時に表示するオブジェクトとそのステージのID")]
    [SerializeField] Element_FirstClearMessageDisplay[] elements;//初クリア時に表示するオブジェクトとそのステージのID
    [Header("初クリアかを判定するコンポーネント")]
    [SerializeField] JudgeFirstClear _judgeFirstClear;//初クリアかを判定するコンポーネント
    [Header("ステージデータ")]
    [SerializeField] CurrentStageData _currentStageData;//ステージデータ

    private void Awake()
    {
        _judgeFirstClear.Action_FirstClear += Display;
    }

    public void Display(bool firstClear)//先ほど遊んだステージのIDと一致するものを表示する
    {
        if (!firstClear) return;

        int currentStageID = _currentStageData.StageID;//先ほど遊んだステージのID

        for(int i=0; i<elements.Length ;i++)
        {
            if (elements[i].StageID==currentStageID)
            {
                elements[i].Object.SetActive(true);
            }
        }
    }

}
