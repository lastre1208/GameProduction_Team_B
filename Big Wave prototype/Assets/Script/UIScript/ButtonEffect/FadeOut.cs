using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者:杉山
//フェードアウトする
public class FadeOut : MonoBehaviour
{
    [Header("▼完全に画面がフェードアウトするまでにかかる時間")]
    [SerializeField] float fadeDuration = 1.0f;
    [Header("▼フェードアウトに使う画像")]
    [SerializeField] Image fadeImage;
    private float fadeTimer = 0f;//フェードアウト時間の管理用
    State_Fade _fadeState = State_Fade.off;//フェードアウトの状況

    public State_Fade FadeState { get { return _fadeState; } }  

    public void ReturnDefault()//フェードし終わったら必ず呼ばなければいけない処理(これをしないとこのコンポーネントの再利用ができない)
    {
        _fadeState = State_Fade.off;
    }

    public void StartTrigger()//フェードアウトを最初から開始したい時に呼ぶ
    {
        if (_fadeState == State_Fade.completed) return;//既に完了している時は呼べない

        fadeTimer = 0f;
        _fadeState = State_Fade.fading;
    }

    public void CancelTrigger()//フェードアウトを止めたい時に呼ぶ
    {
        if (_fadeState != State_Fade.fading) return;//フェード中でなければ無視

        _fadeState = State_Fade.cancel;
    }

    public void ResumeTrigger()//フェードアウトを途中から再開したい時に呼ぶ
    {
        if (_fadeState != State_Fade.cancel) return;//キャンセル状態でなければ無視

        _fadeState = State_Fade.fading;
    }

    void Update()
    {
        FadeOutDisplay();
    }

    private void FadeOutDisplay()//フェードアウトの処理
    {
        //フェードアウト中でないなら処理をしない
        if (_fadeState!=State_Fade.fading) return;

        //経過時間をもとに透明度を計算
        fadeTimer += Time.deltaTime;
        float normalizedTime = fadeTimer / fadeDuration;
        float newAlpha = Mathf.Clamp01(normalizedTime);

        //フェードアウト用の画像の透明度を更新
        Color currentColor= fadeImage.color;
        currentColor.a = newAlpha;
        fadeImage.color = currentColor;

        if (fadeTimer >= fadeDuration)
        {
            //完全に画面が暗転したら動いていない状態に
            _fadeState=State_Fade.completed;
        }
    }
}
