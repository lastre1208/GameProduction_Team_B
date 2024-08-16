using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[System.Serializable]
class ReflectScore
{
    [Header("ゲーム終了時に反映させたいスコア")]
    [SerializeField] Score reflectScore;
    [Header("クリア時のみスコアを反映させるか")]
    [SerializeField] bool reflectWhenClear;

    internal void Reflect(bool gameClear)
    {
        if(reflectWhenClear)//クリア時のみスコアを反映させる場合(ゲームオーバー時はスコアが0)
        {
            reflectScore.ReflectScore(gameClear);
        }
        else//ゲームオーバー時でもスコアを反映させる場合
        {
            reflectScore.ReflectScore();
        }
    }
}

public class JudgeGameSet : MonoBehaviour
{
    [Header("コンボ回数のスコア")]
    [SerializeField] Score_TrickCombo score_TrickCombo;//コンボ回数のスコア
    [Header("ゲーム終了時に反映させたいスコア")]
    [SerializeField] ReflectScore[] reflectScores;
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
        for(int i = 0; i<reflectScores.Length; i++)
        {
            reflectScores[i].Reflect(gameClear);
        }
    }

    void StopControllerVibe()//ゲーム終了時コントローラーの振動を止める応急処置
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0f, 0f);
        }
    }
}
