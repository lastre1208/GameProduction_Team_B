using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者：桑原

public class ClickedEffectManager : CalculateButtonEffectScale
{
    private RectTransform menuPanel;
    private GameObject effectPrefab;
    private Color effectColor;
    private GameObject leftEffect;
    private GameObject rightEffect;

    private const float aspectRatio = 0.75f;
    private const float sizeOffset = 5f;

    private bool isEffectGenerated = false;//エフェクトが生成されたか

    public GameObject EffectPrefab
    {
        get { return leftEffect; }
    }

    public bool IsEffectGenerated
    {
        get { return isEffectGenerated; }
    }

    public ClickedEffectManager(RectTransform menuPanel, GameObject effectPrefab, Color effectColor)
    {
        this.menuPanel = menuPanel;
        this.effectPrefab = effectPrefab;
        this.effectColor = effectColor;
    }

    public void GenerateEffects(RectTransform buttonRect)//エフェクトの生成
    {
        DestroyEffects();
        leftEffect = CreateEffect(buttonRect, true);
        rightEffect = CreateEffect(buttonRect, false);
        SetEffectColor();
        isEffectGenerated = true;
    }

    public void DestroyEffects()//エフェクトの破棄
    {
        if (leftEffect != null) Object.DestroyImmediate(leftEffect);
        if (rightEffect != null) Object.DestroyImmediate(rightEffect);
        isEffectGenerated = false;
    }

    private GameObject CreateEffect(RectTransform buttonRect, bool isLeft)//エフェクトの生成・調整
    {
        GameObject effect = Object.Instantiate(effectPrefab, menuPanel);
        RectTransform effectRect = effect.GetComponent<RectTransform>();

        float panelHalfWidth = CalculateScaledWidth(menuPanel) * 0.5f;

        float buttonHalfWidth = CalculateScaledWidth(buttonRect) * 0.5f;

        float buttonLeft = buttonRect.anchoredPosition.x - buttonHalfWidth;
        float buttonRight = buttonRect.anchoredPosition.x + buttonHalfWidth;

        float effectRectWidth = isLeft
            ? ((panelHalfWidth + buttonLeft) + sizeOffset) / menuPanel.localScale.x
            : ((panelHalfWidth - buttonRight) + sizeOffset) / menuPanel.localScale.x;//エフェクトの横幅をパネル端からボタン端までの幅に設定

        float effectRectHeight = CalculateScaledHeight(buttonRect);//エフェクトの縦幅を設定

        effectRect.sizeDelta = new Vector2(effectRectWidth, effectRectHeight);//パネルのスケールを考慮して幅を設定

        float effectWidth = effectRect.rect.width * 0.5f * menuPanel.localScale.x;//スケールを考慮してエフェクトの半分の幅を取得

        effectRect.anchoredPosition = new Vector2(
            isLeft ? (-panelHalfWidth + effectWidth) / menuPanel.localScale.x : (panelHalfWidth - effectWidth) / menuPanel.localScale.x, buttonRect.anchoredPosition.y);

        if (!isLeft) effectRect.localRotation = Quaternion.Euler(0, 180, 0);//左右反転処理

        return effect;
    }

    private void SetEffectColor()//エフェクトの色の設定
    {
        if (leftEffect != null)
        {
            Image effectImage = leftEffect.GetComponent<Image>();
            effectImage.color = effectColor;
        }

        if (rightEffect != null)
        {
            Image effectImage = rightEffect.GetComponent<Image>();
            effectImage.color = effectColor;
        }
    }
}
