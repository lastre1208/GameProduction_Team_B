using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームクリアのスコア
[CreateAssetMenu(menuName = "ScriptableObjects/Score/GameClear")]

public class Score_GameClear_ : Score_Base
{
    bool m_gameCleared=false;//ゲームをクリアしたか

    public bool GameCleared { get { return m_gameCleared; } }

    public void Rewrite(float score,bool gameCleared)//スコアの書き換え
    {
        m_score = score;
        m_gameCleared = gameCleared;
    }
}
