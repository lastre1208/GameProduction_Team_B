using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//作成者:杉山
//トリックパターンの抽象クラス
public enum Button
{
    A,
    B,
    X,
    Y
}

public class TrickPatternEffect : MonoBehaviour
{
    [Header("ボタンの種類")]
    [SerializeField] Button button;//ボタンの種類
    [Header("消費トリック量")]
    [SerializeField] int trickCost;
    [Header("トリック時の効果(イベント)")]
    [SerializeField] UnityEvent trickEffectEvent;
    
    public Button Button { get { return button; } }
    public int TrickCost { get {  return trickCost; } }
    
    public virtual void TrickEffect()//トリックの効果
    {
        trickEffectEvent.Invoke();
    }

}
