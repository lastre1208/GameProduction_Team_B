using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JudgeGameSet : MonoBehaviour
{
    HP player;
    HP enemy;
    Controller controller;
    ManagementOfScore managementOfScore;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.FindWithTag("Player").GetComponent<HP>();

        enemy = GameObject.FindWithTag("Enemy").GetComponent<HP>();

        controller = GameObject.FindWithTag("Player").GetComponent<Controller>();

        managementOfScore = GameObject.FindWithTag("ScoreManager").GetComponent<ManagementOfScore>();
    }

    // Update is called once per frame
    void Update()
    {
        DeadEnemy();

        DeadPlayer();
    }

    void DeadPlayer()
    {
        if(player.Hp<=0)//プレイヤーが死んだら
        {
            controller.StopVibe_Trick();//ゲーム終了時コントローラーの振動を止める応急処置
            SceneManager.LoadScene("GameoverScene");//ゲームオーバーシーンに移行
        }
    }

    void DeadEnemy()
    {
        if(enemy.Hp<=0)//敵が死んだら
        {
            controller.StopVibe_Trick();//ゲーム終了時コントローラーの振動を止める応急処置
            managementOfScore.CalculateScore();//スコア算出
            SceneManager.LoadScene("ClearScene");//クリアシーンに移行
        }
    }
}
