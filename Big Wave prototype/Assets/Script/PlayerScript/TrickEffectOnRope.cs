using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//エフェクトが定められた箇所を順に進む
//後程コードの整理はします
public class TrickEffectOnRope : MonoBehaviour
{
    [Header("エフェクトの通る地点")]
    [SerializeField] Transform[] effectPassPos;//エフェクトの通る地点、最初の地点から指定時間ごとに進んでいって最後の地点で着弾エフェクトを出す
    [Header("伝う時のエフェクト")]
    [SerializeField] GameObject passEffect;//伝う時のエフェクト
    [Header("着弾時のエフェクト")]
    [SerializeField] GameObject landEffect;//着弾時のエフェクト
    [Header("次の地点に進むまでの秒数")]
    [SerializeField] float transitNextPosTime;//次の地点に進むまでの秒数
    private List<PassPos> passPosList=new List<PassPos>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreatePassEffect();
    }

    void CreatePassEffect()
    {
        for(int i=0; i<passPosList.Count;i++)
        {
            passPosList[i].passTime += Time.deltaTime;

            if(passPosList[i].passTime>=transitNextPosTime)
            {
                Transform pass= effectPassPos[passPosList[i].passNum];

                if (passPosList[i].passNum== effectPassPos.Length-1)//最終地点なら
                {
                    Instantiate(landEffect, pass.position, pass.rotation, pass);//生成
                }
                else
                {
                    Instantiate(passEffect, pass.position, pass.rotation, pass);//生成
                }
                
                passPosList[i].passNum++;//次の場所を設定
                passPosList[i].passTime = 0;
            }
        }

        //次の場所が通る地点の数ならここで消す
        while(true)
        {
            if (passPosList.Count == 0) break;

            if (passPosList[0].passNum>=effectPassPos.Length)
            {
                passPosList.RemoveAt(0);//削除
            }
            else
            {
                break;
            }
        }
    }

    //ロープを伝うエフェクトを出す時に呼び出す
    public void ActivateEffect()
    {
        PassPos passPos=new PassPos(transitNextPosTime);
        passPosList.Add(passPos);
    }
}

class PassPos
{
    public int passNum;//passNumber(次エフェクトを出す場所の要素番号、初期は0)
    public float passTime;//passTime(生成されてからの時間、初期は0)

    //コンストラクタ
    public PassPos(float time)
    {
        passNum = 0;
        passTime = time;
    }
}
