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

    void ChangeGameoverScene()//ゲームオーバー画面に移行
    {
        SceneManager.LoadScene("GameoverScene");
    }

    void ChangeClearScene()//クリア画面に移行
    {
        SceneManager.LoadScene("ClearScene");
    }

    void ChangeMenuScene()//メニュー画面に移行
    {
        SceneManager.LoadScene("MenuScene");
    }

    void ChangeGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
