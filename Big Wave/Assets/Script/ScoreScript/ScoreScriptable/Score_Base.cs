using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//スコアの値(シーンをまたいで保存できる)
public abstract class Score_Base : ScriptableObject
{
    protected float m_score;//スコア量

    public float Score { get { return m_score; } }
}
