using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

public class CalculateButtonEffectScale
{
    public float CalculateScaledWidth(RectTransform rectTransform)//エフェクトの横幅の調整用
    {
        float width = rectTransform.rect.width;
        float scaleX = rectTransform.localScale.x;
        return width * scaleX;
    }

    public float CalculateScaledHeight(RectTransform rectTransform)//エフェクトの縦幅の調整用
    {
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;
        float scaleY = rectTransform.localScale.y;
        float aspectHeight = height < width ? width / height : height / width;

        return height * aspectHeight * scaleY;
    }
}
