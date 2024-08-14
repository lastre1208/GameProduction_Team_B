using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Button
{
   A,
   B, 
   X, 
   Y
}

[System.Serializable]
public class TrickPattern
{
    [Header("消費トリック(ゲージ本数)")]
    [SerializeField] int trickCost;//消費トリック(プレイヤーの最大トリックのtrickCostPercent%分消費)
    //☆作成者:福島
    [Header("トリックに用いる効果音")]
    [SerializeField] AudioClip trickSound;//トリックに用いる効果音
    private Button buttonPattern;//ボタンの種類

    public int TrickCost
    {
        get { return trickCost; }
    }
    public AudioClip TrickSound
    {
        get { return trickSound; }
    }

    public Button ButtonPattern
    {
        set { buttonPattern = value; }
        get { return buttonPattern; }
    }
}

public class TrickControl : MonoBehaviour
{
    //☆作成者:杉山
    [Header("Aボタンのトリック")]
    [SerializeField] TrickPattern A_Trick;
    [Header("Bボタンのトリック")]
    [SerializeField] TrickPattern B_Trick;
    [Header("Xボタンのトリック")]
    [SerializeField] TrickPattern X_Trick;
    [Header("Yボタンのトリック")]
    [SerializeField] TrickPattern Y_Trick;
    [Header("通常時の敵に与えるダメージ")]
    [SerializeField] float damageAmount = 100;//通常時の敵に与えるダメージ
    [Header("トリック使用時の滞空時間")]
    [SerializeField] float hoverTime = 0.2f;//トリック使用時の滞空時間
    [Header("滞空終了時に起こるジャンプの強さ")]
    [SerializeField] float hoverJumpStrength = 2f;//滞空終了時に起こるジャンプの強さ
    //private bool tricked;//トリックしたかしていないかの判定
    private int trickCount=0;//一回のジャンプにしたトリックの回数
    
    private Coroutine HoverCoroutine;
    AudioSource audioSource;//プレイヤーから音を出す為の処置。
    HP enemy_Hp;
    TRICKPoint player_TrickPoint;
    JumpControl jumpcontrol;
    Rigidbody rb;
    Controller controller;
    FeverMode feverMode;
    Critical critical;
    
    //public bool Tricked
    //{
    //    get { return tricked; }
    //}

    // Start is called before the first frame update
    void Start()
    {
        A_Trick.ButtonPattern = Button.A;
        B_Trick.ButtonPattern= Button.B;
        X_Trick.ButtonPattern=Button.X;
        Y_Trick.ButtonPattern = Button.Y;
        //tricked = false;
        trickCount = 0;
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
        player_TrickPoint = gameObject.GetComponent<TRICKPoint>();
        jumpcontrol = gameObject.GetComponent<JumpControl>();
        rb = gameObject.GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<Controller>();
        //☆福島君が書いた
        audioSource = GetComponent<AudioSource>();
        //
        feverMode= gameObject.GetComponent<FeverMode>();
        critical = gameObject.GetComponent<Critical>();
    }

    // Update is called once per frame
    void Update()
    {
        ResetTrickCount();
        //TrickedtoFalseNoJump();//ジャンプしていない時攻撃していない判定にする
    }

    float Damage(Button button)//敵に与えるダメージ合計
    {
        return damageAmount* feverMode.CurrentPowerUp_GrowthRate*critical.CriticalDamageRate(button);
    }

    //トリック
    public void Trick(Button button)
    {
        TrickPattern trickPattern = A_Trick;//未割り当てだとエラーが出るのでとりあえず最初に割り当てる
        //ここで割り当て
        switch (button)
        {
            case Button.A:
                trickPattern = A_Trick;
                break;
            case Button.B:
                trickPattern = B_Trick;
                break;
            case Button.X:
                trickPattern = X_Trick;
                break;
            case Button.Y:
                trickPattern = Y_Trick;
                break;
        }

        if (jumpcontrol.JumpNow == true && enemy_Hp != null && player_TrickPoint.Consume(trickPattern.TrickCost))//ジャンプしている＆敵がいる時のみ攻撃可能＆消費トリックが足りる(ここでトリック消費の処理をする)
        {
            //全てのトリックの共通処理
            //tricked = true;//トリックした
            enemy_Hp.Hp -= Damage(button);
            controller.Vibe_Trick();//バイブさせる
            //☆福島君が書いた
            audioSource.PlayOneShot(trickPattern.TrickSound);//効果音の再生
            //トリック成功によるスコアの加点
            trickCount++;//1回トリックした(1ジャンプ中に)
            feverMode.ChargeFeverPoint(trickCount);//フィーバーゲージのチャージ
            HoverCoroutine = StartCoroutine(HoverJump());
        }
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
    //void TrickedtoFalseNoJump()
    //{
    //    if (jumpcontrol.JumpNow == false)//水面に接地しているなら
    //    {
    //        tricked = false;//攻撃していない
    //    }
    //}

    IEnumerator HoverJump()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;//重力とジャンプの運動を一時的に止める

        yield return new WaitForSeconds(hoverTime);

        rb.useGravity = true;
        rb.velocity= new(0, hoverJumpStrength, 0);
    }
}
