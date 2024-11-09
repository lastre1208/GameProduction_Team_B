using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text m_scoreText;
    [SerializeField] Score_Base[] m_showScores;

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
