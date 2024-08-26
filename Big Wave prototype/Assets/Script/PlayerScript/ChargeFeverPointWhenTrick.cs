using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeFeverPointWhenTrick : MonoBehaviour
{
    [Header("回数ごとの溜まるフィーバーポイントの値")]
    [Header("注意:トリックゲージの個数分配列を用意してください")]
    [SerializeField] float[] chargeFeverPoint;//回数ごとの溜まるフィーバーポイントの値

    FeverPoint player_FeverPoint;
    FeverMode feverMode;
    CountTrickWhileJump countTrickWhileJump;
    // Start is called before the first frame update
    void Start()
    {
        player_FeverPoint = GetComponent<FeverPoint>();
        feverMode=GetComponent<FeverMode>();
        countTrickWhileJump = GetComponent<CountTrickWhileJump>();
    }

    //フィーバーポイントのチャージ
    public void Charge()
    {
        int count =countTrickWhileJump.TrickCount;//トリックをした時のその1回のジャンプ中にしたトリック回数(1ジャンプ中のトリック回数の加算後にこの処理を入れるようにする)

        if (!feverMode.FeverNow)//フィーバー状態でない時
        {
            player_FeverPoint.FeverPoint_ += chargeFeverPoint[count - 1];//フィーバーポイント加算(トリックするごとに加算するようにする)
        }
    }
}
