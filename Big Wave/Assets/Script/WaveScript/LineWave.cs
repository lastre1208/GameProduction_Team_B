using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//生成時にLineInstantiateを取得し、そのオブジェクトが消える時にLineInstantiateから消去する
public class LineWave : MonoBehaviour
{
    private LineInstantiate m_lineInstantiate;

    //生成時に呼び出す
    public void GetLineInstantiate(LineInstantiate lineInstantiate)
    {
        m_lineInstantiate = lineInstantiate;
    }

    //
    public void Remove()
    {
        m_lineInstantiate.Remove();
    }
}
