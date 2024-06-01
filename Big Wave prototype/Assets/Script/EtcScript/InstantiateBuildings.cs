using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBuildings : MonoBehaviour
{
    //☆桑原君が書いた
    [SerializeField] GameObject buildingsPrefab;//ビルのプレハブ
    [SerializeField] GameObject buildingsGroundPrefab;//ビルの地面部のプレハブ
    [SerializeField] float buildingsPrefabPosX = -37f;//生成するビルのX軸の座標（調整用）
    [SerializeField] float buildingsPrefabRotY = 90f;//生成するビルのY軸の角度（調整用）
    [SerializeField] float buildingsGroundPrefabPosX = -48f;//生成するビルの地面部のX軸の位置（調整用）
    [SerializeField] float instantiateIntervalTime = 2.5f;//ビルの出現間隔

    private float instantiatePrefabTime = 0f;//ビルの出現間隔を管理する時間
    private int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateBuildingsPrefab();//ビルの生成
    }

    void InstantiateBuildingsPrefab()
    {
        instantiatePrefabTime += Time.deltaTime;//経過時間の計測

        if(instantiatePrefabTime > instantiateIntervalTime)//経過時間が一定の時間を超えたら
        {
            randomNumber = Random.Range(0, 2);
            instantiatePrefabTime = 0f;//経過時間をリセット

            Instantiate(buildingsGroundPrefab,
                new Vector3(buildingsGroundPrefabPosX, transform.position.y, transform.position.z),
                transform.rotation);//ビルの地面部の生成

            if (randomNumber == 0)//ランダムに取得した値が0だった場合
            {
                Instantiate(buildingsPrefab,
                    new Vector3(buildingsPrefabPosX, transform.position.y, transform.position.z),
                    Quaternion.Euler(0f, buildingsPrefabRotY, 0f));
                //buildingsPrefabRotYの値の分だけY軸に回転させて表示
            }

            else//ランダムに取得した値が1だった場合
            {
                Instantiate(buildingsPrefab,
                   new Vector3(buildingsPrefabPosX, transform.position.y, transform.position.z),
                   Quaternion.Euler(0f, -buildingsPrefabRotY, 0f));
                //buildingsPrefabRotYの値の分だけY軸に逆回転させて表示
            }
        }
    }
}
