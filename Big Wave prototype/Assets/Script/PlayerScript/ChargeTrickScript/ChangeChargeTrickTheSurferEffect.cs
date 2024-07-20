using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChargeTrickTheSurferEffect : MonoBehaviour
{
    [Header("チャージ時のエフェクト")]
    [SerializeField] GameObject chargeEffect;//チャージ時のエフェクト
    [Header("最大倍率時のチャージ時のエフェクトの大きさ")]
    [SerializeField] float maxScale;//チャージ時のエフェクト
    private Vector3 normalScale;
    private Vector3 currentScale;

    JudgeChargeNow judgeChargeNow;
    ChangeChargeTrickTheSurfer changeChargeTrickTheSurfer;
    // Start is called before the first frame update
    void Start()
    {
        judgeChargeNow = GetComponent<JudgeChargeNow>();
        changeChargeTrickTheSurfer =GetComponent<ChangeChargeTrickTheSurfer>();
        normalScale = chargeEffect.transform.localScale;
        currentScale = normalScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeEffectScale()//エフェクトの大きさを変更
    {
        //エフェクトの大きさを変更
        float effectScale = normalScale.x + (maxScale - normalScale.x) *changeChargeTrickTheSurfer.RatioOfChargeRate();
        currentScale = new Vector3(effectScale, effectScale, effectScale);

        ApplyCurrentScale();
    }

    void ApplyCurrentScale()//現在の大きさを適用
    {
        if(judgeChargeNow.ChargeNow())
        {
            chargeEffect.transform.localScale = currentScale;
        }
    }
}
