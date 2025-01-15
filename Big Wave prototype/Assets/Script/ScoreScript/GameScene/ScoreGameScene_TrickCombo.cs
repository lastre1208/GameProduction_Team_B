using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームシーンでのトリックスコアの計測・判定
//ここでいうコンボとは連続クリティカル回数のこと
//トリックの成功率で計測する仕様に変更
public class ScoreGameScene_TrickCombo : MonoBehaviour
{
    [Header("基本スコア")]
    [SerializeField] float m_defaultScore;//基本スコア
    [Header("成功率100%だった場合に追加されるスコア")]
    [SerializeField] float m_perfectScore;
    [Header("コンボ追加スコア")]
    [SerializeField] float m_addComboScore;//コンボ追加スコア
    [Header("スコア増加最大コンボ回数")]
    [SerializeField] int m_maxAddComboCount;//スコア増加最大コンボ回数
    [Header("スコア反映に使うコンポーネント")]
    [SerializeField] Score_TrickCombo score_TrickCombo;//スコア反映
    [Header("コンボ回数を数えるコンポーネント")]
    [SerializeField] Count_Trick_Critical countTrickCombo;
    [Header("ゲーム終了を判断するコンポーネント")]
    [SerializeField] JudgeGameSet judgeGameSet;
    private float m_score=0;//スコア合計

    public float Score { get { return m_score; }  }

    private void Start()
    {
        judgeGameSet.GameSetCommonAction += Reflect;
    }

    public void AddScore()//スコア加算(トリック時に呼ぶ)
    {
        //コンボ回数を取得(最大コンボ回数を超えていたら最大コンボ回数の値にする)
        int comboCount = Mathf.Min(countTrickCombo.ContinuanceCriticalCount, m_maxAddComboCount);

        m_score += m_defaultScore + m_addComboScore * comboCount;//連続コンボ回数に応じてスコアを加算
    }

    float AddCriticalSuccessRateScore()//クリティカルの成功率により加算されるスコアの算出
    {
        return m_perfectScore * countTrickCombo.CriticalRate;
    }

    public void Reflect()//スコア反映
    {
        m_score += AddCriticalSuccessRateScore();
       
        score_TrickCombo.Rewrite(m_score);
    }
}
