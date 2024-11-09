using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームシーンでのスコアの更新
public abstract class ScoreGameScene_Base : MonoBehaviour
{
    public abstract void Reflect();//ゲーム終了時にこれを呼びスコアを反映させるようにする
}
