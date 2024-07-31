using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlManager : MonoBehaviour
{
    //☆塩が書いた
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMenuScene()//メニュー画面に移行
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ChangeGameScene()
    {
        SceneManager.LoadScene("SampleScene");
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
