using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAtInterval : MonoBehaviour
{
    //☆作成者:桑原
    [SerializeField] List <GameObject> instantiatePrefabs;//生成するプレハブ
    [SerializeField] float instantiateIntervalTime = 1.5f;//生成出現間隔
    private float instantiateCurrentTime = 0f;//出現間隔を管理する時間
    private GameObject instantiatePrefab;
    // Start is called before the first frame update
    void Start()
    {
        instantiateCurrentTime = instantiateIntervalTime;
    }

    // Update is called once per frame
    void Update()
    {
        InstantiatePrefab();//生成
    }

    void InstantiatePrefab()
    {
        instantiateCurrentTime += Time.deltaTime;//経過時間の計測

        if (instantiateCurrentTime > instantiateIntervalTime)//経過時間が一定の時間を超えたら
        {
            instantiateCurrentTime = 0f;//経過時間をリセット
            SetObject();
            Instantiate(instantiatePrefab, transform.position, transform.rotation); //生成
        }
    }
    void SetObject()
    {
        instantiatePrefab = instantiatePrefabs[Random.Range(0,instantiatePrefabs.Count-1)];
    }
}
