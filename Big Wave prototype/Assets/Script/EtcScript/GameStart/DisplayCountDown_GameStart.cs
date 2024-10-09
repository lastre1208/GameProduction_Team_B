using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//作成者:杉山
//ゲームスタート時のカウントダウンの演出
public class DisplayCountDown_GameStart : MonoBehaviour
{
    [Header("表示させるテキスト")]
    [SerializeField] TMP_Text countDownText;//表示させるテキスト
    [Header("残り秒数が変わるごとに出す効果音")]
    [SerializeField] AudioClip countDownSoundEffect;//残り秒数が変わるごとに出す効果音
    private int remainingGameStartTimeBeforeFrame_Display;//前フレームのゲーム開始までの残り時間(整数のみ)
    JudgeGameStart judgeGameStart;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        judgeGameStart = GameObject.FindWithTag("GameStartManager").GetComponent<JudgeGameStart>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCountDown();//カウントダウンの表示
    }

    void DisplayCountDown()//カウントダウンの表示
    {
        if (judgeGameStart.IsStarted) return;//ゲームが開始したらカウントダウンをしなくなる

        int remainingGameStartTime_Display = (int)Mathf.Ceil(judgeGameStart.RemainingGameStartTime);//表示する残り時間(例えば3～2.00...1なら3、2～1.00...1なら2になる)

        //前フレームと表示する残り時間が違ったら(変わっていたら)効果音を出す
        if (remainingGameStartTimeBeforeFrame_Display != remainingGameStartTime_Display)
        {
            audioSource.PlayOneShot(countDownSoundEffect);//ゲーム開始時の効果音を出す
        }

        countDownText.text = remainingGameStartTime_Display.ToString("0");

        remainingGameStartTimeBeforeFrame_Display = remainingGameStartTime_Display;
    }
}
