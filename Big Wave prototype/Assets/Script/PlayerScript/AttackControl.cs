using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackControl : MonoBehaviour
{
    [SerializeField] float damageMax = 1f;//最大ダメージ(トリックを最大まで溜めた時のダメージ)
    Enemy enemy;
    Player player;
    JumpControl jumpcontrol;
    [HideInInspector] public bool attacked;//攻撃したかしていないかの判定

    // Start is called before the first frame update
    void Start()
    {
       attacked = false;
       enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
       player = gameObject.GetComponent<Player>();
       jumpcontrol = gameObject.GetComponent<JumpControl>();
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
                    enemy.Damage(player.trick / player.trickMax * damageMax);
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
