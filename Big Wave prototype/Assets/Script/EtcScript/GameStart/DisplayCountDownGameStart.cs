using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//作成者:杉山
//ゲーム開始のカウントダウンをする
public class DisplayCountDownGameStart : MonoBehaviour
{
    [Header("表示させるテキスト")]
    [SerializeField] TMP_Text countDownText;//表示させるテキスト
    [Header("ゲーム開始時に表示する文字")]
    [SerializeField] string startText;//ゲーム開始時に表示する文字
    [Header("ゲーム開始の文字を出す時間")]
    [SerializeField] float displayTime_GameStart;//ゲーム開始の文字を出す時間
    [Header("残り秒数が変わるごとに出す効果音")]
    [SerializeField] AudioClip countDownSoundEffect;//残り秒数が変わるごとに出す効果音
    [Header("ゲーム開始した瞬間に出す効果音")]
    [SerializeField] AudioClip gameStartSoundEffect;//ゲーム開始した瞬間に出す効果音
    private float remainingdisplayTime_GameStart;//ゲーム開始の文字を出す残り時間
    private int remainingGameStartTimeBeforeFrame_Display;//前フレームのゲーム開始までの残り時間(整数のみ)
    JudgeGameStart judgeGameStart;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        judgeGameStart=GetComponent<JudgeGameStart>();
        audioSource = GetComponent<AudioSource>();
        remainingdisplayTime_GameStart = displayTime_GameStart;//ゲーム開始の文字を出す残り時間を設定
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
    }

    void CountDown()//ゲーム開始のカウントダウン
    {
        if (remainingdisplayTime_GameStart <= 0) return;//ゲーム開始の文字を出す残り時間がなくなったらカウントダウンをしなくなる


        bool gameStart = judgeGameStart.IsStarted;//ゲームが開始されたか

        if (gameStart)//ゲームが開始されたら
        {
            DisplayGameStart();//ゲーム開始の文字を表示
        }
        else//まだゲームが開始されていないなら
        {
            DisplayRemainingTime();//開始までの残り時間を表示
        }
    }

    void DisplayGameStart()//ゲーム開始の文字を表示
    {
        if(judgeGameStart.IsStarted_Moment)//ゲームが開始された瞬間
        {
            countDownText.text = startText;//ゲーム開始の文字が出る
            audioSource.PlayOneShot(gameStartSoundEffect);//ゲーム開始時の効果音を出す
        }
        
        remainingdisplayTime_GameStart -= Time.deltaTime;//ゲーム開始の文字を出す残り時間を更新

        if(remainingdisplayTime_GameStart<=0)//ゲーム開始の文字を出す残り時間がなくなったら
        {
            countDownText.enabled = false;//文字を非表示
        }
    }

    void DisplayRemainingTime()//開始までの残り時間を表示
    {
        int remainingGameStartTime_Display = (int)Mathf.Ceil(judgeGameStart.RemainingGameStartTime);//表示する残り時間(例えば3～2.00...1なら3、2～1.00...1なら2になる)

        //前フレームと表示する残り時間が違ったら(変わっていたら)効果音を出す
        if(remainingGameStartTimeBeforeFrame_Display!=remainingGameStartTime_Display)
        {
            audioSource.PlayOneShot(countDownSoundEffect);//ゲーム開始時の効果音を出す
        }

        countDownText.text = remainingGameStartTime_Display.ToString("0"); 

        remainingGameStartTimeBeforeFrame_Display=remainingGameStartTime_Display;
    }
}
