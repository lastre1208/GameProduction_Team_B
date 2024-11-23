using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//フェードアウトする
public class FadeOut : MonoBehaviour
{
    [Header("▼完全に画面がフェードアウトするまでにかかる時間")]
    [SerializeField] float fadeDuration = 1.0f;
    [Header("▼フェードアウトに使う画像")]
    [SerializeField] Image fadeImage;
    private float fadeTimer = 0f;//フェードアウト時間の管理用
    private bool fadeStart;//フェードアウトが開始されたか
    private bool fadeCompleted;//フェードアウトが終わったか

    public bool FadeStart
    {
        get { return fadeStart; }
    }

    public bool FadeCompleted
    {
        get { return fadeCompleted; }
    }

    void Start()
    {
        fadeImage.color = new Color(0, 0, 0, 0);//フェードアウト用の画像を透明に設定

        fadeStart = false;
        fadeCompleted = false;
    }

    void Update()
    {
        FadeOutDisplay();
    }

    public void FadeOutTrigger()//フェードアウト開始したい時に呼ぶ
    {
        fadeStart = true;
    }

    private void FadeOutDisplay()//フェードアウトの処理
    {
        if (!fadeStart) return;//フェードアウトがまだ始まってないなら処理をしない

        fadeTimer += Time.deltaTime;
        float normalizedTime = fadeTimer / fadeDuration;
        float newAlpha = Mathf.Clamp01(normalizedTime);//経過時間をもとに透明度を計算
        fadeImage.color = new Color(0, 0, 0, newAlpha);//フェードアウト用の画像の透明度を更新

        if (fadeTimer >= fadeDuration)
        {
            fadeCompleted = true;//完全に画面が暗転した
        }
    }
}
