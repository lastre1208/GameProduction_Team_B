using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//数学系のメソッドを拡張したもの
public static class MathfExtend 
{
    public static float Cos01(float f)//cosの値を0～1で返すようにする
    {
        const float cosWidth = 2f;//cosの幅
        const float gap = 0.5f;//目標の値とcosの幅で割ったcosの値の差(cosの幅で割った時、cosは-0.5～0.5の値をとるのでそれを目標値の0～1にするための値)

        float ret = Mathf.Cos(f) / cosWidth + gap;

        return ret;
    }
}
