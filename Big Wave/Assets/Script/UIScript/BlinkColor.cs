using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//色を点滅させる
[System.Serializable]
public class BlinkColor 
{
    [Header("点滅周期")]
    [SerializeField] float cycle;//点滅周期
    [Header("最も点滅している時の彩度の値")]
    [Range(0f, 100f)]
    [SerializeField] float s_maxValue;//最も点滅している時の彩度の値
    private float _time = 0;

    public BlinkColor()//コンストラクタ
    {
        _time = 0;
    }

    public Color Blinking(Color color)//点滅させる(点滅時の色を返す)
    {
        _time += Time.deltaTime;

        float h;//色相
        float s;//彩度
        float v;//明度

        //元の色からhsvを取得
        UnityEngine.Color.RGBToHSV(color,out h,out s,out v);

        //s(彩度)を変更
        float ratio = MathfExtend.Cos01(2*Mathf.PI*_time/cycle);
        
        s = ratio * (s-s_maxValue)+s_maxValue;

        //元の色に適用
        color = UnityEngine.Color.HSVToRGB(h, s, v);

        return color;
    }

}
