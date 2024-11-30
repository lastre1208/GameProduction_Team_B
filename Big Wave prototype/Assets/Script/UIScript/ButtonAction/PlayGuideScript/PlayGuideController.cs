using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者：桑原

public class PlayGuideController : MonoBehaviour
{
    [SerializeField] MenuEffectController effectControllerObject;
    [SerializeField] PlayGuideInputHandler playGuideInputHandlerObject;
    [SerializeField] TransitionPages transitionPagesObject;
    [SerializeField] PlayGuideSlider playGuideSlider;
    [SerializeField] List<Image> playGuideImages;

    private MenuEffectController effectController;
    private PlayGuideInputHandler playGuideInputHandler;
    private TransitionPages transitionPages;
    private int currentIndex = 0;
    private bool isOpenGuide = false;

    private void Start()
    {
        effectController = effectControllerObject.GetComponent<MenuEffectController>();
        playGuideInputHandler = playGuideInputHandlerObject.GetComponent<PlayGuideInputHandler>();
        transitionPages = transitionPagesObject.GetComponent<TransitionPages>();

        transitionPages.SetImages(playGuideImages, currentIndex);
    }

    private void Update()
    {
        //画面がスライドしていない、表示されていないなら
        if (!playGuideSlider.IsSliding && !playGuideSlider.IsDisplay)
            playGuideInputHandler.EnableAllUIActions();//全ての操作を有効化

        if (isOpenGuide)
        {
            playGuideInputHandler.DisableAllUIActions();//全ての操作を無効化
            if (effectController.EffectColorChanged)
            {
                OpenGuide();

                if (!playGuideSlider.IsSliding && playGuideSlider.IsDisplay)
                {
                    playGuideInputHandler.EnableSpecificUIActions();
                }//操作を有効にする、エフェクトの初期化処理・・・スライドアウト完了を待ってから                
            }
        }

        else
        {
            playGuideInputHandler.DisableSpecificUIActions();//一部の操作を無効化
            if (playGuideSlider.CompletedSlideOut)//画像のスライドが完了していたら
            {
                transitionPages.HideImage(currentIndex);
                effectController.ResetButtonEffects();
                playGuideSlider.CompletedSlideOut = false;
            }
        }
    }

    public void OpenGuide()//ガイドの表示処理
    {
        if (!playGuideSlider.IsDisplay)
        {
            transitionPages.ShowImage(currentIndex);
            playGuideSlider.SlideIn();
        }
    }

    public void CloseGuide()//ガイドの格納処理
    {
        if (playGuideSlider.IsDisplay)
        {
            playGuideSlider.SlideOut();
            isOpenGuide = false;
        }
    }

    public void PlayGuideButtonClicked()//playGuideButtonボタンを押したときの処理
    {
        if (!playGuideSlider.IsSliding && !playGuideSlider.IsDisplay)
        {
            isOpenGuide = true;
        }
    }
}
