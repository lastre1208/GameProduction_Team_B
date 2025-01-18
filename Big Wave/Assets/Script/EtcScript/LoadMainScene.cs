using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//作成者:杉山
//ゲームシーンへのロード処理
public class LoadMainScene : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] CurrentStageData _currentStageData;

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()//ゲームシーンへのロード
    {
        //前のシーンで現在プレイしているステージデータが更新されているはずなのでそのシーン名を読み込む
        AsyncOperation async = SceneManager.LoadSceneAsync(_currentStageData.StageSceneName);

        while (!async.isDone)
        {
            _slider.value = async.progress;
            yield return null;
        }
    }
}
