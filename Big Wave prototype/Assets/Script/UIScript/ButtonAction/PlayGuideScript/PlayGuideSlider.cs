using UnityEngine;

//作成者；桑原

public class PlayGuideSlider : MonoBehaviour
{
    [SerializeField] RectTransform playGuideGroup;//スライドさせたい画像のグループ
    [SerializeField] float slideSpeed = 5f;//スライド速度

    private Vector2 offScreenPosition;//画面外待機位置
    private Vector2 onScreenPosition;//画面内画像表示位置
    private bool isSliding = false;//スライドしているか
    private bool isDisplay = false;//表示しているか
    private bool startSlidingIn = false;//スライドインしているか
    private bool startSlidingOut = false;//スライドアウトしているか

    public bool CompletedSlideOut { get; set; } = false;//スライドアウトが完了したか

    public bool IsSliding
    {
        get { return isSliding; }
    }

    public bool IsDisplay
    {
        get { return isDisplay; }
    }

    private void Start()
    {
        offScreenPosition = new Vector2(0, Screen.height);//画面外待機位置の設定
        onScreenPosition = playGuideGroup.anchoredPosition;//画面内表示位置の設定
        playGuideGroup.anchoredPosition = offScreenPosition;//初期位置の設定
    }

    private void Update()
    {
        if (!IsSliding) return;//スライドしていないなら何もしない

        Vector2 targetPosition = startSlidingIn ? onScreenPosition : offScreenPosition;//スライド方向に応じた目標位置の設定
        playGuideGroup.anchoredPosition = Vector2.Lerp(playGuideGroup.anchoredPosition, targetPosition, slideSpeed * Time.deltaTime);

        if (Vector2.Distance(playGuideGroup.anchoredPosition, targetPosition) < 0.1f)//目標の位置と現在位置の差が一定値以下なら
        {
            CompleteSlide();//スライド完了時の処理
        }
    }

    public void SlideIn()
    {
        if (!IsDisplay)//画像が表示されていないなら
        {
            startSlidingIn = true;//スライドインしている
            isSliding = true;//画像をスライドしている
        }
    }

    public void SlideOut()
    {
        if (IsDisplay)//画像が表示されているなら
        {
            startSlidingOut = true;//スライドアウトしている
            isSliding = true;//画像をスライドしている
        }
    }

    private void CompleteSlide()//画像のスライド完了時の処理
    {
        isSliding = false;//スライドしていない
        playGuideGroup.anchoredPosition = startSlidingIn ? onScreenPosition : offScreenPosition;

        if (startSlidingIn)//スライドイン時の処理
        {
            startSlidingIn = false;//スライドインしていない
            isDisplay = true;//画像を表示している
        }

        else if (startSlidingOut)//スライドアウト時の処理
        {
            startSlidingOut = false;//スライドアウトしていない
            isDisplay = false;//画像を表示していない
            CompletedSlideOut = true;//スライドアウトが完了した
        }
    }
}
