using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeFever : MonoBehaviour
{
    [Header("回数ごとの溜まるフィーバーポイントの値")]
    [Header("注意:トリックゲージの個数分配列を用意してください")]
    [SerializeField] float[] chargeFeverPoint;//回数ごとの溜まるフィーバーポイントの値

    FEVERPoint player_FeverPoint;
    FeverMode feverMode;
    // Start is called before the first frame update
    void Start()
    {
        player_FeverPoint = GetComponent<FEVERPoint>();
        feverMode=GetComponent<FeverMode>();
    }

    //フィーバーポイントのチャージ、引数のcountはトリックをした時のその1回のジャンプ中にしたトリック回数
    public void Charge(int count)
    {
        if (!feverMode.FeverNow)//フィーバー状態でない時
        {
            player_FeverPoint.FeverPoint += chargeFeverPoint[count - 1];//フィーバーポイント加算(トリックするごとに加算するようにする)
        }
    }
}
