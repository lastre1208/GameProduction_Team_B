using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームシーンでのトリックスコアの計測・判定
//ここでいうコンボとは連続クリティカル回数のこと
public class ScoreGameScene_TrickCombo : MonoBehaviour
{
    [Header("基本スコア")]
    [SerializeField] float m_defaultScore;//基本スコア
    [Header("コンボ追加スコア")]
    [SerializeField] float m_addComboScore;//コンボ追加スコア
    [Header("スコア増加最大コンボ回数")]
    [SerializeField] int m_maxAddComboCount;//スコア増加最大コンボ回数
    [Header("スコア反映に使うコンポーネント")]
    [SerializeField] Score_TrickCombo score_TrickCombo;//スコア反映
    [Header("コンボ回数を数えるコンポーネント")]
    [SerializeField] CountTrickCombo countTrickCombo;
    [Header("ゲーム終了を判断するコンポーネント")]
    [SerializeField] JudgeGameSet judgeGameSet;
    private float m_score=0;

    public float Score { get { return m_score; }  }

    private void Start()
    {
        judgeGameSet.GameSetCommonAction += Reflect;
    }

    public void AddScore()//スコア加算(トリック時に呼ぶ)
    {
        if(countTrickCombo.ContinueCombo)//コンボが続いていたら
        {
            int comboCount = countTrickCombo.ComboCount > m_maxAddComboCount ? m_maxAddComboCount : countTrickCombo.ComboCount;//コンボ回数(最大コンボ回数を超えていたら最大コンボ回数の値にする)
            m_score += m_defaultScore + m_addComboScore*comboCount;//連続コンボ回数に応じてスコアを加算
        }
        else //コンボが途切れたら(普通のトリックだったら)
        {
            m_score += m_defaultScore;//基本スコア分加算
        }
    }

    public void Reflect()//スコア反映
    {
        score_TrickCombo.Rewrite(m_score);
    }
}
