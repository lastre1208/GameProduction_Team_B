using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChargeTrickTheSurferEffect : MonoBehaviour
{
    [Header("チャージ時のエフェクト")]
    [SerializeField] GameObject chargeEffect;//チャージ時のエフェクト
    [Header("最大倍率時のチャージ時のエフェクトの大きさ(倍率)")]
    [SerializeField] float maxScaleRate;//最大倍率時のチャージ時のエフェクトの大きさ、初期の大きさから何倍の大きさか
    private Vector3 maxScale;//最大倍率時のエフェクトの大きさ
    private Vector3 normalScale;//通常時(初期)のエフェクトの大きさ
    private Vector3 currentScale;//現在のエフェクトの大きさ

    ChangeChargeTrickTheSurfer changeChargeTrickTheSurfer;
    // Start is called before the first frame update
    void Start()
    {
        changeChargeTrickTheSurfer =GetComponent<ChangeChargeTrickTheSurfer>();
        normalScale = chargeEffect.transform.localScale;
        maxScale = normalScale * maxScaleRate;
        currentScale = normalScale;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeEffectScale();//エフェクトの大きさを変更
    }

    void ChangeEffectScale()//エフェクトの大きさを変更
    {
        if (chargeEffect.activeSelf)//チャージエフェクトがアクティブの時にエフェクトの大きさを変更
        {
            float current = changeChargeTrickTheSurfer.CurrentChargeRate - changeChargeTrickTheSurfer.NormalChargeRate;//現在の倍率から通常の倍率(1)を引いたもの
            float max = changeChargeTrickTheSurfer.ChargeRateMax - changeChargeTrickTheSurfer.NormalChargeRate;//最大倍率から通常の倍率(1)を引いたもの
            float ratio= current / max;

            //エフェクトの現在の大きさの値を変更
            currentScale = normalScale + (maxScale - normalScale) * ratio;

            //現在の大きさをエフェクトの大きさに適用
            chargeEffect.transform.localScale = currentScale;
        }
    }
}
