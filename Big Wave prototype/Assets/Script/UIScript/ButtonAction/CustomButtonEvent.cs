using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//作成者:桑原
//ボタンのイベント
public class CustomButtonEvent : MonoBehaviour
{
    [Header("▼フェードアウトするかどうか")]
    [SerializeField] bool isFadeOut;
    [Header("どのシーンに移行するか")]
    [SerializeField] SelectScene _selectScene=new SelectScene();//シーン移行のインスタンス
    [SerializeField] MenuEffectController menuEffectController;
    [SerializeField] FadeOut fadeOut;

    private bool isButtonClicked = false;

    private void Update()
    {
        if (!isButtonClicked) return;

        ButtonAction();
    }

    public void ButtonClicked()
    {
        isButtonClicked = true;
    }

    private void ButtonAction()
    {

        if (!menuEffectController.EffectColorChanged) return;//ボタンの色が変わり切ってから

        if(isFadeOut&&!fadeOut.FadeStart) fadeOut.FadeOutTrigger();//フェードアウトする場合はフェードアウトさせる
        if (isFadeOut && !fadeOut.FadeCompleted) return;//また、フェードアウトが終わるのを待ってからシーン移行させる(フェードアウトしない場合はそのままシーン移行)

        _selectScene.ChangeScene();
    }
}
