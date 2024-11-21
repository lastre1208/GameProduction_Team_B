using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//波に乗るほどチャージエフェクトの大きさが大きくなっていく
public class ChangeScaleTheSurfer : MonoBehaviour
{
    [Header("最大倍率時のチャージ時の大きさ(倍率)")]
    [SerializeField] float maxScaleRate;//最大倍率時のチャージ時の大きさの倍率、初期の大きさから何倍の大きさか
    private Vector3 normalScale;//通常時(初期)の大きさ
    [SerializeField] ChangeChargeRateTheSurfer changeChargeRateTheSurfer;

    void Start()
    {
        normalScale = transform.localScale;//通常時(初期)の大きさを記憶
    }

    void Update()
    {
        ChangeEffectScale();
    }

    //大きさを変更
    void ChangeEffectScale()
    {
        if (gameObject.activeSelf)//アクティブの(表示している)時に大きさを変更
        {
            //現在の大きさを変更
            transform.localScale = normalScale*CurrentScaleRate();
        }
    }

    //現在のチャージ倍率(波に乗るほど増えるやつ)から
    //通常時と比べた時の現在の大きさの倍率を計算して返す
    //チャージ倍率が最大の時は最大倍率時のチャージ時の大きさの倍率を返すようにする
    float CurrentScaleRate()
    {
        //0%を初期のチャージ倍率、100%を最大のチャージ倍率としたときに
        //現在のチャージ倍率が何%かを求める
        float current = changeChargeRateTheSurfer.ChargeRate() - changeChargeRateTheSurfer.NormalChargeRate;//現在のチャージ倍率から通常のチャージ倍率(1)を引いたもの
        float max = changeChargeRateTheSurfer.ChargeRateMax - changeChargeRateTheSurfer.NormalChargeRate;//最大チャージ倍率から通常のチャージ倍率(1)を引いたもの
        float ratio = current / max;

        const float normalScaleRate = 1;//通常時の大きさの倍率、1固定
        float currentScaleRate=normalScaleRate+(maxScaleRate-normalScaleRate)*ratio;//通常時と比べた時の現在の大きさの倍率
        return currentScaleRate;
    }

    
}
