using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//数学系のメソッドを拡張したもの
public static class MathfExtend 
{
    const float cosWidth = 2f;//cosの幅(-1～1)
    const float sinWidth = 2f;//sinの幅(-1～1)

    public static float Cos01(float f)//cosの値を0～1で返すようにする(引数が0 or 2πの時は1、π/2 or 3π/2の時は0.5、πの時は0)
    {
        const float gap = 0.5f;//目標の値とcosの幅で割ったcosの値の差(cosの幅で割った時、cosは-0.5～0.5の値をとるのでそれを目標値の0～1にするための値)

        float ret = Mathf.Cos(f) / cosWidth + gap;

        return ret;
    }

    public static float Sin01(float f)//sinの値を0～1で返すようにする(引数が0 or π or 2πの時は0.5、π/2の時は1、 3π/2の時は0)
    {
        const float gap = 0.5f;//目標の値とcosの幅で割ったcosの値の差(cosの幅で割った時、cosは-0.5～0.5の値をとるのでそれを目標値の0～1にするための値)

        float ret= Mathf.Sin(f) / sinWidth + gap;

        return ret;
    }
}
