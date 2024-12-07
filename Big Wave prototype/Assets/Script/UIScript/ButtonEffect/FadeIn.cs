using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者:杉山
//フェードイン
public class FadeIn : MonoBehaviour
{
    [Header("▼完全に画面がフェードアウトするまでにかかる時間")]
    [SerializeField] float fadeDuration = 1.0f;
    [Header("▼フェードアウトに使う画像")]
    [SerializeField] Image fadeImage;
    private float fadeTimer = 0f;//フェードアウト時間の管理用
    private bool fadeStart = false;//フェードアウトが開始されたか
    private bool fadeCompleted = false;//フェードアウトが終わったか
    const float _maxAlpha = 1;

    public bool FadeStart
    {
        get { return fadeStart; }
    }

    public bool FadeCompleted
    {
        get { return fadeCompleted; }
    }

    void Update()
    {
        FadeOutDisplay();
    }

    public void FadeOutTrigger()//フェードアウト開始したい時に呼ぶ
    {
        fadeStart = true;
        fadeTimer = 0f;
        fadeCompleted = false;
    }

    private void FadeOutDisplay()//フェードアウトの処理
    {
        if (!fadeStart || fadeCompleted) return;//フェードアウトがまだ始まってないもしくはフェードアウトが完了したなら、処理をしない

        //経過時間をもとに透明度を計算
        fadeTimer += Time.deltaTime;
        float normalizedTime = fadeTimer / fadeDuration;
        float newAlpha = _maxAlpha - Mathf.Clamp01(normalizedTime);

        //フェードアウト用の画像の透明度を更新
        Color currentColor = fadeImage.color;
        currentColor.a = newAlpha;
        fadeImage.color = currentColor;

        if (fadeTimer >= fadeDuration)
        {
            fadeCompleted = true;//完全に画面が暗転した
        }
    }
}
