using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:桑原(後に杉山が改造)
//最後に生成された建物の大きさ(BoxColliderから取得)と位置を参照して建物を生成する
public class InstantiateBuildings : MonoBehaviour
{
    [Header("生成させたい建物(BoxColiderがついているもの限定)")]
    [SerializeField] RandomGet<GameObject> randomGetGameObject = new RandomGet<GameObject>();//登録したオブジェクトをランダムに取得する
    [Header("直前に生成された建物(BoxColiderがついているもの限定)")]
    [SerializeField] GameObject lastBuilding;//最後に生成された建物
    private GameObject newBuilding;//新しく生成する建物
    private Vector3 lastPosition;//最後に生成された位置
    private float minimumNecessaryDistanceToGenerate;//生成するのに最低限必要な距離

    void Start()
    {
        DecideMinimumNecessaryDistanceToGenerate();//生成するのに最低限必要な距離を求める
        lastPosition = lastBuilding.transform.position;//最後に生成された位置を記録
    }

    void Update()
    {
        InstantiateBuildingsPrefab();//建物の生成
    }

    void InstantiateBuildingsPrefab()//建物の生成
    {
        //現在の位置と最後に生成された位置との距離を測る
        Vector3 currentPos = transform.position;
        float distance = Vector3.Distance(currentPos, lastPosition);

        //距離と生成するのに最低限必要な距離を比較して十分に距離が離れていれば建物を生成
        if (distance > minimumNecessaryDistanceToGenerate)
        {
            lastBuilding = GenerateNewBuilding((currentPos - lastPosition).normalized);//建物の生成処理

            lastPosition = lastBuilding.transform.position;

            DecideMinimumNecessaryDistanceToGenerate();//生成するのに最低限必要な距離を求める
        }
    }

    //建物の生成処理、directionは前回生成した位置から現在の位置への方向ベクトル
    //最後に生成された建物を返す(BoxCollider型で)
    GameObject GenerateNewBuilding(Vector3 direction)
    {
        //進行方向に沿って新しい建物を生成する位置を計算
        Vector3 newPosition = lastPosition + direction * minimumNecessaryDistanceToGenerate;
        //生成
        GameObject newBuildingObject = Instantiate(newBuilding.gameObject, newPosition, transform.rotation);
        //角度を調整？(ここがもともとマジックナンバーが使われていて意図がよく分からなかったby塩)
        newBuildingObject.transform.Rotate(0, Random.Range(0, 4) * 90, 0);

        return newBuildingObject;
    }

    //生成するのに最低限必要な距離を求める
    void DecideMinimumNecessaryDistanceToGenerate()
    {
        newBuilding = randomGetGameObject.Get();//次に生成する建物を決める

        //最後に生成された建物の大きさを測る
        BoxCollider lastBuildingCollider = lastBuilding.GetComponent<BoxCollider>();
        if (lastBuildingCollider == null) Debug.Log("BoxColliderがついていません！");

        Vector3 lastBuildingSize = lastBuildingCollider.size;

        //次に生成する建物の大きさを測る
        BoxCollider newBuildingCollider=newBuilding.GetComponent<BoxCollider>();
        if (newBuildingCollider == null) Debug.Log("BoxColliderがついていません！");

        Vector3 newBuildingSize = newBuildingCollider.size;

        //生成条件距離を決める(最後の建物の大きさ/2+次に生成する建物の大きさ/2)
        //この時大きさは縦(z)と横(x)で大きい方を扱う(高さ(y)は測らない)
        float last_d2 = Mathf.Max(lastBuildingSize.x, lastBuildingSize.z) / 2;//最後の建物の大きさ/2
        float new_d2 = Mathf.Max(newBuildingSize.x, newBuildingSize.z) / 2;//次に生成する建物の大きさ/2
        minimumNecessaryDistanceToGenerate = last_d2 + new_d2;
    }
}
