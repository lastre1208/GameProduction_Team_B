using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWave : MonoBehaviour
{
    //☆作成者:杉山
    [Header("波の生成位置")]
    [SerializeField] GameObject instantiateWavePos;//波の生成位置
    [Header("波のプレハブ")]
    [SerializeField] GameObject wavePrefab;//波のプレハブ
    [Header("波の出現間隔")]
    [SerializeField] float waveIntervalTime = 0.1f;//波の出現間隔
    [Header("GamePos")]
    [SerializeField] GameObject gamePos;//GamePos
    private float waveTime = 0f;//波の出現間隔を管理する時間
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InstantiateWavePrefab();//波の生成
    }

    //波の生成、waveIntervalTimeの時間ごとに波を生成する
    void InstantiateWavePrefab()
    {
        waveTime += Time.deltaTime;//波の出現間隔を管理する時間を更新

        if (waveTime>waveIntervalTime)
        {
            waveTime = 0f;//波の出現間隔を管理する時間をリセット
            GameObject wave = Instantiate(wavePrefab, instantiateWavePos.transform.position, transform.rotation, gamePos.transform);//波を生成
            wave.transform.rotation = Quaternion.Euler(0, 180, 0);//波を後ろ向き(プレイヤー方向)にする
        }
    }
}
