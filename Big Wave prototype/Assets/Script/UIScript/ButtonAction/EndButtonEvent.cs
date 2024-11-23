using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButtonEvent : MonoBehaviour
{
    [Header("▼フェードアウトするかどうか")]
    [SerializeField] bool isFadeOut;

    [SerializeField] SceneController sceneController;
    [SerializeField] MenuEffectController menuEffectController;
    [SerializeField] FadeOut fadeOut;

    private bool isEndButtonClicked = false;

    private void Update()
    {
        if (!isEndButtonClicked)
        {
            return;
        }

        else
        {
            EndAction();
        }
    }

    public void EndButtonClicked()
    {
        isEndButtonClicked = true;
    }

    private void EndAction()
    {
        if (menuEffectController.ClickedEffectGenerated)
        {
            if (isFadeOut && menuEffectController.EffectColorChanged)
            {
                fadeOut.FadeOutTrigger();
            }

            if (isFadeOut ? menuEffectController.EffectColorChange_FadeOutWasCompleted : menuEffectController.EffectColorChanged)
            {
                sceneController.EndGame();
            }
        }
    }
}
