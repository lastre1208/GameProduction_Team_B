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
    [Header("エフェクトを生成するインターバル")]
    [SerializeField] float generateInterval;//エフェクトを生成するインターバル
    [Header("エフェクトの通る地点")]
    [SerializeField] Transform[] effectWays;//エフェクトの通る地点、最初の地点から指定時間ごとに進んでいって最後の地点で着弾エフェクトを出す
    [SerializeField] Critical critical;
    private List<Pos_AlongWay> generatePosList = new List<Pos_AlongWay>();//エフェクト生成位置情報のリスト

    public EffectType_AlongWay NormalTrickEffect { get { return  normalTrickEffect; }}
    public EffectType_AlongWay CriticalTrickEffect { get { return criticalTrickEffect; }}

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

    //トリック時に呼び出す(エフェクトを新たに生成させる)
    public void ActivateEffect()
    {
        //クリティカルかそうでないかによってエフェクトを変える
        GenerateType_AlongWay generateType=critical.CriticalNow? GenerateType_AlongWay.critical : GenerateType_AlongWay.normal;
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


