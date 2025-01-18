using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者:杉山
//プレイヤーのクリアレベル(どのステージまでクリアしたか)に応じてボタンの選択
public class ChangeInteractable_ClearLevel : MonoBehaviour
{
    [Header("必要クリアレベル")]
    [SerializeField] int _requiredLevel;
    [Header("対象のボタン")]
    [SerializeField] Button _targetButton;//対象のボタン

    void Start()
    {
        ChangeInteractable();
    }

    void ChangeInteractable()
    {
        //プレイヤーのクリアレベルを取得
        int clearLevel=SaveData.GetClearLevel();

        //挑戦可能か判断
        bool challengable = clearLevel >= _requiredLevel;

        //挑戦不可能ならボタン選択ができないようにする
        _targetButton.interactable = challengable;
    }
}
