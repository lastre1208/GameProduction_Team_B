using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

//作成者:杉山
//受け取ったボタンの種類に応じてダメージ増加倍率を返す
public class Critical : MonoBehaviour
{
    [Header("ダメージの増加倍率")]
    [SerializeField] float criticalRate;//クリティカル時のダメージの増加倍率
    [Header("クリティカル時の効果音")]
    [SerializeField] AudioClip criticalSound;//クリティカル時の効果音
    [Header("必要なコンポーネント")]
    [SerializeField] Score_CriticalTrickCount criticalTrickCount;//クリティカルのスコア
　　[SerializeField] AudioSource audioSource;
    [SerializeField] TrickPoint player_TrickPoint;
    private TrickButton[] criticalButton;//指定されたボタンの配列([0]が現在指定されているボタン、[1]が二番目に指定されているボタン...)
    

    public TrickButton[] CriticalButton
    {
        get { return criticalButton; }
    }

    void Start()
    {
        criticalButton = new TrickButton[player_TrickPoint.TrickGaugeNum];//プレイヤーのトリックゲージの本数分criticalButtonの配列を用意する
        StartAllocateButton();
    }

    void StartAllocateButton()//最初に全てのcriticalButtonにボタンを割り当てる
    {
        for(int i=0; i<criticalButton.Length;i++)
        {
            AllocateButton(ref criticalButton[i]);
        }
    }

    public float CriticalDamageRate(TrickButton button)//指定されたボタンを入力することによってクリティカルが発生するようにする(ダメージがアップするようにする)
    {
        if (button == criticalButton[0])//入力したボタンが指定されたボタンだった時(クリティカル時)
        {
            audioSource.PlayOneShot(criticalSound);//効果音の再生

            criticalTrickCount.AddScoreWhenCritical(true);//クリティカルだったためスコアの加算

            for(int i=1; i<criticalButton.Length ;i++)//[0](現在指定されている)ボタン以外の全てのボタンを1つ前([0]方向)にずらす
            {
                criticalButton[i - 1] = criticalButton[i];
            }

            AllocateButton(ref criticalButton[criticalButton.Length - 1]);//ボタンの配列の最後のボタンに割り当て

            return criticalRate;//クリティカル時の倍率を返す
        }


        //入力したボタンが指定されたボタンではなかった時(クリティカルではなかった時)
        criticalTrickCount.AddScoreWhenCritical(false);//クリティカルではなかったためスコアの加算はされない

        return 1;//等倍を返す
    }

    void AllocateButton(ref TrickButton button)//ボタンの割り当て(ランダム)
    {
        //enum型のButtonの要素数を取得
        int max = Enum.GetNames(typeof(TrickButton)).Length;
        //ランダムな整数を取得
        int num = UnityEngine.Random.Range(0, max);
        //取得したランダムな整数をenum型:Buttonに変換してcriticalButtonに入れる
        button = (TrickButton)Enum.ToObject(typeof(TrickButton), num);
    }

}
