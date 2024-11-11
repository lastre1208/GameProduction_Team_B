using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGuideButtonEvent : MonoBehaviour
{
    [SerializeField] GameObject menuEffect;
    [SerializeField] GameObject inputModule;
    [SerializeField] RectTransform playGuideGroup;
    [SerializeField] List<Image> playGuideImages;
    [SerializeField] Image displayImage;
    [SerializeField] float slideSpeed = 5f;

    private MenuEffectController menuEffectController;
    private PlayGuideInputModule playGuideInputModule;

    private Vector2 offScreenPosition;
    private Vector2 onScreenPosition;

    private int currentIndex = 0;
    private float currentSpeed;

    private bool isSliding = false;//スライドしているか
    private bool isSlidingIn = false;//スライドインしているか
    private bool isSlidingOut = false;//スライドアウトしているか
    private bool isImageDisplayed = false;//画像が表示されているか
    private bool isPlayGuideButtonClicked = false;//ボタンが押されたか

    private void Start()
    {
        menuEffectController = menuEffect.GetComponent<MenuEffectController>();
        playGuideInputModule = inputModule.GetComponent<PlayGuideInputModule>();

        playGuideInputModule.enabled = false;

        playGuideGroup.gameObject.SetActive(true);
        offScreenPosition = new Vector2(0, Screen.height);//画像収納時の座標を設定
        onScreenPosition = playGuideGroup.anchoredPosition;//画像表示時の座標を設定
        playGuideGroup.anchoredPosition = offScreenPosition;//初期位置を画面外に設定

        foreach (var image in playGuideImages)//全ての画像を非表示にする
        {
            image.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        //ボタンがクリックされていないなら
        if (!isPlayGuideButtonClicked) return;

        if (menuEffectController.EffectColorChanged)//決定時のエフェクトが生成され終えたら
        {
            if (isSlidingIn || isSlidingOut)//画像がスライド移動中なら
            {
                isSliding = true;
                playGuideInputModule.DisableAllUIActions();//全ての入力を無効化
                SlidingPlayGuide();//画像のスライド処理
            }

            if (isImageDisplayed)//画像が表示されているなら
            {
                playGuideInputModule.EnableSpecificUIActions();//一部の入力を有効化
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
            ShowImage(currentIndex);
        }
    }

    public void ShowPreviousImage()//前の画像を表示
    {
        if (!isSliding)
        {
            playGuideImages[currentIndex].gameObject.SetActive(false);
            currentIndex = (currentIndex - 1 + playGuideImages.Count) % playGuideImages.Count;
            ShowImage(currentIndex);
        }
    }

    public void CloseImage()//画像を収納
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
            ShowImage(currentIndex);
            isPlayGuideButtonClicked = true;
        }
    }

    private void SlidingPlayGuide()//画像のスライド移動処理
    {
        playGuideInputModule.enabled = false;

        //画像の移動処理
        playGuideGroup.anchoredPosition = Vector2.Lerp(playGuideGroup.anchoredPosition,
            isSlidingIn ? onScreenPosition : offScreenPosition, currentSpeed * Time.deltaTime);

        //現在の画像の座標と設定座標との距離が一定以下になったら
        if (Vector2.Distance(playGuideGroup.anchoredPosition,
            isSlidingIn ? onScreenPosition : offScreenPosition) < 0.1f)
        {
            isSliding = false;
            playGuideGroup.anchoredPosition = isSlidingIn ? onScreenPosition : offScreenPosition;

            if (isSlidingIn)//スライドイン完了時の処理
            {
                CompleteSlideIn();
            }
            else if (isSlidingOut)//スライドアウト完了時の処理
            {
                CompleteSlideOut();
            }
        }
    }

    private void CompleteSlideIn()//スライドイン完了時の処理
    {
        isSlidingIn = false;
        isImageDisplayed = true;
        playGuideInputModule.enabled = true;
        playGuideInputModule.EnableSpecificUIActions();//一部入力を有効化
    }

    private void CompleteSlideOut()//スライドアウト完了時の処理
    {
        playGuideImages[currentIndex].gameObject.SetActive(false);
        isPlayGuideButtonClicked = false;
        isSlidingOut = false;
        isImageDisplayed = false;
        menuEffectController.ResetButtonClickEffect();//ボタンエフェクトの再設定
        playGuideInputModule.enabled = true;
        playGuideInputModule.EnableAllUIActions();//一部入力を有効化
        playGuideInputModule.enabled = false;
    }
}