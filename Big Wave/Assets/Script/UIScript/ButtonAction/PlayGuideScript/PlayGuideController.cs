using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//作成者：桑原

public class PlayGuideController : MonoBehaviour
{
    [Header("プレイガイドを出すボタン")]
    [SerializeField] GameObject _playGuidebutton;
    [Header("必要なコンポーネント")]
    [SerializeField] EventSystem _eventSystem;
    [SerializeField] PlayGuideInputHandler playGuideInputHandlerObject;
    [SerializeField] TransitionPages transitionPagesObject;
    [SerializeField] PlayGuideSlider playGuideSlider;
    [Header("操作したい画像")]
    [SerializeField] List<Image> playGuideImages;

    private PlayGuideInputHandler playGuideInputHandler;
    private TransitionPages transitionPages;
    private int currentIndex = 0;
    private bool isOpenGuide = false;

    private void Start()
    {
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

            OpenGuide();

            if (!playGuideSlider.IsSliding && playGuideSlider.IsDisplay)//操作を有効にする、スライドアウト完了を待ってから
            {
                playGuideInputHandler.EnableSpecificUIActions();
            }
        }

        else
        {
            playGuideInputHandler.DisableSpecificUIActions();//一部の操作を無効化
            if (playGuideSlider.CompletedSlideOut)//画像のスライドが完了していたら
            {
                transitionPages.HideImage(currentIndex);
                _eventSystem.SetSelectedGameObject(_playGuidebutton);//プレイガイドのボタンを選択状態にする
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
