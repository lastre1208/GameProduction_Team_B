using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//作成者:杉山
//登録したスコアを表示させる
public class ScoreDisplay : MonoBehaviour
{
    [Header("スコア表示する文字")]
    [SerializeField] TMP_Text m_scoreText;
    [Header("表示したいスコア")]
    [SerializeField] Score_Base[] m_showScores;//表示したいスコア

    void Start()
    {
        ShowScore();
    }

    void ShowScore()
    {
        float totalScore = 0;

        for(int i=0;i<m_showScores.Length ;i++)
        {
            totalScore += m_showScores[i].Score;
        }

        m_scoreText.text = totalScore.ToString("0");
    }
}
