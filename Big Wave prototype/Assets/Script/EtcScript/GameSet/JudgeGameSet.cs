using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JudgeGameSet : MonoBehaviour
{
    [Header("コントローラのバイブを止めるため")]
    [SerializeField] ControlVibe controlVibe;
    [Header("スコア反映するコンポーネント")]
    [SerializeField] ScoreGameScene_GameClear score_GameClear;
    [SerializeField] ScoreGameScene_HP score_HP;
    [SerializeField] ScoreGameScene_TimeLimit score_TimeLimit;
    [SerializeField] ScoreGameScene_ComboMax score_ComboMax;
    [SerializeField] ScoreGameScene_ChargeTime score_ChargeTime;
    [SerializeField] ScoreGameScene_TrickCombo score_TrickCombo;
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
        DeadEnemy();

        DeadPlayer();

        TimeUp();
    }

    void DeadPlayer()//プレイヤー死亡時、ゲームオーバー
    {
        if(player_Hp.Hp<=0)//プレイヤーが死んだら
        {
            GameOverProcess();
        }
    }

    void DeadEnemy()//プレイヤー死亡時、ゲームクリア
    {
        if(enemy_Hp.Hp<=0)//敵が死んだら
        {
            ClearProcess();
        }
    }

    void TimeUp()//時間切れ時、ゲームオーバー
    {
        if(TimeLimit.RemainingTime<=0)//時間切れになったら
        {
            GameOverProcess();
        }
    }

    void GameOverProcess()//ゲームオーバーシーンに移行する時の処理
    {
        GameSetProcess(false);
        SceneManager.LoadScene("GameoverScene");//ゲームオーバーシーンに移行
    }

    void ClearProcess()//クリアシーンに移行する時の処理
    {
        GameSetProcess(true);
        SceneManager.LoadScene("ClearScene");//クリアシーンに移行
    }

    void GameSetProcess(bool gameClear)//ゲーム終了しシーンに移行する直前に行う処理
    {
        //コントローラのバイブを止める
        controlVibe.Vibe();
        //スコア反映
        score_GameClear.Reflect(gameClear);
        score_HP.Reflect(gameClear);
        score_TimeLimit.Reflect(gameClear);
        score_ComboMax.Refelect();
        score_ChargeTime.Reflect();
        score_TrickCombo.Reflect();

        if(gameClear)//クリア時
        {

        }
        else//ゲームオーバー時
        {

        }
    }
}
