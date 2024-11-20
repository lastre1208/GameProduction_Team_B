using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ロープを伝うエフェクトの位置(エフェクトを出す地点とタイミングの)情報
class Pos_AlongWay
{
    GenerateType_AlongWay type;
    int posNum_GenerateEffect;//エフェクトを出す地点の要素番号
    float generateTime;//エフェクトを生成するタイミングを管理する時間


    public GenerateType_AlongWay Type { get { return type; } }
    public int PosNum_GenerateEffect { get { return posNum_GenerateEffect; } }
    public float GenerateTime { get { return generateTime; } }

    //コンストラクタ
    public Pos_AlongWay(GenerateType_AlongWay generateType, float defaultTime)
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
