using UnityEngine;
using UnityEngine.UI;

public class TriangleWaveLine : MonoBehaviour
{
    [Header("電撃エフェクトの画像")]
    [SerializeField] Image electricImage;
    [Header("エフェクトの再生速度")]
    [SerializeField] float speed = 1.0f;
    [Header("再生完了時、再生処理を止めるか")]
    [SerializeField] bool isStop = true;

    private bool effectCompleted;

    public bool EffectCompleted
    {
        get { return effectCompleted; }
    }

    void Start()
    {
        electricImage.fillAmount = 0.0f;
        effectCompleted = false;
    }

    void Update()
    {
        electricImage.fillAmount += speed * Time.deltaTime;//FillAmountを時間に応じて調整

        if (electricImage.fillAmount >= 1.0f)//FillAmountが1になったら0に戻す
        {
            if (isStop)
            {
                electricImage.fillAmount = 1.0f;//エフェクトの表示を固定
                effectCompleted = true;
            }

            else
                electricImage.fillAmount = 0.0f;//エフェクトの再生を繰り返す
        }
    }
}
