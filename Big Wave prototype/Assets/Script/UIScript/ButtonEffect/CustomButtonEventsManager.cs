using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//作成者：桑原

public class CustomButtonEventsManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [Header("▼シーンを遷移するコンポーネント")]
    [SerializeField] GameObject sceneController;

    //private SceneControlManager sceneControlManager;
    private MenuEffectController menuEffectController;
    private RectTransform currentSelectedButton;
    private RectTransform currentClickedButton;

    void Start()
    {
        menuEffectController = canvas.GetComponent<MenuEffectController>();
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
}