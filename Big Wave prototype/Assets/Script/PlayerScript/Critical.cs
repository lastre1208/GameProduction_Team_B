using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Critical : MonoBehaviour
{
    [Header("ダメージの増加倍率")]
    [SerializeField] float criticalRate;//クリティカル時のダメージの増加倍率
    [Header("クリティカル時の効果音")]
    [SerializeField] AudioClip criticalSound;//クリティカル時の効果音
    private Button[] criticalButton;//指定されたボタンの配列([0]が現在指定されているボタン、[1]が二番目に指定されているボタン...)
    AudioSource audioSource;
    TRICKPoint player_TrickPoint;

    public Button[] CriticalButton
    {
        get { return criticalButton; }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player_TrickPoint = GetComponent<TRICKPoint>();
        criticalButton = new Button[player_TrickPoint.TrickGaugeNum];//プレイヤーのトリックゲージの本数分criticalButtonの配列を用意する
        StartAllocateButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartAllocateButton()//最初に全てのcriticalButtonにボタンを割り当てる
    {
        for(int i=0; i<criticalButton.Length;i++)
        {
            AllocateButton(ref criticalButton[i]);
        }
    }

    public float Method1(Button button)
    {
        if (button == criticalButton[0])//入力したボタンが指定されたボタンだった時
        {
            audioSource.PlayOneShot(criticalSound);//効果音の再生

            for(int i=1; i<criticalButton.Length ;i++)//[0](現在指定されている)ボタン以外の全てのボタンを1つ前([0]方向)にずらす
            {
                criticalButton[i - 1] = criticalButton[i];
            }

            AllocateButton(ref criticalButton[criticalButton.Length - 1]);//ボタンの配列の最後のボタンに割り当て

            return criticalRate;//クリティカル時の倍率を返す
        }
        return 1;//等倍を返す
    }

    void AllocateButton(ref Button button)//ボタンの割り当て(ランダム)
    {
        //enum型のButtonの要素数を取得
        int max = Enum.GetNames(typeof(Button)).Length;
        //ランダムな整数を取得
        int num = UnityEngine.Random.Range(0, max);
        //取得したランダムな整数をenum型:Buttonに変換してcriticalButtonに入れる
        button = (Button)Enum.ToObject(typeof(Button), num);
    }

}
