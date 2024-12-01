using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//作成者:杉山
//シーン遷移のメソッドを呼ぶ(シーン名が変わった時の変更のコストを減らすため)
public class SceneController : MonoBehaviour
{
    [Header("以下はゲームシーンに移行しないなら必要ない")]
    [Header("ゲームシーンに移行するのに必要なステージデータ")]
    [SerializeField] CurrentStageData _currentStageData;
    [Header("ステージデータリスト")]
    [SerializeField] StageDataList _stageDataList;

    public void MenuScene()//メニュー画面に移行
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ClearScene()//クリアシーンに移行
    {
        SceneManager.LoadScene("ClearScene");
    }

    public void GameOverScene()//ゲームオーバーシーンに移行
    {
        SceneManager.LoadScene("GameoverScene");
    }

    public void GameScene(int stageID)//ゲームシーン1へ移動
    {
        //必要なデータがアタッチされていなければ警告し無視する
        if(_currentStageData==null||_stageDataList==null)
        {
            Debug.Log("必要なデータがそろっていません！");
            return;
        }

        _currentStageData.Rewrite(_stageDataList.Get(stageID));

        SceneManager.LoadScene("ToMainLoadScene");//一度ロード画面(ToMainLoadScene)を経由させる
    }

    public void EndGame()//ゲームを終了する
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
