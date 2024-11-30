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
    [Header("敵を倒した時の演出")]
    [SerializeField] DefeatEnemyEffect defeatEnemyEffect;//敵を倒した時の演出
    [Header("死亡時の演出")]
    [SerializeField] DeadEffect deadEffect;//死亡時の演出
    [Header("タイムアップ時の演出")]
    [SerializeField] TimeUpEffect timeUpEffect;//タイムアップ時のエフェクト
    [Header("プレイヤーのHP")]
    [SerializeField] HP player_Hp;//プレイヤーのHP
    [Header("敵のHP")]
    [SerializeField] HP enemy_Hp;//敵のHP
    [Header("時間")]
    [SerializeField] TimeLimit timeLimit;
    bool gameSet = false;

    public bool GameSet { get { return gameSet; } }

    void Update()
    {
        JudgeClear();
        JudgeGameOver();
    }

    void JudgeClear()
    {
        if (enemy_Hp.Hp <= 0&&!gameSet)//敵を倒したら
        {
            GameSetProcess(true);

            defeatEnemyEffect.Trigger();
        }
    }

    void JudgeGameOver()
    {
        bool dead = player_Hp.Hp <= 0;//プレイヤーが死んだ
        bool timeUp = timeLimit.RemainingTime <= 0;//時間切れになった

        if ((dead||timeUp) && !gameSet)//プレイヤーが死んだらまたは時間切れになったら
        {
            GameSetProcess(false);

            if(dead)//プレイヤー死亡時
            {
                deadEffect.Trigger();
            }
            else if(timeUp)//時間切れ時
            {
                timeUpEffect.Trigger();
            }
        }
    }

    void GameSetProcess(bool gameClear)//ゲーム終了しシーンに移行する直前に行う処理
    {
        GameSetCommonAction.Invoke();
        GameSetAction.Invoke(gameClear);
        gameSet = true;
    }
}
