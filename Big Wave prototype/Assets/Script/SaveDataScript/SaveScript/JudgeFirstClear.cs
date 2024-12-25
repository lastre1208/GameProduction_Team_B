using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//作成者:杉山
//初クリアか判定
public class JudgeFirstClear : MonoBehaviour
{
    [Header("クリア回数をセーブするコンポーネント")]
    [SerializeField] SaveClearCount _saveClearCount;
    public event Action<bool> Action_FirstClear;//初クリアの判定後に呼ぶ処理、初クリアであれば、trueが入る
    const int _judgeFirstClear_ClearCount = 0;//初クリアと判定するクリア回数(0回であれば、初クリアとなる)
    bool _isFirstClear = false;

    public bool IsFirstClear { get { return _isFirstClear; } }

    private void Awake()
    {
        _saveClearCount.Action_ClearCount_BeforeUpdate += Judge;
    }

    public void Judge(int clearCount_BeforeUpdate)//更新・セーブ前のクリア回数を取得、それが0回であれば初クリアということ
    {
        _isFirstClear = (clearCount_BeforeUpdate == _judgeFirstClear_ClearCount);

        Action_FirstClear?.Invoke(_isFirstClear);
    }

}
