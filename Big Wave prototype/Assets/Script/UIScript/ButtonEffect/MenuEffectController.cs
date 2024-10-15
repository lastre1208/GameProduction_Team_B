using UnityEngine;
using UnityEngine.UI;

//作成者：桑原

public class MenuEffectController : MonoBehaviour
{
    [Header("▼座標計算のもとにするオブジェクト")]
    [SerializeField] RectTransform menuPanel;
    [Header("▼ボタン選択時に生成されるエフェクト")]
    [SerializeField] GameObject selectedEffectPrefab;
    [Header("▼ボタン決定時に生成されるエフェクト")]
    [SerializeField] GameObject clickedEffectPrefab;
    [Header("フェードアウトの設定")]
    [SerializeField] FadeOut fadeOut;

    //[Header("▼フェードアウトに使う画像")]
    //[SerializeField] Image fadeImage;
    /*[Header("▼ゲームを開始するボタン")]
    [SerializeField] GameObject startGameButton;
    [Header("▼ゲームを終了するボタン")]
    //[SerializeField] GameObject endGameButton;*/
    //[Header("▼完全に画面がフェードアウトするまでにかかる時間")]
    //[SerializeField] float fadeDuration = 1.0f;


    private TriangleWaveLine triangleWaveLine;

    private GameObject leftSelectedEffect;//左側に生成されるボタン選択時のエフェクト
    private GameObject rightSelectedEffect;//右側に生成されるボタン選択時のエフェクト
    private GameObject leftClickedEffect;//左側に生成されるボタン決定時のエフェクト
    private GameObject rightClickedEffect;//右側に生成されるボタン決定時のエフェクト

    private Image currentButtonImage;

    private float setPositionOffset = 2.5f;//座標計算の補正用
    //private float fadeTimer = 0f;//フェードアウト時間の管理用
    //private bool fadeCompleted;
    private bool clickedEffectGenerated = false;//決定されたかどうか
    private bool effectColorChanged = false;

    //public bool FadeCompleted
    //{
    //    get { return fadeCompleted; }
    //}

    public bool EffectColorChanged
    {
        get { return effectColorChanged; }
    }

    public bool EffectColorChange_FadeOutWasCompleted
    {
        get { return effectColorChanged && fadeOut.FadeCompleted; }
    }

    private void Start()
    {
        //fadeImage.color = new Color(0, 0, 0, 0);//フェードアウト用の画像を透明に設定

        //fadeCompleted = false;

        clickedEffectGenerated = false;
    }

    void Update()
    {
        if (triangleWaveLine == null && leftClickedEffect != null)
        {
            //決定時のエフェクトのコンポーネントを取得
            triangleWaveLine = leftClickedEffect.GetComponent<TriangleWaveLine>();
        }

        if (clickedEffectGenerated)
        {
            if (triangleWaveLine.EffectCompleted)//決定用のエフェクトがすべて表示されたら
            {
                if (currentButtonImage != null)
                {
                    currentButtonImage.color = new Color(1.0f, 0.64f, 0.0f, 1.0f);//ボタンの色をオレンジ色にする
                    effectColorChanged = true;
                }

                if (effectColorChanged)
                {
                    fadeOut.FadeOutTrigger();//画面の暗転処理を開始
                }
            }
        }
    }

    public void ButtonSelectedProcess(RectTransform buttonRect)//各ボタンが選択されたときの処理
    {
        if (buttonRect != null)
        {
            DestroyEffects(ref leftSelectedEffect, ref rightSelectedEffect);
            GenerateEffects(buttonRect, selectedEffectPrefab, ref leftSelectedEffect, ref rightSelectedEffect);
        }
    }

    public void ButtonDeselectedProcess(RectTransform buttonRect)//各ボタンから選択が外されたときの処理
    {
        if (buttonRect != null)
        {
            DestroyEffects(ref leftSelectedEffect, ref rightSelectedEffect);//選択エフェクトの削除
        }
    }

    public void ButtonClickedProcess(RectTransform buttonRect)//ボタンがクリックされたときの処理
    {
        DestroyEffects(ref leftClickedEffect, ref rightClickedEffect);//決定エフェクトの削除
        GenerateEffects(buttonRect, clickedEffectPrefab, ref leftClickedEffect, ref rightClickedEffect);
        clickedEffectGenerated = true;//決定時のエフェクトが生成された
        currentButtonImage = buttonRect.GetComponent<Image>();
    }

    //エフェクトの生成
    public void GenerateEffects(RectTransform buttonRect, GameObject effectPrefab, ref GameObject leftEffect, ref GameObject rightEffect)
    {
        float panelWidth = menuPanel.rect.width;//パネルの横幅
        float panelLeftX = -panelWidth * 0.5f;//パネルの左端
        float panelRightX = panelWidth * 0.5f;//パネルの右端

        //float buttonWidth = buttonRect.rect.width;//ボタンの幅

        float buttonCenterY = buttonRect.anchoredPosition.y;//ボタンの中央のアンカーY座標を取得
                
        leftEffect = Instantiate(effectPrefab, menuPanel);//左側のエフェクトを生成
        RectTransform leftEffectRect = leftEffect.GetComponent<RectTransform>();
                
        float effectWidth = leftEffectRect.rect.width;//エフェクトの幅の半分を取得

        float leftEffectX = panelLeftX + effectWidth * setPositionOffset;//左エフェクトの座標をパネルの左端の座標に合わせる
        leftEffectRect.anchoredPosition = new Vector2(leftEffectX, buttonCenterY);//計算した座標に配置

        rightEffect = Instantiate(effectPrefab, menuPanel);//右側のエフェクトを生成
        RectTransform rightEffectRect = rightEffect.GetComponent<RectTransform>();

        float rightEffectX = panelRightX - effectWidth * setPositionOffset;//右エフェクトの座標をパネルの右端の座標に合わせる
        rightEffectRect.anchoredPosition = new Vector2(rightEffectX, buttonCenterY);//計算した座標に配置
        rightEffectRect.localRotation = Quaternion.Euler(0, 180, 0);//右側のエフェクトを回転させる
    }

    //エフェクトの破棄
    public void DestroyEffects(ref GameObject leftEffect, ref GameObject rightEffect)
    {
        if (leftEffect != null)
        {
            DestroyImmediate(leftEffect);
            leftEffect = null;
        }

        if (rightEffect != null)
        {
            DestroyImmediate(rightEffect);
            rightEffect = null;
        }      
    }

    ////画面の暗転
    //private void FadeOutDisplay()
    //{
    //    fadeTimer += Time.deltaTime;
    //    float normalizedTime = fadeTimer / fadeDuration;
    //    float newAlpha = Mathf.Clamp01(normalizedTime);//経過時間をもとに透明度を計算
    //    fadeImage.color = new Color(0, 0, 0, newAlpha);//フェードアウト用の画像の透明度を更新

    //    if (fadeTimer >= fadeDuration)
    //    {
    //        fadeCompleted = true;//完全に画面が暗転した
    //    }
    //}
}
