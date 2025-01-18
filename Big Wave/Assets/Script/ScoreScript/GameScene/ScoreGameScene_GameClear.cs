using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームシーンでのゲームクリアスコアの計測・判定
public class ScoreGameScene_GameClear : MonoBehaviour
{
    [Header("ゲームクリア時のスコア量")]
    [SerializeField] float m_scoreGameClear;//ゲームクリア時のスコア量
    [Header("スコア反映に使うコンポーネント")]
    [SerializeField] Score_GameClear score_GameClear;//スコア反映
    [Header("ゲーム終了を判断するコンポーネント")]
    [SerializeField] JudgeGameSet judgeGameSet;
    const float m_scoreGameOver = 0;//ゲームオーバー時のスコア量

    private void Start()
    {
        judgeGameSet.GameSetAction += Reflect;
    }

    public void Reflect(bool gameClear)//スコア反映
    {
        score_GameClear.Rewrite(gameClear ? m_scoreGameClear : m_scoreGameOver, gameClear);
    }
}
