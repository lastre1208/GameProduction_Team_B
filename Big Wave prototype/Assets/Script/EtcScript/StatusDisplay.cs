using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusDisplay : MonoBehaviour
{
    [SerializeField] GameObject playerOfHpGauge;//プレイヤーのHPゲージ
    [SerializeField] GameObject playerOfTrickGauge;//プレイヤーのトリックゲージ
    [SerializeField] GameObject enemyOfHpGauge;//敵のHPゲージ
    Enemy enemy;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerOfHPGage();

        PlayerOfTRICKGage();

        EnemyOfHPGage();
    }

    void PlayerOfHPGage()//プレイヤーのHPゲージの処理
    {
        float hpratio = player.hp / player.hpMax;
        playerOfHpGauge.GetComponent<Image>().fillAmount = hpratio;
    }

    void PlayerOfTRICKGage()//プレイヤーのトリックゲージの処理
    {
        float trickratio = player.trick / player.trickMax;
        playerOfTrickGauge.GetComponent<Image>().fillAmount = trickratio;
    }

    void EnemyOfHPGage()//敵のHPゲージの処理
    {
        if (enemy != null)
        {
            float enemy_hpratio = enemy.hp / enemy.hpMax;
            enemyOfHpGauge.GetComponent<Image>().fillAmount = enemy_hpratio;
        }
    }
}
