using System.Collections.Generic;
using UnityEngine;

public class PathFollower: MonoBehaviour
{
    public Transform leadingObject; // 先行オブジェクト（○）
    public float waitTime;
    private float countTime;
    // オブジェクトの位置（X軸）とY軸の回転を保存するキュー
    private Queue<Vector3> pathPoints_P = new Queue<Vector3>();
    private Queue<Quaternion> pathPoints_R= new Queue<Quaternion>();
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        // 先行オブジェクトのX軸の位置とY軸の回転をキューに保存
        pathPoints_P.Enqueue(leadingObject.position);
        pathPoints_R.Enqueue(leadingObject.rotation);
        countTime += Time.deltaTime;

        if (pathPoints_R.Count > 0)
        {
            // キューの最も古い位置と回転を取得
           

            if (waitTime<=countTime) {

               
                // 後続オブジェクトの新しい位置と回転を設定
               Vector3 target_P = pathPoints_P.Dequeue();
               Quaternion target_R = pathPoints_R.Dequeue();
                transform.position = target_P;
                transform.rotation = target_R;
             
            }
           
        }
    }
}
