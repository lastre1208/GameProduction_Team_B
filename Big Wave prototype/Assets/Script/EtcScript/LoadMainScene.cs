using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] CurrentStageData _currentStageData;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(_currentStageData.StageSceneName);

        while (!async.isDone)
        {
            _slider.value = async.progress;
            yield return null;
        }
    }
}
