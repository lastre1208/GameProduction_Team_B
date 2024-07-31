using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

enum TrickType
{
   // attack,//攻撃(敵にダメージを与える)
    //heal,//体力回復
   // buff,//バフ
   type_A,
   type_B, 
   type_X, 
   type_Y
}

[System.Serializable]
class Trick
{
    [Header("消費トリック(ゲージ本数)")]
    [SerializeField] int trickCost;//消費トリック(プレイヤーの最大トリックのtrickCostPercent%分消費)
    //☆福島君が書いた
    [Header("トリックに用いる効果音")]
    [SerializeField] AudioClip trickSound;//トリックに用いる効果音
    //
    private TrickType trickPattern;//攻撃の種類

    public int TrickCost
    {
        get { return trickCost; }
    }
    public AudioClip TrickSound
    {
        get { return trickSound; }
    }

    public TrickType TrickPattern
    {
        set { trickPattern = value; }
        get { return trickPattern; }
    }
}

public class TrickControl : MonoBehaviour
{
    //☆塩が書いた
    //[Header("攻撃のトリック")]
    //[SerializeField] Trick attackTrick;//攻撃のトリック
    //[Header("回復のトリック")]
    //[SerializeField] Trick healTrick;//回復のトリック
    [Header("Aボタンのトリック")]
    [SerializeField] Trick A_Trick;
    [Header("Bボタンのトリック")]
    [SerializeField] Trick B_Trick;
    [Header("Xボタンのトリック")]
    [SerializeField] Trick X_Trick;
    [Header("Yボタンのトリック")]
    [SerializeField] Trick Y_Trick;
    //[Header("バフのトリック")]
    //[SerializeField] Trick buffTrick;//バフのトリック
    [Header("通常時の敵に与えるダメージ")]
    [SerializeField] float damageAmount = 100;//通常時の敵に与えるダメージ
    //[Header("HPの回復量")]
    //[SerializeField] float healAmount = 50;//HPの回復量
    ///*[Header("攻撃力増加のバフ")]
    //[SerializeField] bool powerUpBuff=false;//攻撃力増加のバフ
    //[Header("チャージトリック量増加のバフ")]
    //[SerializeField] bool chargeTrickBuff=false;//チャージトリック量増加のバフ*/
    //[Header("トリック強化のバフ")]
    //[SerializeField] bool trickBoostBuff = false;//トリック強化のバフ
    //[SerializeField] float trick_DamageFactor = 0.5f;//トリックをためた時のダメージの上昇具合、1、２、3、nだとそれぞれトリック満タン時、トリック空っぽの時のダメージの2、3、4、(1+1*n)倍になる
    [Header("トリック使用時の滞空時間")]
    [SerializeField] float hoverTime = 0.2f;//トリック使用時の滞空時間
    [Header("滞空終了時に起こるジャンプの強さ")]
    [SerializeField] float hoverJumpStrength = 2f;//滞空終了時に起こるジャンプの強さ
    //[Header("回避の無敵時間")]
    //[SerializeField] float avoidTime = 10f;
    private bool tricked;//トリックしたかしていないかの判定
    private int trickCount=0;//一回のジャンプにしたトリックの回数
    private bool consumedTrickPoint;//トリックゲージを消費したかどうかの判定
    //private bool avoidNow;
    //private float avoidTimeCount;
    
    private Coroutine HoverCoroutine;
    //Material Avoidmaterial;
    AudioSource audioSource;//プレイヤーから音を出す為の処置。
    HP enemy_Hp;
    TRICKPoint player_TrickPoint;
    JumpControl jumpcontrol;
    //BuffOfPlayer buffOfPlayer;
    Controller controller;
    ManagementOfScore managementOfScore;
    ProcessFeverMode processFeverPoint;
    JudgeChargeNow JudgeChargeNow;
    
    public bool Tricked
    {
        get { return tricked; }
    }

    // Start is called before the first frame update
    void Start()
    {
        A_Trick.TrickPattern = TrickType.type_A;
        B_Trick.TrickPattern= TrickType.type_B;
        X_Trick.TrickPattern=TrickType.type_X;
        Y_Trick.TrickPattern = TrickType.type_Y;
        //attackTrick.TrickPattern = TrickType.attack;
        //healTrick.TrickPattern = TrickType.heal;
       // buffTrick.TrickPattern = TrickType.buff;
        tricked = false;
        //avoidNow = false;
        trickCount = 0;
        JudgeChargeNow=gameObject.GetComponent<JudgeChargeNow>(); 
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
        player_TrickPoint = gameObject.GetComponent<TRICKPoint>();
        jumpcontrol = gameObject.GetComponent<JumpControl>();
        //buffOfPlayer = gameObject.GetComponent<BuffOfPlayer>(); 
        controller = gameObject.GetComponent<Controller>();
        //☆福島君が書いた
        audioSource = GetComponent<AudioSource>();
        //
        managementOfScore = GameObject.FindWithTag("ScoreManager").GetComponent<ManagementOfScore>();
        processFeverPoint= gameObject.GetComponent<ProcessFeverMode>();
    }

    // Update is called once per frame
    void Update()
    {
        ResetTrickCount();
        TrickedtoFalseNoJump();//ジャンプしていない時攻撃していない判定にする
        //AvoidUpdate();
       
    }

    float Damage()//敵に与えるダメージ合計
    {
        //return damageAmount * buffOfPlayer.PowerUp.CurrentGrowthRate * processFeverPoint.CurrentPowerUp_GrowthRate;
        return damageAmount* processFeverPoint.CurrentPowerUp_GrowthRate;
    }

    //float Heal()
    //{
    //    return healAmount;
    //}
    //private void Avoid()
    //{
    //    if (avoidNow)
    //    {
    //        player.tag = ("AvoidNow");
    //        GetComponent<MeshRenderer>().material.color = Color.red;
    //    }

    //}
   
    //public void OnAvoid()
    //{
    //    if (!avoidNow && !jumpcontrol.JumpNow && !JudgeChargeNow.ChargeNow())
    //    {
            
    //        avoidNow = true;
    //        avoidTimeCount = avoidTime;
    //        Avoid();
    //    }
    //}

    //public void AvoidUpdate()
    //{
    //    if (avoidNow)
    //    {
    //        avoidTimeCount--;
    //        if (avoidTimeCount < 0)
    //        {
    //            avoidNow = false;
    //            player.tag = ("Player");
    //            GetComponent<MeshRenderer>().material.color = Color.white;
    //        }
    //    }
    //}
    //トリック
    void Trick(Trick trick)
    {
        if (jumpcontrol.JumpNow == true && /*player.ConsumeTrickPoint(trick.TrickCost) &&*/ enemy_Hp != null)//ジャンプしている＆消費トリックが足りる(ここでトリック消費の処理をする)＆敵がいる時のみ攻撃可能
        {
            consumedTrickPoint = false;

            //if(trick.TrickPattern == TrickType.buff
            //    && buffOfPlayer.TrickBoost.BuffStockCount >= buffOfPlayer.TrickBoost.BuffStockMax)
            ////バフのトリックが行われ、かつバフのストックが最大数たまっているなら
            //{
            //    return;//トリックの処理を行わない
            //}

            if (player_TrickPoint.Consume(trick.TrickCost))
            {
                consumedTrickPoint = true;

                switch (trick.TrickPattern)
                {
                    case TrickType.type_A:
                        enemy_Hp.Hp -= Damage(); 
                        break;
                    case TrickType.type_B: 
                        enemy_Hp.Hp -= Damage();
                        break;
                    case TrickType.type_X:
                        enemy_Hp.Hp -= Damage();
                        break;
                    case TrickType.type_Y:
                        enemy_Hp.Hp -= Damage();
                        break;

                        //case TrickType.attack://敵にダメージを与える
                        //   // buffOfPlayer.TrickBoost.DecrementBuffStock();
                        //    enemy.Hp -= Damage();
                        //    break;
                        //case TrickType.heal://プレイヤーの体力を回復する
                        //   // buffOfPlayer.TrickBoost.DecrementBuffStock();
                        //    //player.Hp += healAmount;
                        //    player.Hp += Heal();
                        //    break;


                        //case TrickType.buff://プレイヤーにバフをかける
                        //    /*if (powerUpBuff)
                        //    {
                        //        buffOfPlayer.PowerUp.Activate();
                        //    }
                        //    if (chargeTrickBuff)
                        //    {
                        //        buffOfPlayer.ChargeTrick.Activate();
                        //    }*/

                        //    if(trickBoostBuff)
                        //    {
                        //        buffOfPlayer.TrickBoost.IncreaseBuffStock();//バフストック数の増加
                        //        buffOfPlayer.TrickBoost.Activate();
                        //    }
                        //    break;
                }
            }

            if (consumedTrickPoint)
            {
                //全てのトリックの共通処理
                tricked = true;//トリックした
                controller.Vibe_Trick();//バイブさせる
                                        //☆福島君が書いた
                audioSource.PlayOneShot(trick.TrickSound);//効果音の再生
                                                          //
                managementOfScore.AddTrickScore();//トリック成功によるスコアの加点
                trickCount++;//1回トリックした(1ジャンプ中に)
                processFeverPoint.ChargeFeverPoint(trickCount);
                HoverCoroutine = StartCoroutine(HoverJump());
            }
        }
    }

    //バフのトリック(ジャンプ中にJキーかXボタンを入力)
    //public void Trick_Buff()
    //{
    //    Trick(buffTrick);
    //}

    //攻撃のトリック(ジャンプ中にKキーかBボタンを入力)
    //消費トリックはプレイヤーの最大トリックのstrong_TrickCostPercent%分消費
    public void Trick_A()
    {
        Trick(A_Trick);
    }

    //回復のトリック(ジャンプ中にLキーかAボタンを入力)
    //消費トリックはプレイヤーの最大トリックのstrong_TrickCostPercent%分消費
    public void Trick_B()
    {
        Trick(B_Trick);
    }
    public void Trick_X()
    {
        Trick(X_Trick);
    }
    public void Trick_Y()
    {
        Trick(Y_Trick);
    }
    void ResetTrickCount()
    {
        if (jumpcontrol.JumpNow == false)//着地したら1ジャンプ中のトリック回数をリセット
        {
            trickCount = 0;
        }
    }

    //☆桑原君が書いた
    //ジャンプしていない時攻撃していない判定にする
    void TrickedtoFalseNoJump()
    {
        if (jumpcontrol.JumpNow == false)//水面に接地しているなら
        {
            tricked = false;//攻撃していない
        }
    }
    IEnumerator HoverJump()
    {
        jumpcontrol.rb.useGravity = false;
        jumpcontrol.rb.velocity = Vector3.zero;//重力とジャンプの運動を一時的に止める

        yield return new WaitForSeconds(hoverTime);

        jumpcontrol.rb.useGravity = true;
        jumpcontrol.rb.velocity= new(0, hoverJumpStrength, 0);
    }
}
