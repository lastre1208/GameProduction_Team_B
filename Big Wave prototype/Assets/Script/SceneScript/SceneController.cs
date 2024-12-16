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

    public void RetryGameScene()//先ほどプレイした番号のゲームシーンをリトライする
    {
        //不備があれば無視する
        if (!CheckError(_currentStageData.StageID)) return;

        SceneManager.LoadScene("ToMainLoadScene");//一度ロード画面(ToMainLoadScene)を経由させる
    }

    public void GameScene(int stageID)//指定の番号のゲームシーンへ移動
    {
        //不備があれば無視する
        if (!CheckError(stageID)) return;

        _currentStageData.Rewrite(stageID);//現在プレイしているステージデータの更新

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

    bool CheckError(int stageID)//ゲームシーン移動時の不備チェック
    {
        //必要なデータがアタッチされていなければ警告する
        if (_currentStageData == null || _stageDataList == null)
        {
            Debug.Log("必要なデータがそろっていません！");
            return false;
        }

        //指定されたIDのステージデータが存在しなければ警告する
        if (!_stageDataList.ExistStageData(stageID))
        {
            Debug.Log(stageID + "というIDのステージデータは存在しません");
            return false;
        }

        return true;
    }
}
