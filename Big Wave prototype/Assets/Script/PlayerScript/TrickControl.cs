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

public partial class TrickControl : MonoBehaviour
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
    [Header("トリック回数のスコア")]
    [SerializeField] Score_TrickCount score_TrickCount;
    [SerializeField] CountTrickWhileJump countTrickWhileJump;//1ジャンプ中のトリック回数を数える機能

    AudioSource audioSource;//プレイヤーから音を出す為の処置。
    HP enemy_Hp;
    TRICKPoint player_TrickPoint;
    JumpControl jumpcontrol;
    Controller controller;
    FeverMode feverMode;
    Critical critical;
    CountTrickCombo countTrickCombo;
    HoverJump hoverJump;
    
    // Start is called before the first frame update
    void Start()
    {
        A_Trick.ButtonPattern = Button.A;
        B_Trick.ButtonPattern= Button.B;
        X_Trick.ButtonPattern=Button.X;
        Y_Trick.ButtonPattern = Button.Y;
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
        player_TrickPoint = gameObject.GetComponent<TRICKPoint>();
        jumpcontrol = gameObject.GetComponent<JumpControl>();
        controller = gameObject.GetComponent<Controller>();
        //☆福島君が書いた
        audioSource = GetComponent<AudioSource>();
        //
        feverMode= gameObject.GetComponent<FeverMode>();
        critical = gameObject.GetComponent<Critical>();
        countTrickCombo = gameObject.GetComponent<CountTrickCombo>();
        hoverJump = gameObject.GetComponent<HoverJump>();
    }

    // Update is called once per frame
    void Update()
    {
        countTrickWhileJump.ResetTrickCount(jumpcontrol.JumpNow);
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
            //tricked = true;//トリックした
            enemy_Hp.Hp -= Damage(button);
            controller.Vibe_Trick();//バイブさせる
            countTrickWhileJump.AddTrickCount();//1ジャンプ中のトリック回数を増やす(注:フィーバーゲージのチャージ前にこの処理を入れる)
            feverMode.ChargeFeverPoint(countTrickWhileJump.TrickCount);//フィーバーゲージのチャージ
            score_TrickCount.AddScore();//トリックによるスコアの加点
            countTrickCombo.AddCombo();//コンボ回数加算
            //☆作成者:福島
            audioSource.PlayOneShot(trickPattern.TrickSound);//効果音の再生
            //作成者:桑原
            hoverJump.HoverDelayJump();//ホバーさせる
        }
    }



    /////内部クラス/////

    //1ジャンプ中のトリック回数を数える
    [System.Serializable]
    private class CountTrickWhileJump
    {
        private int trickCount = 0;//一回のジャンプにしたトリックの回数

        public int TrickCount
        {
            get { return trickCount; }
        }

        public void ResetTrickCount(bool jumpNow)//トリック回数をリセット(update)
        {
            if (!jumpNow)//着地したら
            {
                trickCount = 0;//1ジャンプ中のトリック回数をリセット
            }
        }

        public void AddTrickCount()
        {
            trickCount++;
        }
    }
}
