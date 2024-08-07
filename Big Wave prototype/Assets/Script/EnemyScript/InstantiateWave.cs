using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWave : MonoBehaviour
{
    //☆塩が書いた
    [SerializeField] GameObject instantiateWavePos;//波の生成位置
    [SerializeField] GameObject outSideWave;//外側の波のプレハブ
    [SerializeField] GameObject inSideWave;//内側(中央)の波のプレハブ
    [SerializeField] float outSideWaveIntervalTime = 0.1f;//外側の波の出現間隔
    [SerializeField] float inSideWaveIntervalTime = 0.1f;//内側の波の出現間隔
    private float outSideWaveTime = 0f;//外側の波の出現間隔を管理する時間
    private float inSideWaveTime = 0f;//内側(中央)の波の出現間隔を管理する時間
    private Vector3 inSideWavePos;//内側の波の生成位置、instantiateWavePosよりも少し高いy座標で生成する
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InstantiateOutSideWave();//外側の波の生成   
        InstantiateInSideWave();//内側(中央)の波の生成
    }

    //外側の波の生成
    //outSideWaveIntervalTimeの時間ごとに波を生成する
    void InstantiateOutSideWave()
    {
        outSideWaveTime += Time.deltaTime;
        if (outSideWaveTime > outSideWaveIntervalTime)
        {
            outSideWaveTime = 0f;
            Instantiate(outSideWave, instantiateWavePos.transform.position, transform.rotation);
        }
    }

    //内側(中央)の波の生成
    //inSideWaveIntervalTimeの時間ごとに波を生成する
    void InstantiateInSideWave()
    {
        inSideWavePos = instantiateWavePos.transform.position;
        inSideWavePos.y += 0.1f;//instantiateWavePosよりも少し高いy座標で生成する
        inSideWaveTime += Time.deltaTime;
        if (inSideWaveTime > inSideWaveIntervalTime)
        {
            inSideWaveTime = 0f;
            Instantiate(inSideWave, inSideWavePos, transform.rotation);
        }
    }
}
