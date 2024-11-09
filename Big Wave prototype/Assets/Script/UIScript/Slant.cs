using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//画像を斜めに減らしたりする
public class Slant
{
    const float maxRatio = 1;//割合の最大値
    const float minRatio = 0;//割合の最小値

    public Slant()//コンストラクタ
    {

    }

    public void MakeSlant(RectTransform gauge,float ratio)
    {
        ratio = Mathf.Clamp(ratio,0,1);

        float xPosition = Mathf.Lerp(0, -368, 1 - ratio);
        gauge.anchoredPosition = new Vector2(xPosition, gauge.anchoredPosition.y);
    }
}
