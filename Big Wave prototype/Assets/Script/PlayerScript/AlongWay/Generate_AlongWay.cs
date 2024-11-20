using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//
enum GenerateType_AlongWay//エフェクトの生成タイプ
{
    normal,
    critical
}

public class Generate_AlongWay : MonoBehaviour
{
    [Header("通常のトリックのエフェクト")]
    [SerializeField] EffectType_AlongWay normalTrickEffect=new EffectType_AlongWay();
    [Header("クリティカルのトリックのエフェクト")]
    [SerializeField] EffectType_AlongWay criticalTrickEffect = new EffectType_AlongWay();
    [Header("次の地点に進むまでの秒数")]
    [SerializeField] float generateInterval;//エフェクトを生成するインターバル
    [Header("エフェクトの通る地点")]
    [SerializeField] Transform[] effectWays;//エフェクトの通る地点、最初の地点から指定時間ごとに進んでいって最後の地点で着弾エフェクトを出す
    [SerializeField] Critical critical;
    private List<Pos_AlongWay> generatePosList = new List<Pos_AlongWay>();

    void Update()
    {
        GenerateEffectAtGeneratePos();
        DestroyGeneratePos();
    }

    void GenerateEffectAtGeneratePos()//通る地点にエフェクトを生成
    {
        for (int i = 0; i < generatePosList.Count; i++)
        {
            generatePosList[i].UpdateGenerateTime();

            if (generatePosList[i].Should_Generate(generateInterval))
            {
                Transform passPos = effectWays[generatePosList[i].PosNum_GenerateEffect];//エフェクトを生成する地点を設定

                bool isLastPoint = (generatePosList[i].PosNum_GenerateEffect == effectWays.Length - 1);//最終地点か

                EffectType_AlongWay effectType = EffectType(generatePosList[i].Type);//エフェクトタイプ

                GameObject effect = isLastPoint ? effectType.LandEffect() : effectType.PassEffect();//最終地点なら着弾エフェクトをそうでないなら伝うエフェクトに設定

                Instantiate(effect, passPos.position, passPos.rotation, passPos);//生成

                generatePosList[i].TransitNextPos();//次の場所を設定
            }
        }
    }


    void DestroyGeneratePos()//最終地点でエフェクトを出したPassPosインスタンスを消す
    {
        while (true)
        {
            if (generatePosList.Count == 0) break;

            if (generatePosList[0].PosNum_GenerateEffect >= effectWays.Length)
            {
                generatePosList.RemoveAt(0);//削除
            }
            else
            {
                break;
            }
        }
    }

    //トリック時に呼び出す
    public void ActivateEffect()
    {
        GenerateType_AlongWay generateType=critical.CriticalNow? GenerateType_AlongWay.critical : GenerateType_AlongWay.normal;
        generatePosList.Add(new Pos_AlongWay(generateType, generateInterval));
        generatePosList.Add(new Pos_AlongWay(generateType, generateInterval));
    }

    EffectType_AlongWay EffectType(GenerateType_AlongWay generateType)//引数のエフェクトの生成タイプからそれに対応したエフェクトタイプを返す
    {
        switch(generateType)
        {
            case GenerateType_AlongWay.normal: return normalTrickEffect;
            case GenerateType_AlongWay.critical: return criticalTrickEffect;
            default: return null;
        }
    }
}


class Pos_AlongWay
{
    GenerateType_AlongWay type;
    int posNum_GenerateEffect;//エフェクトを出す地点の要素番号
    float generateTime;//エフェクトを生成するタイミングを管理する時間


    public GenerateType_AlongWay Type { get { return type; } }
    public int PosNum_GenerateEffect { get { return posNum_GenerateEffect; } }
    public float GenerateTime { get { return generateTime; } }

    //コンストラクタ
    public Pos_AlongWay(GenerateType_AlongWay generateType,float defaultTime)
    {
        type = generateType;
        posNum_GenerateEffect = 0;
        generateTime = defaultTime;
    }

    public bool Should_Generate(float transitNextPosInterval)//エフェクトを生成するならtrueを返す
    {
        return (generateTime >= transitNextPosInterval);
    }

    public void TransitNextPos()//次の地点に設定
    {
        posNum_GenerateEffect++;//次の場所を設定
        generateTime = 0;//エフェクトを生成するタイミングを管理する時間をリセット
    }

    public void UpdateGenerateTime()//エフェクトを生成するタイミングを管理する時間を更新
    {
        generateTime += Time.deltaTime;
    }
}
