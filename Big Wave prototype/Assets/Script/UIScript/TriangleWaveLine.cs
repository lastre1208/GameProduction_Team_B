using UnityEngine;
using UnityEngine.UI;

public class TriangleWaveLine : MonoBehaviour
{
    [SerializeField] Image electricImage;  // 電流エフェクトのイメージ
    [SerializeField] float speed = 1.0f;   // エフェクトの進行速度
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
        // Fill Amountを時間に応じて調整
        electricImage.fillAmount += speed * Time.deltaTime;

        // Fill Amountが1になったら0に戻す
        if (electricImage.fillAmount >= 1.0f)
        {
            if (isStop)
            {
                electricImage.fillAmount = 1.0f;
                effectCompleted = true;
            }

            else
            {
                electricImage.fillAmount = 0.0f;
            }
        }
    }
}
