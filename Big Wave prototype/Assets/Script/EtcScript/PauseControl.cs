using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseControl : MonoBehaviour
{
    [Header("ポーズメニューのUI")]
    [SerializeField]  GameObject pauseMenu;
    private bool isPaused = false;

    void Start()
    {
        isPaused = false;
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false); // ポーズメニューを非表示にする
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)||Input.GetButtonDown("Pause")) // Pキーが押されたら
        {
            TogglePause(); // ポーズの切り替え
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused; // ポーズ状態を反転させる
        Time.timeScale = isPaused ?0 : 1;// ゲームの時間経過を制御する
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(isPaused); // ポーズメニューを表示・非表示にする
        }
    }

    public void ResumeGame()
    {
        TogglePause(); // ポーズを解除してゲームを再開する
    }

    public void RestartGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
