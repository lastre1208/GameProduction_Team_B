using System.Collections.Generic;
using UnityEngine;

public class PathFollower_a : MonoBehaviour
{
    public Transform leadingObject;  // 先行オブジェクト（○）
    public float waitTime = 3.0f;    // 指定した秒数後に追従する時間差

    private Queue<Vector3> pathPoints_P = new Queue<Vector3>();  // 位置を保存するキュー
    private Queue<Quaternion> pathPoints_R = new Queue<Quaternion>();  // 回転を保存するキュー
    private int requiredQueueSize;  // 追従を開始するために必要なキューサイズ

    void Awake()
    {
        Application.targetFrameRate = 60;
        // 必要なキューサイズをフレームレートに基づいて計算
        requiredQueueSize = Mathf.RoundToInt(waitTime / Time.deltaTime); 
        Debug.Log(Mathf.RoundToInt(waitTime / Time.deltaTime));
        pathPoints_P.Enqueue(leadingObject.position);
        pathPoints_R.Enqueue(leadingObject.rotation);

    }

    void Update()
    {
        // 先行オブジェクトの位置と回転をキューに保存
        pathPoints_P.Enqueue(leadingObject.position);
        pathPoints_R.Enqueue(leadingObject.rotation);

        // 必要なキューサイズ分データが貯まるまで待機
        if (pathPoints_P.Count > requiredQueueSize)
        {
            
            // キューの最も古い位置と回転を取得してフォロワーを追従させる
            Vector3 target_P = pathPoints_P.Dequeue();
            Quaternion target_R = pathPoints_R.Dequeue();

            transform.position = target_P;
          
            transform.rotation = target_R;
        }
        
    }
}
