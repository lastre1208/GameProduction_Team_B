using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBuildings : MonoBehaviour
{
    //☆作成者:桑原
    //☆後に杉山が一部改良
    [Header("生成させたいオブジェクトを入れてください")]
    [SerializeField] RandomGetGameObject randomGetGameObject = new RandomGetGameObject();//登録したオブジェクトをランダムに取得する
    //[SerializeField] GameObject buildingsPrefab;//生成する建物のプレハブ
    [SerializeField] GameObject lastBuilding;//直前に生成された建物のプレハブ

    private Vector3 lastPosition;
    private float building_sizeX;//建物のx軸方向の大きさ
    private float building_sizeZ;//建物のz軸方向の大きさ

    // Start is called before the first frame update
    void Start()
    {
        if (randomGetGameObject != null)
        {
            BoxCollider collider = randomGetGameObject[0].GetComponent<BoxCollider>();

            if (collider != null)
            {
                building_sizeX = collider.size.x;
                building_sizeZ = collider.size.z;
            }
        }

        if (lastBuilding != null)
        {
            lastPosition = lastBuilding.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateBuildingsPrefab();//建物の生成
    }

    void InstantiateBuildingsPrefab()//建物の生成
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = (currentPosition - lastPosition).normalized; //前回の位置から現在の位置への進行方向ベクトル
        
        float minGenerationDistance = Mathf.Max(building_sizeX, building_sizeZ);//建物のサイズに応じた生成間隔の設定

        if (Vector3.Distance(currentPosition, lastPosition) > minGenerationDistance)//指定された距離以上離れたときにのみ生成
        {            
            Vector3 newPosition = lastPosition + direction * minGenerationDistance;//進行方向に沿った新しい位置の計算
            
            GameObject newBuilding = Instantiate(randomGetGameObject.GetObjectRandom(), newPosition, transform.rotation);//新しい建物を生成

            lastPosition = newPosition;//最後に生成した建物の位置を更新
        }
    }
}
