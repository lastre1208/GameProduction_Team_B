using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonEvent : MonoBehaviour
{
    [Header("▼フェードアウトするかどうか")]
    [SerializeField] bool isFadeOut;

    [SerializeField] SceneController sceneController;
    [SerializeField] MenuEffectController menuEffectController;
    [SerializeField] FadeOut fadeOut;

    private bool isStartButtonClicked = false;

    private void Update()
    {
        if (!isStartButtonClicked)
        {
            return;            
        }

        else
        {
            StartAction();
        }
    }

    public void StartButtonClicked()
    {
        isStartButtonClicked = true;
    }

    private void StartAction()
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
