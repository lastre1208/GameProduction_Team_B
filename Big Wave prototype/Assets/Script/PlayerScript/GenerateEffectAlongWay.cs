using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//作成者:杉山
//定められた箇所を順にエフェクトを生成していく
public class GenerateEffectAlongWay : MonoBehaviour
{
    [Header("エフェクトの通る地点")]
    [SerializeField] Transform[] effectWays;//エフェクトの通る地点、最初の地点から指定時間ごとに進んでいって最後の地点で着弾エフェクトを出す
    [Header("伝う時のエフェクト")]
    [SerializeField] GameObject passEffect;//伝う時のエフェクト
    [Header("着弾時のエフェクト")]
    [SerializeField] GameObject landEffect;//着弾時のエフェクト
    [Header("次の地点に進むまでの秒数")]
    [SerializeField] float generateInterval;//エフェクトを生成するインターバル
    [Header("着弾時に呼び出したいイベント")]
    [SerializeField] UnityEvent landEvents;//着弾時に呼び出したいイベント
    [Header("着弾時(非クリティカル)に呼び出したいイベント")]
    [SerializeField] UnityEvent landEvents_F;
    [SerializeField] Critical critical;
  
    private List<GenerateEffectPos_AlongWay> generatePosList=new List<GenerateEffectPos_AlongWay>();
    private Queue<bool> C_Trick=new Queue<bool>();

    //public Queue<bool> c_Trick
    //{
    //    get { return C_Trick; }
    //    set { C_Trick = value; }
    //}
    void Update()
    {
        GenerateEffectAtGeneratePos();
        DestroyGeneratePos();
    }

    void GenerateEffectAtGeneratePos()//通る地点にエフェクトを生成
    {
        for(int i=0; i<generatePosList.Count;i++)
        {
            generatePosList[i].UpdateGenerateTime();

            if(generatePosList[i].Should_Generate(generateInterval))
            {
                Transform passPos= effectWays[generatePosList[i].PosNum_GenerateEffect];//エフェクトを生成する地点を設定

                bool isLastPoint = (generatePosList[i].PosNum_GenerateEffect == effectWays.Length - 1);//最終地点か

                GameObject effect = isLastPoint ? landEffect : passEffect;//最終地点なら着弾エフェクトをそうでないなら伝うエフェクトに設定

                Instantiate(effect, passPos.position, passPos.rotation, passPos);//生成

               
                if (isLastPoint && C_Trick.Peek())//クリティカルのやつが着弾時
                {
                    landEvents.Invoke();//着弾なら着弾時に登録していたイベントを呼び出す
                    C_Trick.Dequeue();
                }
                else if (isLastPoint)//普通のやつ着弾時
                {
                    landEvents_F.Invoke();
                    C_Trick.Dequeue();
                }
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
        C_Trick.Enqueue(critical.CriticalNow);
        GenerateEffectPos_AlongWay generatePos=new GenerateEffectPos_AlongWay(generateInterval);//トリックをしたらすぐに電撃が出るようにする
        generatePosList.Add(generatePos);
    }
}


//エフェクトを生成する地点とタイミングを管理している
class GenerateEffectPos_AlongWay
{
    int posNum_GenerateEffect;//エフェクトを出す地点の要素番号
    float generateTime;//エフェクトを生成するタイミングを管理する時間

    public int PosNum_GenerateEffect { get {  return posNum_GenerateEffect; } }
    public float GenerateTime { get { return generateTime; } }

    //コンストラクタ
    public GenerateEffectPos_AlongWay(float time)
    {
        posNum_GenerateEffect = 0;
        generateTime = time;
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
