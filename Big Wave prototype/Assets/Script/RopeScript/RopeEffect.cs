using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeEffect : MonoBehaviour
{
    //☆作成者:桑原
    [SerializeField] HP player_Hp;
    [SerializeField] HP enemy_Hp;
    LineRenderer lineRenderer; // LineRendererコンポーネント

    [SerializeField] GameObject startPoint;//ロープの始点
    [SerializeField] GameObject endPoint;//ロープの終点
    [SerializeField] GameObject[] vertices = new GameObject[20];//ロープの質点

    void Start()
    {   
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = vertices.Length;

        foreach (GameObject v in vertices)
        {
            v.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void Update()
    {
        if (enemy_Hp.Hp > 0 && player_Hp.Hp > 0)
        {
            DrawRope();
        }

        else
        {
            lineRenderer.positionCount = 0;//ロープの描写をなくす
        }
    }

    void DrawRope()
    {
        //Vector3 enemyPosition = enemy.transform.position;//敵の座標を取得
        //Vector3 playerPosition = player.transform.position;//プレイヤーの座標を取得

        //Vector3 enemyLocalPosition= transform.InverseTransformPoint(enemyPosition);
        //Vector3 playerLocalPosition = transform.InverseTransformPoint(playerPosition);

        //enemyLocalPosition.z -= enemy.transform.localScale.z / 2f;
        //playerLocalPosition.z += player.transform.localScale.z / 2f;

        //enemyPosition= transform.TransformPoint(enemyLocalPosition);
        //playerPosition= transform.TransformPoint(playerLocalPosition);

        //startPoint.transform.position = playerPosition;//ロープの始点の座標をプレイヤーの座標に移動
        //endPoint.transform.position = enemyPosition;//ロープの終点の座標を敵の座標に移動

        int index = 0;
        foreach (GameObject v in vertices)
        {
            lineRenderer.SetPosition(index, v.transform.position);  // 質点の座標を設定
            index++;
        }
    }
}
