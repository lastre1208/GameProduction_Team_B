using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class AttackControl : MonoBehaviour
{
    [SerializeField] float strong_TrickCostPercent=50;//強攻撃時の消費トリック(プレイヤーの最大トリックのstrong_TrickCostPercent%分消費)
    [SerializeField] float medium_TrickCostPercent=30;//中攻撃時の消費トリック(プレイヤーの最大トリックのmedium_TrickCostPercent%分消費)
    [SerializeField] float weak_TrickCostPercent=10;//弱攻撃時の消費トリック(プレイヤーの最大トリックのweak_TrickCostPercent%分消費)
    [SerializeField] float strong_Damage = 100;//強攻撃時の敵に与えるダメージ
    [SerializeField] float medium_Damage = 60;//中攻撃時の敵に与えるダメージ
    [SerializeField] float weak_Damage = 20;//弱攻撃時の敵に与えるダメージ
    [SerializeField] float trick_DamageFactor = 0.5f;//トリックをためた時のダメージの上昇具合、1、２、3、nだとそれぞれトリック満タン時、トリック空っぽの時のダメージの2、3、4、(1+1*n)倍になる
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
        AttackedtoFalseNoJump();//ジャンプしていない時攻撃していない判定にする
    }

    //攻撃
    void Attack(float strength_TrickCostPercent,float strength_Damage)
    {
        float trickPercentage = player.trick / player.trickMax;//プレイヤーのトリックの(最大値に対しての現在のトリックの値)割合
        float trickCost = player.trickMax * strength_TrickCostPercent / 100;//消費トリック
        if (jumpcontrol.jumpNow == true && trickCost <= player.trick && enemy != null)//ジャンプしている＆消費トリックが足りる＆敵がいる時のみ攻撃可能
        {
            //player.AttackVibration(1.0f);
            enemy.Damage(strength_Damage * (1 + trickPercentage * trick_DamageFactor));
            attacked = true;//攻撃した
            player.ConsumeTRICK(trickCost);

        }
    }

    //強攻撃(ジャンプ中にJキーかXボタンを入力)
    //消費トリックはプレイヤーの最大トリックのstrong_TrickCostPercent%分消費
    public void Attack_Strong()
    {
        Attack(strong_TrickCostPercent,strong_Damage);
    }


    //中攻撃(ジャンプ中にKキーかBボタンを入力)
    //消費トリックはプレイヤーの最大トリックのstrong_TrickCostPercent%分消費
    public void Attack_Medium()
    {
        Attack(medium_TrickCostPercent, medium_Damage);
    }


    //弱攻撃(ジャンプ中にLキーかAボタンを入力)
    //消費トリックはプレイヤーの最大トリックのstrong_TrickCostPercent%分消費
    public void Attack_Weak()
    {
        Attack(weak_TrickCostPercent, weak_Damage);
    }

    //ジャンプしていない時攻撃していない判定にする
    void AttackedtoFalseNoJump()
    {
        if (jumpcontrol.jumpNow == false)//水面に接地しているなら
        {
            attacked = false;//攻撃していない
        }
    }
    //private IEnumerator StopVibration()//振動を止める
    //{
    //    yield return new WaitForSeconds(0.2f);
    //    if (player.gamepad != null)
    //    {
    //        player.gamepad.SetMotorSpeeds(0, 0);
    //    }
    //}
}
