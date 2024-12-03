using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;

//作成者:杉山
//ゲーム終了の判断
public class JudgeGameSet : MonoBehaviour
{
    public event Action<bool> GameSetAction;//trueならゲームクリア、falseならゲームオーバー
    public event Action GameSetCommonAction;//ゲーム終了時クリアでもゲームオーバーでもどちらでもやる共通イベント
    public event Action GameClearAction;//ゲームクリア時に呼ぶ
    public event Action DeadAction;//死亡時に呼ぶ
    public event Action TimeUpAction;//タイムアップ時に呼ぶ
    public event Action LatedAction;//遅れて呼ぶ

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
        JudgeDead();
        JudgeTimeUp();
    }

    void JudgeClear()//クリア判断
    {
        if (enemy_Hp.Hp <= 0&&!gameSet)//敵を倒したら
        {
            GameSetProcess(true);
            GameClearAction?.Invoke();
            LatedAction?.Invoke();
        }
    }

    void JudgeDead()//プレイヤー死亡判断
    {
        bool dead = player_Hp.Hp <= 0;//プレイヤーが死んだ

        if (dead&& !gameSet)//プレイヤーが死んだら
        {
            GameSetProcess(false);
            DeadAction?.Invoke();
            LatedAction?.Invoke();
        }
    }

    void JudgeTimeUp()//時間切れ判断
    {
        bool timeUp = timeLimit.RemainingTime <= 0;//時間切れになった

        if(timeUp&&!gameSet)//時間切れ時
        {
            GameSetProcess(false);
            TimeUpAction?.Invoke();
            LatedAction?.Invoke();
        }
    }

    void GameSetProcess(bool gameClear)//ゲーム終了しシーンに移行する直前に行う処理
    {
        gameSet = true;
        GameSetCommonAction?.Invoke();
        GameSetAction?.Invoke(gameClear);
    }
}
