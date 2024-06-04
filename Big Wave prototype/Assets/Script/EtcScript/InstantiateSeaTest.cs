using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSeaTest : MonoBehaviour
{
    //☆桑原君が書いた
    [SerializeField] GameObject seaTestPrefab;//海のプレハブ
    [SerializeField] float instantiateIntervalTime = 6.2f;//海の出現間隔

    private float instantiatePrefabTime = 0f;//海の出現間隔を管理する時間

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateSeaTestPrefab();//海の生成
    }

    void InstantiateSeaTestPrefab()
    {
        instantiatePrefabTime += Time.deltaTime;//経過時間の計測

        if (instantiatePrefabTime > instantiateIntervalTime)//経過時間が一定の時間を超えたら
        {
            instantiatePrefabTime = 0f;//経過時間をリセット
            Instantiate(seaTestPrefab, transform.position, transform.rotation); //海の生成
        }
    }
}
