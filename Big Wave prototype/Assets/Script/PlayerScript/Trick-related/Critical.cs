using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//作成者:杉山
//最後に押したボタンがクリティカルになるかを判定
public class Critical : MonoBehaviour
{
    [Header("必要なコンポーネント")]
    [SerializeField] PushedButton_CurrentTrickPattern pushedButton_CurrentTrickPattern;
    [SerializeField] TrickPoint player_TrickPoint;
    bool criticalNow = false;//最後に押したボタンがクリティカルだったか
    private TrickButton[] criticalButton;//指定されたボタンの配列([0]が現在指定されているボタン、[1]が二番目に指定されているボタン...)

    public bool CriticalNow { get { return criticalNow; } }
    
    public TrickButton[] CriticalButton{ get { return criticalButton; } }

    void Start()
    {
        criticalButton = new TrickButton[player_TrickPoint.TrickGaugeNum];//プレイヤーのトリックゲージの本数分criticalButtonの配列を用意する
        StartAllocateButton();
    }

    public void SetCriticalNow()//クリティカルが発生したかを設定(押されたボタンからクリティカルの判定)
    {
        criticalNow = (pushedButton_CurrentTrickPattern.PushedButton == criticalButton[0]);
        //入力したボタンが指定されていたボタンだった時(クリティカルの時)
        if(criticalNow)
        {
            for (int i = 1; i < criticalButton.Length; i++)//[0](現在指定されている)ボタン以外の全てのボタンを1つ前([0]方向)にずらす
            {
                criticalButton[i - 1] = criticalButton[i];
            }
           
            AllocateButton(ref criticalButton[criticalButton.Length - 1]);//ボタンの配列の最後のボタンに割り当て
        } 
    }

    void StartAllocateButton()//最初に全てのcriticalButtonにボタンを割り当てる
    {
        for (int i = 0; i < criticalButton.Length; i++)
        {
            AllocateButton(ref criticalButton[i]);
        }
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
