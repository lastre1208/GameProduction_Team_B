using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームの開始処理の状態(追加するなら順番通りにしてください)
enum State_GameStartSequence
{
    movie,//ムービー再生
    signal,//合図
    start//(ゲームの)スタート
}