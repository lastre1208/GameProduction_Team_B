using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//作成者:杉山
//トリックの発動と(登録された)トリック時の処理を呼ぶ
public partial class Trick : MonoBehaviour
{
    //☆作成者:杉山
    [Header("トリック時の処理(メソッド)")]
    [SerializeField] UnityEvent eventsWhenTrick;//トリック時の処理(メソッド)
    [Header("必要なコンポーネント")]
    [SerializeField] JudgeJumpNow judgeJumpNow;
    [SerializeField] TrickPoint player_TrickPoint;
    [SerializeField] PushedButton_CurrentTrickPattern pushedButton_TrickPattern;
    //[SerializeField] CountTrickCombo countTrickCombo;
    //[SerializeField] CountTrickWhileJump countTrickWhileJump;
    //[SerializeField] ControllerVibeOfTrick controllerVibeOfTrick;
    //[SerializeField] ChargeFeverPointWhenTrick chargeFeverPointWhenTrick;
    //[SerializeField] Score_TrickCount score_TrickCount;
    //[SerializeField] HoverJump hoverJump;
    //[SerializeField] GenerateEffectAlongWay generateEffectAlongWay;

    HP enemy_Hp;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
    }

    //トリック発動
    public void TrickTrigger(TrickButton button)
    {
        pushedButton_TrickPattern.SetTrickPattern(button);//押されたボタンの種類を設定

        if (JudgeSuccessOfTrick())//トリック成功時
        {
            eventsWhenTrick.Invoke();//登録された全イベントを呼ぶ
            //EventsWhwnTrick();
        }
    }

    //void EventsWhwnTrick()//トリック時の処理(イベント)
    //{
    //    countTrickWhileJump.AddTrickCount();//ジャンプ中のトリック回数の加算
    //    countTrickCombo.AddCombo();//トリックコンボ回数の加算
    //    pushedButton_TrickPattern.TrickEffect();//トリック事の効果を発動
    //    controllerVibeOfTrick.Vibe();//トリック時のコントローラのバイブ
    //    chargeFeverPointWhenTrick.Charge();//フィーバーポイントのチャージ
    //    score_TrickCount.AddScore();//トリック回数のスコア加算
    //    hoverJump.HoverJumpTrigger();//ホバージャンプさせる
    //    generateEffectAlongWay.ActivateEffect();//ロープを伝うエフェクトを生成する
    //}

    bool JudgeSuccessOfTrick()//トリック成功かの判定(成功であればtrueを返す)
    {
        int trickCost = pushedButton_TrickPattern.TrickCost;//トリック消費量、押されたボタンに対応したトリックパターンのトリック消費量

        //ジャンプしている＆敵がいる時のみ攻撃可能＆消費トリックが足りる(ここでトリック消費の処理をする)
        if (judgeJumpNow.JumpNow() == true && enemy_Hp != null && player_TrickPoint.Consume(trickCost))
        {
            return true;//トリック成功
        }

        return false;//トリック失敗
    }

    //作成者:桑原

    //private bool tricked;//トリックしたかしていないかの判定

    //public bool Tricked
    //{
    //    get { return tricked; }
    //}

    //void Start()
    //{
    //tricked = false;
    //}

    //void Update()
    //{
    //TrickedtoFalseNoJump();//ジャンプしていない時攻撃していない判定にする
    //}

    //ジャンプしていない時攻撃していない判定にする
    //void TrickedtoFalseNoJump()
    //{
    //    if (jumpcontrol.JumpNow == false)//水面に接地しているなら
    //    {
    //        tricked = false;//攻撃していない
    //    }
    //}
}

