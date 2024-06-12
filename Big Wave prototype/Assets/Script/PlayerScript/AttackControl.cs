using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class AttackControl : MonoBehaviour
{
    //☆塩が書いた
    [SerializeField] float strong_TrickCostPercent=50;//強攻撃時の消費トリック(プレイヤーの最大トリックのstrong_TrickCostPercent%分消費)
    [SerializeField] float medium_TrickCostPercent=30;//中攻撃時の消費トリック(プレイヤーの最大トリックのmedium_TrickCostPercent%分消費)
    [SerializeField] float weak_TrickCostPercent=10;//弱攻撃時の消費トリック(プレイヤーの最大トリックのweak_TrickCostPercent%分消費)
    [SerializeField] float strong_Damage = 100;//強攻撃時の敵に与えるダメージ
    [SerializeField] float medium_Damage = 60;//中攻撃時の敵に与えるダメージ
    [SerializeField] float weak_Damage = 20;//弱攻撃時の敵に与えるダメージ
    [SerializeField] float trick_DamageFactor = 0.5f;//トリックをためた時のダメージの上昇具合、1、２、3、nだとそれぞれトリック満タン時、トリック空っぽの時のダメージの2、3、4、(1+1*n)倍になる
    //☆福島君が書いた
    [SerializeField] AudioClip attackSound;//攻撃に用いる効果音。改善の余地あり
    private bool attacked;//攻撃したかしていないかの判定
   　AudioSource audioSource;//プレイヤーから音を出す為の処置。
    //
    Enemy enemy;
    Player player;
    JumpControl jumpcontrol;
   
    
    public bool Attacked
    {
        get { return attacked; }
    }

    // Start is called before the first frame update
    void Start()
    {
       attacked = false;
       enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
       player = gameObject.GetComponent<Player>();
       jumpcontrol = gameObject.GetComponent<JumpControl>();
        //☆福島君が書いた
        audioSource = GetComponent<AudioSource>();
        //
    }

    // Update is called once per frame
    void Update()
    {
        AttackedtoFalseNoJump();//ジャンプしていない時攻撃していない判定にする
    }

    //攻撃
    void Attack(float strength_TrickCostPercent,float strength_Damage)
    {
        float trickPercentage = player.Trick / player.TrickMax;//プレイヤーのトリックの(最大値に対しての現在のトリックの値)割合
        float trickCost = player.TrickMax * strength_TrickCostPercent / 100;//消費トリック
        if (jumpcontrol.JumpNow == true && trickCost <= player.Trick && enemy != null)//ジャンプしている＆消費トリックが足りる＆敵がいる時のみ攻撃可能
        {
            //player.AttackVibration(1.0f);
            //☆福島君が書いた
            audioSource.PlayOneShot(attackSound);//効果音の再生
            //
            enemy.Hp-=strength_Damage * (1 + trickPercentage * trick_DamageFactor);//トリックがたまっているときほどダメージが上昇するようになっている
            attacked = true;//攻撃した
            player.Trick-=trickCost;//トリック消費
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



    //☆桑原君が書いた
    //ジャンプしていない時攻撃していない判定にする
    void AttackedtoFalseNoJump()
    {
        if (jumpcontrol.JumpNow == false)//水面に接地しているなら
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
