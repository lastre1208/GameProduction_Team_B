using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//トリック回数によってその分フィーバーポイントがたまる
public class ChargeFeverPointWhenTrick : MonoBehaviour
{
    [Header("回数ごとの溜まるフィーバーポイントの値")]
    [Header("注意:トリックゲージの個数分配列を用意してください")]
    [SerializeField] float[] chargeFeverPoint;//回数ごとの溜まるフィーバーポイントの値
    [Header("必要なコンポーネント")]
    [SerializeField] FeverPoint player_FeverPoint;
    [SerializeField] FeverMode feverMode;
    [SerializeField] CountTrickWhileJump countTrickWhileJump;
    [SerializeField] Critical critical;
    int count;

    //フィーバーポイントのチャージ
    public void Charge()
    {
        if (!feverMode.FeverNow&&critical.CriticalNow)//フィーバー状態でない時トリックが成功した時のみ溜まるようにする
        {
             count = countTrickWhileJump.TrickCount;//トリックをした時のその1回のジャンプ中にしたトリック回数(1ジャンプ中のトリック回数の加算後にこの処理を入れるようにする)

            if (count>chargeFeverPoint.Length) count = chargeFeverPoint.Length;//例外処理対策

            player_FeverPoint.FeverPoint_ += chargeFeverPoint[count - 1];//フィーバーポイント加算(トリック成功するごとに加算するようにする)
          
        }
    }
}
