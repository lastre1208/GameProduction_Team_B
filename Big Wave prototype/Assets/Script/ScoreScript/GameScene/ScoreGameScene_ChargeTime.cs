using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームシーンでのチャージタイムスコアの計測・判定
public class ScoreGameScene_ChargeTime : MonoBehaviour
{
    [Header("残り時間(1秒)ごとのスコア量")]
    [SerializeField] float m_scorePerSecond;//残り時間(1秒)ごとのスコア量
    [Header("スコア反映に使うコンポーネント")]
    [SerializeField] Score_ChargeTime_ score_ChargeTime;//スコア反映
    [Header("チャージ時間を計測するコンポーネント")]
    [SerializeField] CountChargeTime countChargeTime;
    [Header("ゲーム終了を判断するコンポーネント")]
    [SerializeField] JudgeGameSet judgeGameSet;

    public float Score { get { return countChargeTime.ChargeTime * m_scorePerSecond; } }//スコアの計算式

    private void Start()
    {
        judgeGameSet.GameSetCommonAction += Reflect;
    }

    public void Reflect()//スコア反映
    {
        score_ChargeTime.Rewrite(Score, countChargeTime.ChargeTime, m_scorePerSecond);
    }
}
