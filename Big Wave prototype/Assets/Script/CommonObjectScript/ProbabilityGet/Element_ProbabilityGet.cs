using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ProbabilityGetクラスの内部クラス(要素)の定義
public partial class ProbabilityGet<T>
{
    //ProbabilityGetクラスから取り出される要素のクラス
    [System.Serializable]
    class Element_ProbabilityGet
    {
        [Header("要素")]
        [SerializeField] T element;//要素
        [Header("確率")]
        [SerializeField] float probability;//確率

        public T Element { get { return element; } }
        public float Probability { get {  return probability; } }
    }
}
