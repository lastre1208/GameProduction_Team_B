using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームシーンでの最大コンボ回数スコアの計測・判定
public class ScoreGameScene_ComboMax : MonoBehaviour
{
    [Header("コンボ1回ごとのスコア")]
    [SerializeField] float m_scorePerCombo;//コンボ1回ごとのスコア
    [Header("スコア反映に使うコンポーネント")]
    [SerializeField] Score_ComboMax_ score_ComboMax;//スコア反映
    [Header("コンボ回数を数えるコンポーネント")]
    [SerializeField] CountTrickCombo countTrickCombo;


    public void Refelect()//スコア反映
    {
        float score = countTrickCombo.ComboCountMax * m_scorePerCombo;//スコアの計算式

        score_ComboMax.Rewrite(score, countTrickCombo.ComboCountMax, m_scorePerCombo);
    }
}
