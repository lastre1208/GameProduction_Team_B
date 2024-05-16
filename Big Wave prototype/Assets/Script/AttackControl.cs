using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackControl : MonoBehaviour
{
    [SerializeField] float damageAdjustment = 1f;//ダメージ調整係数
    Enemy enemy;
    Player player;
    JumpControl jumpcontrol;
    public bool attacked;//攻撃したかしていないかの判定

    // Start is called before the first frame update
    void Start()
    {
       attacked = false;
       enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
       player = GameObject.FindWithTag("Player").GetComponent<Player>();
       jumpcontrol = GameObject.FindWithTag("Player").GetComponent<JumpControl>();
    }

    // Update is called once per frame
    void Update()
    {
            Attack();//攻撃
    }

    //攻撃(ジャンプ中に左クリック)
    //trickを消費して敵にダメージを与える、trickの値によってダメージが変わる(ダメージの値はtrick×damagecoefficient)
    void Attack()
    {
        if (Input.GetButtonDown("Fire1")||Input.GetKeyDown("j"))
        {
            if (jumpcontrol.jumpNow == true)
            {
                if (enemy != null)
                {
                    enemy.Damage(player.trick * damageAdjustment);
                }

                attacked = true;//攻撃した
                player.ConsumeTRICK();
            }
        }

        if(jumpcontrol.jumpNow == false)//水面に接地しているなら
        {
            attacked = false;//攻撃していない
        }
    }
}
