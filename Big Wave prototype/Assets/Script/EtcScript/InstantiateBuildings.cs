using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBuildings : MonoBehaviour
{
    //☆作成者:桑原
    //☆後に杉山が一部改良
    [SerializeField] GameObject buildingsPrefab;//ビルのプレハブ
    [SerializeField] GameObject lastBuilding;//直前に生成されたビルのプレハブ
    [SerializeField] float generationDistance = 70f;//ビルの出現間隔

    private Vector3 lastPosition;
    private float buildingWidth;
    private float buildingDepth;

    // Start is called before the first frame update
    void Start()
    {
        if (buildingsPrefab != null)
        {
            BoxCollider collider = buildingsPrefab.GetComponent<BoxCollider>();

            if (collider != null)
            {
                buildingWidth = collider.size.x;
                buildingDepth = collider.size.z;
            }

            lastPosition = lastBuilding.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateBuildingsPrefab();//ビルの生成
    }

    void InstantiateBuildingsPrefab()
    {
        Vector3 newPosition = transform.position;

        if (Vector3.Distance(newPosition, lastPosition) > generationDistance)//今回生成するビルと前回生成されているビルの間隔が一定以上離れたら
        {
            bool isOverlapX = Mathf.Abs(newPosition.x - lastPosition.x) > buildingWidth;//x座標の間隔がビルのx軸サイズよりも大きいかどうか
            bool isOverlapZ = Mathf.Abs(newPosition.z - lastPosition.z) > buildingDepth;//z軸の間隔がビルのz軸サイズよりも大きいかどうか

            if (isOverlapX || isOverlapZ)//ビル同士の重なりがないなら
            {
                GameObject newBuilding = Instantiate(buildingsPrefab, newPosition, transform.rotation);

                lastPosition = newPosition;//最後に生成した建物の位置を更新
            }
        }
    }
}
