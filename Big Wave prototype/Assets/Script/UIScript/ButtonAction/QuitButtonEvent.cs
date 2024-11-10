using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonEvent : MonoBehaviour
{
    [Header("▼フェードアウトするかどうか")]
    [SerializeField] bool isFadeOut;

    [SerializeField] GameObject sceneMove;
    [SerializeField] GameObject menuEffect;
    [SerializeField] GameObject fadeOutCom;

    private SceneControlManager sceneControlManager;
    private MenuEffectController menuEffectController;
    private FadeOut fadeOut;

    private bool isQuitButtonClicked = false;

    private void Start()
    {
        sceneControlManager = sceneMove.GetComponent<SceneControlManager>();
        menuEffectController = menuEffect.GetComponent<MenuEffectController>();
        fadeOut = fadeOutCom.GetComponent<FadeOut>();
    }

    private void Update()
    {
        if (!isQuitButtonClicked)
        {
            return;
        }

        else
        {
            QuitAction();
        }
    }

    public void QuitButtonClicked()
    {
        isQuitButtonClicked = true;
    }

    private void QuitAction()
    {
        if (menuEffectController.ClickedEffectGenerated)
        {
            if (isFadeOut && menuEffectController.EffectColorChanged)
            {
                fadeOut.FadeOutTrigger();
            }

            if (isFadeOut ? menuEffectController.EffectColorChange_FadeOutWasCompleted : menuEffectController.EffectColorChanged)
            {
                sceneControlManager.ChangeMenuScene();
            }
        }
    }
}
