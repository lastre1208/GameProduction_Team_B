using UnityEngine;

//作成者：桑原

public class CustomButtonEventsManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [Header("▼ゲームを開始するボタン")]
    [SerializeField] GameObject startGameButton;
    [Header("▼ゲームを終了するボタン")]
    [SerializeField] GameObject endGameButton;

    private SceneControlManager sceneControlManager;
    private MenuEffectController menuEffectController;
    private RectTransform currentSelectedButton;
    private RectTransform currentClickedButton;

    void Start()
    {
        sceneControlManager = startGameButton.GetComponent<SceneControlManager>();
        menuEffectController = canvas.GetComponent<MenuEffectController>();
    }

    void Update()
    {
        ButtonsProcess();//各ボタンの処理
    }

    //ボタン選択時の処理
    public void OnButtonSelected(RectTransform buttonRect)
    {
        if (currentSelectedButton != buttonRect)
        {
            menuEffectController.ButtonSelectedProcess(buttonRect);
            currentSelectedButton = buttonRect;
        }
    }

    //ボタンの選択解除時の処理
    public void OnButtonDeselected(RectTransform buttonRect)
    {
        if (currentSelectedButton != null)
        {
            menuEffectController.ButtonDeselectedProcess(buttonRect);
            currentSelectedButton = null;
        }
    }

    //ボタンのクリック時の処理
    public void OnButtonClicked(RectTransform buttonRect)
    {
        menuEffectController.ButtonClickedProcess(buttonRect);
        currentClickedButton = buttonRect;
    }

    //各ボタンの処理
    private void ButtonsProcess()
    {
        if (currentClickedButton == startGameButton.GetComponent<RectTransform>())//ゲームを開始するボタンが押されたら
        {
            if (menuEffectController.EffectColorChanged && menuEffectController.FadeCompleted)//ボタンの色の変化と画面の暗転が終了していたら
            {
                sceneControlManager.ChangeGameScene();//ロード画面への移行処理を呼び出す
            }
        }     

        else if (currentClickedButton == endGameButton.GetComponent<RectTransform>())//ゲームを終了するボタンが押されたら
        {
            if (menuEffectController.EffectColorChanged)//ボタンの色の変化が終了していたら
            {
                sceneControlManager.EndGame();//ゲームの終了処理を呼びだす
            }
        }
    }
}
