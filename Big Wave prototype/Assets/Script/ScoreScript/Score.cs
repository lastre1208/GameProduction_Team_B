using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Score : MonoBehaviour
{
    protected float score=0;//スコア、シーン遷移する直前に以下のstatic変数のどれかにscoreの値を代入

    public float Score_
    {
        get { return score; }
    }

    public virtual void ReflectScore() { }//スコア反映
    public virtual void ReflectScore(bool gameSet) { }//クリア時のみスコア反映
}
