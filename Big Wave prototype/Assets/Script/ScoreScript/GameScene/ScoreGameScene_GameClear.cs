using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���V�[���ł̃Q�[���N���A�X�R�A�̌v���E����
public class ScoreGameScene_GameClear : MonoBehaviour
{
    [Header("�Q�[���N���A���̃X�R�A��")]
    [SerializeField] float m_scoreGameClear;//�Q�[���N���A���̃X�R�A��
    [Header("�X�R�A���f�Ɏg���R���|�[�l���g")]
    [SerializeField] Score_GameClear_ score_GameClear;//�X�R�A���f
    const float m_scoreGameOver = 0;//�Q�[���I�[�o�[���̃X�R�A��

    public void Reflect(bool gameClear)//�X�R�A���f
    {
        score_GameClear.Rewrite(gameClear ? m_scoreGameClear : m_scoreGameOver, gameClear);
    }
}