using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonEvent : MonoBehaviour
{
    [Header("▼フェードアウトするかどうか")]
    [SerializeField] bool isFadeOut;

    [SerializeField] SceneController sceneController;
    [SerializeField] MenuEffectController menuEffectController;
    [SerializeField] FadeOut fadeOut;
    private bool isQuitButtonClicked = false;

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
                sceneController.MenuScene();
            }
        }
    }
}
