using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Button
{
    A,
    B,
    X,
    Y
}

public class TrickPattern : MonoBehaviour
{
    [Header("ボタンの種類")]
    [SerializeField] Button button;//ボタンの種類
    [Header("消費トリック(ゲージ本数)")]
    [SerializeField] int trickCost;//消費トリック
    [Header("トリックに用いる効果音")]
    [SerializeField] AudioClip soundEffect;//トリックに用いる効果音
    [Header("敵に与えるダメージ")]
    [SerializeField] float damageAmount = 100;//敵に与えるダメージ

    public Button Button { get { return button; } }
    public int TrickCost { get { return trickCost; } }
    public AudioClip SoundEffect { get { return soundEffect; } }
    public float DamageAmount { get {  return damageAmount; } }

}
