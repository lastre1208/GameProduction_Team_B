using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ロードシーンから次に移行するゲームシーンの名前を管理する
[CreateAssetMenu(menuName = "ScriptableObjects/Scene/GameSceneName")]
public class GameSceneName : ScriptableObject
{
    string _nextGameScene;

    public string NextGameScene
    {
        get { return _nextGameScene; }
        set { _nextGameScene = value; }
    }
}
