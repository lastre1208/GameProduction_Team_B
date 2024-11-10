using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//トリックのスコア
[CreateAssetMenu(menuName = "ScriptableObjects/Score/TrickCombo")]
public class Score_TrickCombo_ : Score_Base
{
    public void Rewrite(float score)//スコアの書き換え
    {
        m_score = score;
    }
}
