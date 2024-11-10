using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者：桑原

public class PlayGuideButtonEvent : MonoBehaviour
{
    [SerializeField] GameObject menuEffect;
    [Header("▼制御したいInputSystem")]
    [SerializeField] GameObject inputModule;

    [Header("▼表示させたい画像のグループ")]
    [SerializeField] RectTransform playGuideGroup;
    [Header("▼表示させたい画像")]
    [SerializeField] List<Image> playGuideImages;
    [Header("▼最初に表示させたい画像")]
    [SerializeField] Image displayImage;
    [Header("▼画像をスライドさせる速さ")]
    [SerializeField] float slideSpeed = 5f;

    private MenuEffectController menuEffectController;
    private PlayGuideInputModule playGuideInputModule;

    private Vector2 offScreenPosition;
    private Vector2 onScreenPosition;

    private int currentIndex = 0;
    private float currentSpeed;

    private bool isSliding = false;
    private bool isSlidingIn = false;
    private bool isSlidingOut = false;
    private bool isImageDisplayed = false;
    private bool isPlayGuideButtonClicked = false;

    private void Start()
    {
        menuEffectController = menuEffect.GetComponent<MenuEffectController>();
        playGuideInputModule = inputModule.GetComponent<PlayGuideInputModule>();

        playGuideGroup.gameObject.SetActive(true);

        onScreenPosition = playGuideGroup.anchoredPosition;//画像表示時の座標を設定
        offScreenPosition = new Vector2(0, Screen.height);//画像収納時の位置座標を設定

        playGuideGroup.anchoredPosition = offScreenPosition;//初期位置を画面外に設定

        foreach (var image in playGuideImages)//全ての画像を非表示にする
        {
            image.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!isPlayGuideButtonClicked) return;

        if (menuEffectController.ClickedEffectGenerated)//決定時のエフェクトが生成され終えたら
        {
            playGuideInputModule.DisableAllUIActions();//全ての入力を無効化

            if (menuEffectController.EffectColorChanged)
            {
                if (isSlidingIn || isSlidingOut)
                {
                    isSliding = true;
                    playGuideInputModule.DisableAllUIActions();
                    SlidingPlayGuide();
                }

                if (isImageDisplayed)
                {
                    playGuideInputModule.EnableSpecificUIActions();
                }
            }
        }
    }

    private void ShowImage(int index)//画像の表示
    {
        playGuideImages[index].gameObject.SetActive(true);
        isSlidingIn = true;
        currentSpeed = slideSpeed;
    }

    public void ShowNextImage()//次の画像を表示
    {
        if (!isSliding)
        {
            playGuideImages[currentIndex].gameObject.SetActive(false);
            currentIndex = (currentIndex + 1) % playGuideImages.Count;
            ShowImage(currentIndex);//画像の表示
        }
    }

    public void ShowPreviousImage()//前の画像を表示
    {
        if (!isSliding)
        {
            playGuideImages[currentIndex].gameObject.SetActive(false);
            currentIndex = (currentIndex - 1 + playGuideImages.Count) % playGuideImages.Count;
            ShowImage(currentIndex);//画像の表示
        }
    }

    public void CloseImage()//画像をしまう
    {
        if (!isSliding)
        {
            isSlidingOut = true;
            currentSpeed = slideSpeed;
        }
    }

    public void PlayGuideButtonClicked()//playGuideButtonが押されたときの処理
    {
        if (!isSliding)
        {
            ShowImage(currentIndex);//画像の表示
            isPlayGuideButtonClicked = true;
        }
    }

    private void SlidingPlayGuide()//画像のスライド移動処理
    {
        if (isSlidingIn)//画面内にスライドさせる場合
        {
            playGuideInputModule.DisableAllUIActions();//全ての入力を無効化
            playGuideGroup.anchoredPosition = Vector2.Lerp(playGuideGroup.anchoredPosition, onScreenPosition, currentSpeed * Time.deltaTime);//画像の移動

            if (Vector2.Distance(playGuideGroup.anchoredPosition, onScreenPosition) < 0.1f)//現在の画像の座標と画面内の設定座標との距離が一定以下になったら
            {
                isSliding = false;
                isSlidingIn = false;
                isImageDisplayed = true;
                playGuideGroup.anchoredPosition = onScreenPosition;
                playGuideInputModule.EnableSpecificUIActions();//一部入力を有効化
            }
        }

        else if (isSlidingOut)//画面外にスライドさせる場合
        {
            playGuideInputModule.DisableAllUIActions();//入力を無効化
            playGuideGroup.anchoredPosition = Vector2.Lerp(playGuideGroup.anchoredPosition, offScreenPosition, currentSpeed * Time.deltaTime);//画像の移動

            if (Vector2.Distance(playGuideGroup.anchoredPosition, offScreenPosition) < 0.1f)//現在の画像の座標と画面外の設定座標との距離が一定以下になったら
            {
                playGuideImages[currentIndex].gameObject.SetActive(false);
                isPlayGuideButtonClicked = false;
                isSliding = false;                
                isSlidingOut = false;
                isImageDisplayed = false;

                playGuideGroup.anchoredPosition = offScreenPosition;
                menuEffectController.ResetButtonClickEffect();//ボタンのエフェクトを再設定
                playGuideInputModule.EnableAllUIActions();//全ての入力を有効化
            }
        }
    }
}