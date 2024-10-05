using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//トリックの操作
public class ControllerOfTrick : MonoBehaviour
{
    Trick trick;
    PushedButton_CurrentTrickPattern pushedButton_TrickPattern;
    JudgePauseNow judgePauseNow;

    void Start()
    {
        trick = GameObject.FindWithTag("Player").GetComponent<Trick>();
        pushedButton_TrickPattern = GameObject.FindWithTag("Player").GetComponent<PushedButton_CurrentTrickPattern>();
        judgePauseNow = GameObject.FindWithTag("PauseManager").GetComponent<JudgePauseNow>();
    }

    void Update()
    {
        Trick();
    }

    void Trick()//トリック
    {
        if (judgePauseNow.PauseNow) return;

        if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("h"))//HキーかYボタン
        {
            Trick_Process(Button.Y);
        }
        else if (Input.GetButtonDown("Fire2") || Input.GetKeyDown("j"))//JキーかXボタン
        {
            Trick_Process(Button.X);
        }
        else if (Input.GetButtonDown("Fire4") || Input.GetKeyDown("k"))//KキーかBボタン
        {
            Trick_Process(Button.B);
        }
        else if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("l"))//LキーかAボタン
        {
            Trick_Process(Button.A);
        }

        //自分(杉山)のコントローラー用
        //if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("h"))//HキーかYボタン
        //{
        //    Trick_Process(Button.Y);
        //}
        //else if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("j"))//JキーかXボタン
        //{
        //    Trick_Process(Button.X);
        //}
        //else if (Input.GetButtonDown("Fire2") || Input.GetKeyDown("k"))//KキーかBボタン
        //{
        //    Trick_Process(Button.B);
        //}
        //else if (Input.GetButtonDown("Fire4") || Input.GetKeyDown("l"))//LキーかAボタン
        //{
        //     Trick_Process(Button.A);
        //}
    }

    void Trick_Process(Button button)
    {
        pushedButton_TrickPattern.SetTrickPattern(button);//押されたボタンの種類を設定
        trick.TrickTrigger();//トリック
    }
}
