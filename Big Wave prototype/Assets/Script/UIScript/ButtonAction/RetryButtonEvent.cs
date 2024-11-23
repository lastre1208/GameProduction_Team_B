using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButtonEvent : MonoBehaviour
{
    [Header("▼フェードアウトするかどうか")]
    [SerializeField] bool isFadeOut;

    [SerializeField] SceneController sceneController;
    [SerializeField] MenuEffectController menuEffectController;
    [SerializeField] FadeOut fadeOut;

    private bool isRetryButtonClicked = false;

    private void Update()
    {
        if (!isRetryButtonClicked)
        {
            return;
        }

        else
        {
            RetryAction();
        }
    }

    public void RetryButtonClicked()
    {
        isRetryButtonClicked = true;
    }

    private void RetryAction()
    {
        if (menuEffectController.ClickedEffectGenerated)
        {
            if (isFadeOut && menuEffectController.EffectColorChanged)
            {
                fadeOut.FadeOutTrigger();
            }

            if (isFadeOut ? menuEffectController.EffectColorChange_FadeOutWasCompleted : menuEffectController.EffectColorChanged)
            {
                sceneController.GameScene_1();
            }
        }
    }
}
