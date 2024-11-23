using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//作成者:杉山
//ゲームクリア演出(シーン遷移も含めて)
public class GameClearEffect : MonoBehaviour
{
    [Header("シーン移行コンポーネント")]
    [SerializeField] SceneController _controller;

    public void Trigger()//演出開始
    {
        _controller.ClearScene();//クリアシーンに移行する
    }
}
