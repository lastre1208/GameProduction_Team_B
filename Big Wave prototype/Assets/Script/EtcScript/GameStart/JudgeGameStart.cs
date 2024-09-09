using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームスタート時のカウントダウン
public class JudgeGameStart : MonoBehaviour
{
    [Header("画面遷移してから何秒でゲームを開始するか")]
    [SerializeField] float gameStartTime;//画面遷移してから何秒でゲームを開始するか
    private float remainingGameStartTime;//現在のゲーム開始までの残り時間
    private bool isStarted = false;//ゲームが開始されたか(カウントダウンは終わったか)
    private bool isStarted_Moment=false;//ゲームが開始された瞬間(カウントダウンは終わった瞬間)
    private bool isStartedBeforeFrame=false;//前のフレームのisStarted

    public float RemainingGameStartTime { get { return remainingGameStartTime; } }

    public bool IsStarted { get { return isStarted; } }

    public bool IsStarted_Moment { get { return isStarted_Moment; } }

    void Start()
    {
        remainingGameStartTime = gameStartTime;//現在のゲーム開始までの残り時間を設定
    }

    void Update()
    {
        UpdateCountDownTime();
        UpdateIsStarted_Moment();
        isStartedBeforeFrame = isStarted;
    }

    //ゲーム開始までの残り時間の更新
    //残り0秒になったらゲームを開始するようにする
    void UpdateCountDownTime()
    {
        if (isStarted) return;//ゲームが開始されたら残り時間の更新をしない
        //ゲームが開始されていない間、残り時間を更新
       
        remainingGameStartTime -= Time.deltaTime;

        if(remainingGameStartTime<=0) isStarted = true;//残り時間が0以下になったらゲーム開始
    }

    //ゲームが開始された瞬間の更新
    void UpdateIsStarted_Moment()
    {
        //前のフレームでまだゲーム開始されてないかつ現在のフレームで開始されていたらゲームが開始された瞬間をtrueにする
        if(!isStartedBeforeFrame&&isStarted)
        {
            isStarted_Moment = true;
        }
        else
        {
            isStarted_Moment = false;
        }
    }
}
