using UnityEngine;
using UnityEngine.UI;

//作成者：桑原

public class MenuEffectController : MonoBehaviour
{
    [Header("座標計算のもとにするオブジェクト")]
    [SerializeField] RectTransform menuPanel;
    [Header("▼エフェクト関連の設定")]
    [Header("選択時のエフェクト")]
    [SerializeField] GameObject selectedEffectPrefab;
    [Header("決定時のエフェクト")]
    [SerializeField] GameObject clickedEffectPrefab;
    [Header("決定時のエフェクトの色")]
    [SerializeField] Color clickedEffectColor;

    private SelectedEffectManager selectedEffectManager;
    private ClickedEffectManager clickedEffectManager;
    private TriangleWaveLine triangleWaveLine;

    private RectTransform currentButtonRect;
    private Image currentButtonImage;//現在選択中のボタンの画像
    private Color originalButtonColor;//ボタンの初期設定時の色

    private bool clickedEffectGenerated = false;//決定時のエフェクトが生成されたか
    private bool effectColorChanged = false;//エフェクトの色が変化したか

    public bool ClickedEffectGenerated { get { return clickedEffectGenerated; } }

    public bool EffectColorChanged { get { return effectColorChanged; } }

    private void Start()
    {
        selectedEffectManager = new SelectedEffectManager(menuPanel, selectedEffectPrefab);
        clickedEffectManager = new ClickedEffectManager(menuPanel, clickedEffectPrefab, clickedEffectColor);
    }

    void Update()
    {
        if (triangleWaveLine == null && clickedEffectManager.EffectPrefab != null)            
            triangleWaveLine = clickedEffectManager.EffectPrefab.GetComponent<TriangleWaveLine>();//決定時のエフェクトのコンポーネントを取得

        if (clickedEffectManager.IsEffectGenerated)
        {
            if (triangleWaveLine.EffectCompleted)//決定用のエフェクトがすべて表示されたら
            {
                if (currentButtonImage != null)
                {
                    currentButtonImage.color = clickedEffectColor;//ボタンの色を決定時エフェクトの色に変更する
                    effectColorChanged = true;
                }
            }
        }
    }

    public void ButtonSelectedProcess(RectTransform buttonRect)//ボタン選択時の処理
    {
        currentButtonRect = buttonRect;
        currentButtonImage = buttonRect.GetComponent<Image>();
        originalButtonColor = currentButtonImage.color;
        selectedEffectManager.SetEffectColor(originalButtonColor);
        selectedEffectManager.GenerateEffects(buttonRect);//選択時のエフェクトの生成
    }

    public void ButtonDeselectedProcess()//選択を切り替えたときの処理
    {
        selectedEffectManager.DestroyEffects();//選択時のエフェクトの破棄
        clickedEffectManager.DestroyEffects();//決定時のエフェクトの破棄

        if (currentButtonImage != null)
            currentButtonImage.color = originalButtonColor;//ボタンの色の初期化
    }

    public void ButtonClickedProcess(RectTransform buttonRect)//ボタン決定時の処理
    {
        if (!clickedEffectManager.IsEffectGenerated)
        {
            clickedEffectManager.GenerateEffects(buttonRect);//ボタン決定時のエフェクトの生成
            currentButtonImage = buttonRect.GetComponent<Image>();
        }
    }

    public void ResetButtonEffects()//ボタンのエフェクトの初期化
    {
        clickedEffectManager.DestroyEffects();//決定時のエフェクトの破棄
        selectedEffectManager.GenerateEffects(currentButtonRect);//選択時のエフェクトの生成

        if (currentButtonImage != null)
        {
            currentButtonImage.color = originalButtonColor;//ボタンの色の初期化
        }
    }
}
