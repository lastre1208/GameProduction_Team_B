using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeEffect : MonoBehaviour
{
    //☆桑原君が書いた
    Enemy enemy;
    Player player;
    LineRenderer lineRenderer; // LineRendererコンポーネント

    [SerializeField] GameObject startPoint;//ロープの始点
    [SerializeField] GameObject endPoint;//ロープの終点
    public GameObject[] vertices = new GameObject[20];//ロープの質点

    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = vertices.Length;

        foreach (GameObject v in vertices)
        {
            v.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void Update()
    {
        if (enemy.Hp > 0 && player.Hp > 0)
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
        Vector3 enemyPosition = enemy.transform.position;//敵の座標を取得
        Vector3 playerPosition = player.transform.position;//プレイヤーの座標を取得
        enemyPosition.z -= enemy.transform.localScale.z / 2f;
        playerPosition.z += player.transform.localScale.z / 2f;

        startPoint.transform.position = playerPosition;//ロープの視点の座標にプレイヤーの座標に移動
        endPoint.transform.position = enemyPosition;//ロープの終点の座標を敵の座標に移動

        int index = 0;
        foreach (GameObject v in vertices)
        {
            lineRenderer.SetPosition(index, v.transform.position);  // 質点の座標を設定
            index++;
        }
    }
}
