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
    HP player_Hp;
    HP enemy_Hp;
    // Start is called before the first frame update
    void Start()
    {
        player_Hp= GameObject.FindWithTag("Player").GetComponent<HP>();

        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
    }

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
        if (player_Hp.Hp <= 0|| TimeLimit.RemainingTime <= 0)//プレイヤーが死んだらまたは時間切れになったら
        {
            GameSetProcess(false);
        }
    }

    void GameSetProcess(bool gameClear)//ゲーム終了しシーンに移行する直前に行う処理
    {
        GameSetCommonAction.Invoke();
        GameSetAction.Invoke(gameClear);

        //シーン移行
        string nextSceneName;
        nextSceneName = gameClear ? "ClearScene" : "GameOverScene";
        SceneManager.LoadScene(nextSceneName);
    }
}
