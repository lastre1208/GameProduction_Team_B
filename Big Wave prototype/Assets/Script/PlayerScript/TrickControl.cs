using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

enum TrickType
{
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
    //☆作成者:杉山
    [Header("Aボタンのトリック")]
    [SerializeField] Trick A_Trick;
    [Header("Bボタンのトリック")]
    [SerializeField] Trick B_Trick;
    [Header("Xボタンのトリック")]
    [SerializeField] Trick X_Trick;
    [Header("Yボタンのトリック")]
    [SerializeField] Trick Y_Trick;
    [Header("通常時の敵に与えるダメージ")]
    [SerializeField] float damageAmount = 100;//通常時の敵に与えるダメージ
    [Header("トリック使用時の滞空時間")]
    [SerializeField] float hoverTime = 0.2f;//トリック使用時の滞空時間
    [Header("滞空終了時に起こるジャンプの強さ")]
    [SerializeField] float hoverJumpStrength = 2f;//滞空終了時に起こるジャンプの強さ
    private bool tricked;//トリックしたかしていないかの判定
    private int trickCount=0;//一回のジャンプにしたトリックの回数
    
    private Coroutine HoverCoroutine;
    AudioSource audioSource;//プレイヤーから音を出す為の処置。
    HP enemy_Hp;
    TRICKPoint player_TrickPoint;
    JumpControl jumpcontrol;
    Controller controller;
    ManagementOfScore managementOfScore;
    ProcessFeverMode processFeverPoint;
    
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
        tricked = false;
        trickCount = 0;
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
        player_TrickPoint = gameObject.GetComponent<TRICKPoint>();
        jumpcontrol = gameObject.GetComponent<JumpControl>();
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
    }

    float Damage()//敵に与えるダメージ合計
    {
        return damageAmount* processFeverPoint.CurrentPowerUp_GrowthRate;
    }

    //トリック
    void Trick(Trick trick)
    {
        if (jumpcontrol.JumpNow == true && player_TrickPoint.Consume(trick.TrickCost) && enemy_Hp != null)//ジャンプしている＆消費トリックが足りる(ここでトリック消費の処理をする)＆敵がいる時のみ攻撃可能
        {
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
            }

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


    public void Trick_A()
    {
        Trick(A_Trick);
    }

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
