using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者:杉山
//シーンの始めに前の画面に戻るボタンを登録する
public class StartOpenMenu : MonoBehaviour
{
    [Header("対象ボタン")]
    [SerializeField] Button _targetButton;//対象ボタン
    [SerializeField] CloseMenuEasily _closeMenuEasily;

    void Start()
    {
        //閉じる・前の画面に戻るボタンに対象ボタンを登録
        _closeMenuEasily.OpenNewMenu(_targetButton);
    }
}
