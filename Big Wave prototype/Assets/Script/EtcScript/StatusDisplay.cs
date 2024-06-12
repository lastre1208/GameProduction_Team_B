using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusDisplay : MonoBehaviour
{
    //☆塩が書いた
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
        float hpratio = player.Hp / player.HpMax;
        playerOfHpGauge.GetComponent<Image>().fillAmount = hpratio;
    }

    void PlayerOfTRICKGage()//プレイヤーのトリックゲージの処理
    {
        float trickratio = player.Trick / player.TrickMax;
        playerOfTrickGauge.GetComponent<Image>().fillAmount = trickratio;
    }

    void EnemyOfHPGage()//敵のHPゲージの処理
    {
        if (enemy != null)
        {
            float enemy_hpratio = enemy.Hp / enemy.HpMax;
            enemyOfHpGauge.GetComponent<Image>().fillAmount = enemy_hpratio;
        }
    }
}
