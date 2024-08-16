using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JudgeGameSet : MonoBehaviour
{
    [Header("トリック回数のスコア")]
    [SerializeField] Score_TrickCount score_TrickCount;
    [Header("トリックボタン指定成功のスコア")]
    [SerializeField] Score_CriticalTrickCount score_CriticalTrickCount;
    [Header("トリックコンボのスコア")]
    [SerializeField] Score_TrickCombo score_TrickCombo;
    [Header("ゲームクリアのスコア")]
    [SerializeField] Score_GameClear score_GameClear;
    [Header("制限時間のスコア")]
    [SerializeField] Score_TimeLimit score_TimeLimit;
    [Header("残りHPのスコア")]
    [SerializeField] Score_HP score_HP;
    HP player_Hp;
    HP enemy_Hp;
    CountTrickCombo countTrickCombo;
    private Gamepad gamepad = Gamepad.current;
    // Start is called before the first frame update
    void Start()
    {
        player_Hp= GameObject.FindWithTag("Player").GetComponent<HP>();

        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();

        countTrickCombo= GameObject.FindWithTag("Player").GetComponent<CountTrickCombo>();
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
            GameOver();
        }
    }

    void DeadEnemy()//プレイヤー死亡時、ゲームクリア
    {
        if(enemy_Hp.Hp<=0)//敵が死んだら
        {
            Clear();
        }
    }

    void TimeUp()//時間切れ時、ゲームオーバー
    {
        if(TimeLimit.RemainingTime<=0)//時間切れになったら
        {
            GameOver();
        }
    }

    void GameOver()//ゲームオーバーシーンに移行する時の処理
    {
        GameSetProcess(false);
        SceneManager.LoadScene("GameoverScene");//ゲームオーバーシーンに移行
    }

    void Clear()//クリアシーンに移行する時の処理
    {
        GameSetProcess(true);
        SceneManager.LoadScene("ClearScene");//クリアシーンに移行
    }

    void GameSetProcess(bool gameClear)//ゲーム終了時の処理
    {
        StopControllerVibe();//コントローラの振動を止める
        //ゲーム終了直前のコンボ回数をスコアに加算
        score_TrickCombo.AddScore(countTrickCombo.ComboCount);
        //スコア反映
        score_TrickCount.ReflectScore();
        score_CriticalTrickCount.ReflectScore();
        score_TrickCombo.ReflectScore();
        score_GameClear.ReflectScore(gameClear);
        score_TimeLimit.ReflectScore(gameClear);
        score_HP.ReflectScore(gameClear);
    }

    void StopControllerVibe()//ゲーム終了時コントローラーの振動を止める応急処置
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0f, 0f);
        }
    }
}
