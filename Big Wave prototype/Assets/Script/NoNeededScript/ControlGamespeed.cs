using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGamespeed : MonoBehaviour
{
    //☆桑原君が書いた
    private float nomalSpeedRatio = 1.0f;//通常時のゲームスピード倍率
    [SerializeField] float speedRatio = 0.5f;//ジャンプ時のゲームスピード遅延倍率
    JumpControl playerJump;//プレイヤーが飛んでいるかどうか
    TrickControl playerAttack;//プレイヤーが攻撃したかどうか

    // Start is called before the first frame update
    void Start()
    {
        playerJump = GameObject.FindWithTag("Player").GetComponent<JumpControl>();
        playerAttack = GameObject.FindWithTag("Player").GetComponent<TrickControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Change_GameSpeed();//ゲームスピードの変化
    }

    void Change_GameSpeed()//ゲームスピードの変化
    {
        if (playerJump.JumpNow == true && playerAttack.Tricked == false)
            //プレイヤーがジャンプ中かつトリックボタンが押されていない場合
        {
            Time.timeScale = speedRatio;//slowratioの値で倍率調整（小さくするほど遅くなる）
        }

        else
        {
            Time.timeScale = nomalSpeedRatio;//1倍速
        }
    }
}
