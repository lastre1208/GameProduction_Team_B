using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

//作成者:杉山
//ゲームシーンでの最大コンボ回数スコアの計測・判定
public class ScoreGameScene_ComboMax : MonoBehaviour
{
    [Header("コンボ1回ごとのスコア")]
    [SerializeField] float m_scorePerCombo;//コンボ1回ごとのスコア
    [Header("スコア反映に使うコンポーネント")]
    [SerializeField] Score_ComboMax score_ComboMax;//スコア反映
    [Header("コンボ回数を数えるコンポーネント")]
    [SerializeField] CountTrickCombo countTrickCombo;
    [Header("ゲーム終了を判断するコンポーネント")]
    [SerializeField] JudgeGameSet judgeGameSet;

    private void Start()
    {
        judgeGameSet.GameSetCommonAction += Reflect;
    }


    public void Reflect()//スコア反映
    {
        float score = countTrickCombo.ComboCountMax * m_scorePerCombo;//スコアの計算式

        score_ComboMax.Rewrite(score, countTrickCombo.ComboCountMax, m_scorePerCombo);
    }
}
