using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ロープを伝うエフェクトを生成する
public class Generate_AlongWay : MonoBehaviour
{
    [Header("通常のトリックのエフェクト")]
    [SerializeField] EffectType_AlongWay normalTrickEffect=new EffectType_AlongWay();//通常のトリックのエフェクト
    [Header("クリティカルのトリックのエフェクト")]
    [SerializeField] EffectType_AlongWay criticalTrickEffect = new EffectType_AlongWay();//クリティカルのトリックのエフェクト
    [Header("クリティカルフィーバーのトリックのエフェクト")]
    [SerializeField] EffectType_AlongWay criticalFeverTrickEffect = new EffectType_AlongWay();//クリティカルフィーバーのトリックのエフェクト
    [Header("エフェクトを生成するインターバル")]
    [SerializeField] float generateInterval;//エフェクトを生成するインターバル
    [Header("エフェクトの通る地点")]
    [SerializeField] Transform[] effectWays;//エフェクトの通る地点、最初の地点から指定時間ごとに進んでいって最後の地点で着弾エフェクトを出す
    [SerializeField] Critical critical;
    [SerializeField] FeverMode feverMode;
    private List<Pos_AlongWay> generatePosList = new List<Pos_AlongWay>();//エフェクト生成位置情報のリスト

    public EffectType_AlongWay NormalTrickEffect { get { return  normalTrickEffect; }}
    public EffectType_AlongWay CriticalTrickEffect { get { return criticalTrickEffect; }}

    public EffectType_AlongWay CriticalFeverTrickEffect { get { return criticalFeverTrickEffect; }}

    void Update()
    {
        GenerateEffectAtGeneratePos();
        DestroyGeneratePos();
    }

    //トリック時に呼び出す(エフェクトを新たに生成させる)
    public void ActivateEffect()
    {
        GenerateType_AlongWay generateType;

        //トリックの状況(クリティカルとかフィーバー中とか)によってエフェクトを変える
        if (critical.CriticalNow&&feverMode.FeverNow)//フィーバー中＆クリティカル
        {
            generateType = GenerateType_AlongWay.criticalFever;
        }
        else if(critical.CriticalNow)//クリティカルだけ
        {
            generateType = GenerateType_AlongWay.critical;
        }
        else//通常トリック
        {
            generateType = GenerateType_AlongWay.normal;
        }

        generatePosList.Add(new Pos_AlongWay(generateType, generateInterval));
    }

    void GenerateEffectAtGeneratePos()//通る地点にエフェクトを生成
    {
        for (int i = 0; i < generatePosList.Count; i++)
        {
            generatePosList[i].UpdateGenerateTime();

            if (generatePosList[i].Should_Generate(generateInterval))
            {
                Transform passPos = effectWays[generatePosList[i].PosNum_GenerateEffect];//エフェクトを生成する地点を設定

                bool isLastPoint = (generatePosList[i].PosNum_GenerateEffect == effectWays.Length - 1);//最終(着弾)地点か

                EffectType_AlongWay effectType = EffectType(generatePosList[i].Type);//エフェクトの生成タイプ

                GameObject effect = isLastPoint ? effectType.LandEffect() : effectType.PassEffect();//最終地点なら着弾エフェクトをそうでないなら伝うエフェクトに設定

                if(effect!=null) Instantiate(effect, passPos.position, passPos.rotation, passPos);//生成

                generatePosList[i].TransitNextPos();//次の場所を設定
            }
        }
    }

    void DestroyGeneratePos()//最終地点でエフェクトを出したPassPosインスタンスを消す
    {
        while (generatePosList.Count != 0)
        {
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

    EffectType_AlongWay EffectType(GenerateType_AlongWay generateType)//引数のエフェクトの生成タイプからそれに対応したエフェクトタイプを返す
    {
        switch(generateType)
        {
            case GenerateType_AlongWay.normal: return normalTrickEffect;
            case GenerateType_AlongWay.critical: return criticalTrickEffect;
            case GenerateType_AlongWay.criticalFever: return criticalFeverTrickEffect;
            default: return null;
        }
    }
}


