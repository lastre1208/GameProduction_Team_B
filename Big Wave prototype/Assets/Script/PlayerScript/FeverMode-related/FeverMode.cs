using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//作成者:杉山
//フィーバー状態の効果
public class FeverMode : MonoBehaviour
{
    [Header("フィーバー状態のエフェクト")]
    [SerializeField] GameObject feverEffect;//フィーバー状態のエフェクト
    [Header("フィーバー状態の効果時間")]
    [SerializeField] float feverTime=20f;//フィーバー状態の効果時間
    private float remainingFeverTime = 0f;//フィーバー状態の残り効果時間
    [Header("フィーバー状態移行時に起こすイベント")]
    [SerializeField] UnityEvent feverEvent;//フィーバー状態移行時に起こすイベント

    [Header("必要なコンポーネント")]
    [SerializeField] FeverPoint player_FeverPoint;

    private bool feverNow=false;//今フィーバー状態か

    public bool FeverNow
    {
        get { return feverNow; }
    }

    // Start is called before the first frame update
    void Start()
    {
        feverEffect.SetActive(false);
        remainingFeverTime = 0f;
        feverNow = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeFeverMode();//フィーバー状態に移行

        UpdateFeverTime();//フィーバー状態の残り時間を管理

        FeverModeEffect();//フィーバー状態の効果の処理
    }

    //まだフィーバー状態になっていないかつフィーバーポイントが満タンになったらフィーバー状態に移行
    void ChangeFeverMode()
    {
        if (feverNow == false && player_FeverPoint.FeverPoint_ >= player_FeverPoint.FeverPointMax)
        {
            feverNow = true;
            remainingFeverTime = feverTime;
            feverEvent.Invoke();
        }
    }

    //フィーバー状態の残り時間を更新
    void UpdateFeverTime()
    {
        remainingFeverTime -= Time.deltaTime;

        if(remainingFeverTime<=0f)//フィーバー状態の残り時間が0になったらフィーバー状態を解除
        {
            remainingFeverTime=0f;
            feverNow = false;
        }
    }

    //フィーバー状態の効果の処理
    void FeverModeEffect()
    {
        //フィーバー状態中は...
        //エフェクトが付く
        //フィーバーポイントが時間ごとに減っていく(フィーバー状態の残り時間を表している)
        if (feverNow)
        {
            float ratio = remainingFeverTime / feverTime;
            player_FeverPoint.FeverPoint_ = player_FeverPoint.FeverPointMax * ratio;
        }

        feverEffect.SetActive(feverNow);//フィーバー時エフェクトを表示
    }
}
