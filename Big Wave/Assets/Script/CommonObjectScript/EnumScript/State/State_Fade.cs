using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//フェードアウト・インの状態
public enum State_Fade
{
    off,//動いていない
    fading,//フェード中
    cancel,//中断中
    completed//完了した
}