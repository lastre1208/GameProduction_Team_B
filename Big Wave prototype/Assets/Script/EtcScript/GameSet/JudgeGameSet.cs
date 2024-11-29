using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;

public class JudgeGameSet : MonoBehaviour
{
    public event Action<bool> GameSetAction;//trueならゲームクリア、falseならゲームオーバー
    public event Action GameSetCommonAction;//ゲーム終了時クリアでもゲームオーバーでもどちらでもやる共通イベント
    [Header("ゲームクリアの演出")]
    [SerializeField] GameClearEffect gameClearEffect;//ゲームクリアの演出
    [Header("ゲームオーバーの演出")]
    [SerializeField] GameOverEffect gameOverEffect;//ゲームオーバーの演出
    [Header("プレイヤーのHP")]
    [SerializeField] HP player_Hp;//プレイヤーのHP
    [Header("敵のHP")]
    [SerializeField] HP enemy_Hp;//敵のHP
    [Header("時間")]
    [SerializeField] TimeLimit timeLimit;

    // Update is called once per frame
    void Update()
    {
        JudgeClear();
        JudgeGameOver();
    }

    void JudgeClear()
    {
        if (enemy_Hp.Hp <= 0)//敵が死んだら
        {
            GameSetProcess(true);
        }
    }

    void JudgeGameOver()
    {
        if (player_Hp.Hp <= 0|| timeLimit.RemainingTime <= 0)//プレイヤーが死んだらまたは時間切れになったら
        {
            GameSetProcess(false);
        }
    }

    void GameSetProcess(bool gameClear)//ゲーム終了しシーンに移行する直前に行う処理
    {
        GameSetCommonAction.Invoke();
        GameSetAction.Invoke(gameClear);

        //ゲーム終了演出
        if(gameClear)//ゲームクリア時
        {
            gameClearEffect.Trigger();
        }
        else//ゲームオーバー時
        {
            gameOverEffect.Trigger();
        }
    }
}
