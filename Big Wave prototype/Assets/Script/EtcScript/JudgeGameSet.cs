using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JudgeGameSet : MonoBehaviour
{
    HP player;
    HP enemy;
    ManagementOfScore managementOfScore;
    private Gamepad gamepad = Gamepad.current;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.FindWithTag("Player").GetComponent<HP>();

        enemy = GameObject.FindWithTag("Enemy").GetComponent<HP>();

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
            //ゲーム終了時コントローラーの振動を止める応急処置
            if (gamepad != null)
            {
                gamepad.SetMotorSpeeds(0f, 0f);
            }
            SceneManager.LoadScene("GameoverScene");//ゲームオーバーシーンに移行
        }
    }

    void DeadEnemy()
    {
        if(enemy.Hp<=0)//敵が死んだら
        {
            //ゲーム終了時コントローラーの振動を止める応急処置
            if (gamepad != null)
            {
                gamepad.SetMotorSpeeds(0f, 0f);
            }
            managementOfScore.CalculateScore();//スコア算出
            SceneManager.LoadScene("ClearScene");//クリアシーンに移行
        }
    }
}
