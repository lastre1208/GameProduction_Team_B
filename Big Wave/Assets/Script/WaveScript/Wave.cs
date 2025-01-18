using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーに触れられたらトリックポイントをチャージさせる
public class Wave : MonoBehaviour
{
    private bool isTouched=false;//プレイヤーに触れられたか
    [Header("波乗りした時に溜まるトリック量")]
    [SerializeField] float chargeTrickAmount = 1;//波乗りした時に溜まるトリック量

    void OnTriggerEnter(Collider other)
    {
        if(!isTouched&&other.CompareTag("Player"))//まだ触れられてないかつ当たったのがプレイヤーなら
        {
            ChargeTrickPoint chargeTrick = other.GetComponentInChildren<ChargeTrickPoint>();//プレイヤーのトリックチャージのコンポーネントを取得
            chargeTrick.Charge(chargeTrickAmount);//トリックをチャージ
            isTouched = true;//触れられた
        }
    }
}
