using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者:杉山
//フェードイン
public class FadeIn : MonoBehaviour
{
    [Header("▼完全に画面がフェードインするまでにかかる時間")]
    [SerializeField] float fadeDuration = 1.0f;
    [Header("▼フェードインに使う画像")]
    [SerializeField] Image fadeImage;
    private float fadeTimer = 0f;//フェードイン時間の管理用
    const float _maxAlpha = 1;
    State_Fade _state = State_Fade.off;//フェードアウトの状況

    public State_Fade State { get { return _state; } }

    public void ReturnDefault()//フェードし終わったら必ず呼ばなければいけない処理(これをしないとこのコンポーネントの再利用ができない)
    {
        _state = State_Fade.off;
    }

    public void StartTrigger()//フェードアウトを最初から開始したい時に呼ぶ
    {
        if (_state == State_Fade.completed) return;//既に完了している時は呼べない

        fadeTimer = 0f;
        _state = State_Fade.fading;
    }

    public void CancelTrigger()//フェードアウトを止めたい時に呼ぶ
    {
        if (_state != State_Fade.fading) return;//フェード中でなければ無視

        _state = State_Fade.cancel;
    }

    public void ResumeTrigger()//フェードアウトを途中から再開したい時に呼ぶ
    {
        if (_state != State_Fade.cancel) return;//キャンセル状態でなければ無視

        _state = State_Fade.fading;
    }

    void Update()
    {
        FadeInDisplay();
    }

    private void FadeInDisplay()//フェードインの処理
    {
        //フェードアウト中でないなら処理をしない
        if (_state != State_Fade.fading) return;

        //経過時間をもとに透明度を計算
        fadeTimer += Time.deltaTime;
        float normalizedTime = fadeTimer / fadeDuration;
        float newAlpha = _maxAlpha - Mathf.Clamp01(normalizedTime);

        //フェードイン用の画像の透明度を更新
        Color currentColor = fadeImage.color;
        currentColor.a = newAlpha;
        fadeImage.color = currentColor;

        if (fadeTimer >= fadeDuration)
        {
            //完全に画面が明転したら完了状態に
            _state = State_Fade.completed;
        }
    }
}
