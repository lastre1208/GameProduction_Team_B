using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲーム開始前の準備段階で呼ぶイベントを登録
public class StartReadyEvent : MonoBehaviour
{
    [SerializeField] StartSignalEvent _startSignalEvent;
    [SerializeField] DelayDisplayTextSoundComp _readyEffect;//Ready？の文字と効果音を出す
    [SerializeField] GameObject _readyText;

    void Start()
    {
        _startSignalEvent.CompleteFadeInAction += CompleteFadeInEvent;
    }

    public void CompleteFadeInEvent()//フェードインが終わった時に呼ぶイベント
    {
        _readyEffect.DisplayTrigger();
        _readyText.SetActive(true);
    }
}
