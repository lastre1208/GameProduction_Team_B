using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//作成者:桑原
//ボタンのイベント
public class CustomButtonEvent : MonoBehaviour
{
    [Header("▼フェードアウトするかどうか")]
    [SerializeField] bool isFadeOut;
    [Header("ボタンの演出が終了した時に起こすイベント")]
    [SerializeField] UnityEvent _clickEvents;
    [SerializeField] MenuEffectController menuEffectController;
    [SerializeField] FadeOut fadeOut;

    private bool isButtonClicked = false;

    private void Update()
    {
        if (!isButtonClicked) return;

        ButtonAction();
    }

    public void ButtonClicked()
    {
        isButtonClicked = true;
    }

    private void ButtonAction()
    {

        if (menuEffectController!=null && !menuEffectController.EffectColorChanged) return;//ボタンの色が変わり切ってから

        if (isFadeOut && fadeOut.FadeState == State_Fade.off) fadeOut.StartTrigger();//フェードアウトする場合はフェードアウトさせる
        if (isFadeOut && fadeOut.FadeState != State_Fade.completed) return;//また、フェードアウトが終わるのを待ってからシーン移行させる(フェードアウトしない場合はそのままシーン移行)

        fadeOut.ReturnDefault();//再利用可能にする
        _clickEvents.Invoke();
    }
}
