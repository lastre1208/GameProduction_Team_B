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
        DrawRope();
    }

    void OnDisable()
    {
        lineRenderer.positionCount = 0;//ロープの描写をなくす
    }

    void DrawRope()
    {
        int index = 0;
        foreach (GameObject v in vertices)
        {
            lineRenderer.SetPosition(index, v.transform.position);  // 質点の座標を設定
            index++;
        }
    }
}
