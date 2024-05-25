using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGameoverScene()//ゲームオーバー画面に移行
    {
        SceneManager.LoadScene("GameoverScene");
    }

    public void ChangeClearScene()//クリア画面に移行
    {
        SceneManager.LoadScene("ClearScene");
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
