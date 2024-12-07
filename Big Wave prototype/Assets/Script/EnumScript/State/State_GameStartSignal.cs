using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//スタート時の合図の状態
public enum State_GameStartSignal
{
    off,//合図が動いていない
    fadeIn,//フェードイン中
    playing,//合図中
    completed//合図終了(完了)
}