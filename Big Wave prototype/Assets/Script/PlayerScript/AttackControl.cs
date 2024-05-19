using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackControl : MonoBehaviour
{
    [SerializeField] float strong_TrickCostPercent=50;//強攻撃時の消費トリック(プレイヤーの最大トリックのstrong_TrickCostPercent%分消費)
    [SerializeField] float medium_TrickCostPercent=30;//中攻撃時の消費トリック(プレイヤーの最大トリックのmedium_TrickCostPercent%分消費)
    [SerializeField] float weak_TrickCostPercent=10;//弱攻撃時の消費トリック(プレイヤーの最大トリックのweak_TrickCostPercent%分消費)
    [SerializeField] float strong_Damage = 100;//強攻撃時の敵に与えるダメージ
    [SerializeField] float medium_Damage = 60;//中攻撃時の敵に与えるダメージ
    [SerializeField] float weak_Damage = 20;//弱攻撃時の敵に与えるダメージ
    private float trickCost;//消費トリック
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
        Attack_Strong();//強攻撃(ゲージ消費大)
        Attack_Medium();//中攻撃(ゲージ消費中)
        Attack_Weak();//弱攻撃(ゲージ消費小)
        AttackedtoFalseNoJump();//ジャンプしていない時攻撃していない判定にする
    }

    //強攻撃(ジャンプ中にJキーかXボタンを入力)
    //消費トリックはプレイヤーの最大トリックのstrong_TrickCostPercent%分消費
    void Attack_Strong()
    {
        trickCost = player.trickMax * strong_TrickCostPercent / 100;//強攻撃時の消費トリック
        if ((Input.GetButtonDown("Fire1")||Input.GetKeyDown("j"))&& jumpcontrol.jumpNow == true&&trickCost<=player.trick&&enemy!=null)//JキーかXボタンを押した＆ジャンプしている＆消費トリックが足りる＆敵がいる時のみ攻撃可能
        {
            enemy.Damage(strong_Damage);
            attacked = true;//攻撃した
            player.ConsumeTRICK(trickCost);
        }
    }


    //中攻撃(ジャンプ中にKキーかBボタンを入力)
    //消費トリックはプレイヤーの最大トリックのstrong_TrickCostPercent%分消費
    void Attack_Medium()
    {
        trickCost = player.trickMax * medium_TrickCostPercent / 100;//強攻撃時の消費トリック
        if ((Input.GetButtonDown("Fire2") || Input.GetKeyDown("k")) && jumpcontrol.jumpNow == true && trickCost <= player.trick && enemy != null)//KキーかBボタンを押した＆ジャンプしている＆消費トリックが足りる＆敵がいる時のみ攻撃可能
        {
            enemy.Damage(medium_Damage);
            attacked = true;//攻撃した
            player.ConsumeTRICK(trickCost);
        }
    }


    //弱攻撃(ジャンプ中にLキーかAボタンを入力)
    //消費トリックはプレイヤーの最大トリックのstrong_TrickCostPercent%分消費
    void Attack_Weak()
    {
        trickCost = player.trickMax * weak_TrickCostPercent / 100;//強攻撃時の消費トリック
        if ((Input.GetButtonDown("Fire3") || Input.GetKeyDown("l")) && jumpcontrol.jumpNow == true && trickCost <= player.trick && enemy != null)//LキーかAボタンを押した＆ジャンプしている＆消費トリックが足りる＆敵がいる時のみ攻撃可能
        {
            enemy.Damage(weak_Damage);
            attacked = true;//攻撃した
            player.ConsumeTRICK(trickCost);
        }
    }

    //ジャンプしていない時攻撃していない判定にする
    void AttackedtoFalseNoJump()
    {
        if (jumpcontrol.jumpNow == false)//水面に接地しているなら
        {
            attacked = false;//攻撃していない
        }
    }
}
