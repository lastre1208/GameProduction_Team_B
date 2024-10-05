using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//トリックパターンの抽象クラス
public enum Button
{
    A,
    B,
    X,
    Y
}

public abstract class TrickPatternTypeBase : MonoBehaviour
{
    [Header("ボタンの種類")]
    protected Button button;//ボタンの種類
    [Header("消費トリック(ゲージ本数)")]
    [SerializeField] int trickCost;//消費トリック
    
    public Button Button { get { return button; } }
    public int TrickCost { get { return trickCost; } }
    
    public virtual void TrickEffect() {}//トリックの効果

}
