using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//タイムアップ時の演出(シーン遷移も含めて)
public class TimeUpEffect : MonoBehaviour
{
    [Header("シーン移行コンポーネント")]
    [SerializeField] SceneController _controller;

    public void Trigger()//演出開始
    {
        _controller.GameOverScene();//ゲームオーバーシーンに移行する
    }
}
