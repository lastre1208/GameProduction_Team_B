using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//登録したものの中からランダムに返す(型指定可能)
[System.Serializable]
public class RandomGet<T>
{
    [SerializeField] T[] elements;

    public T this[int i]
    {
        get { return elements[i]; }
    }

    public int ElementsNum { get { return elements.Length; } }//要素数を返す

    public RandomGet()//コンストラクタ
    {

    }

    //呼ばれるとランダムに返す
    public T Get()
    {
        if (elements == null)
        {
            Debug.Log("何も設定されていません");
            return default(T);
        }

        return elements[Random.Range(0,elements.Length)];
    }
}
