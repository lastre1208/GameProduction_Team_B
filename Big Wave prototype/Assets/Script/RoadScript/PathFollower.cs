using System.Collections.Generic;
using UnityEngine;

public class PathFollower: MonoBehaviour
{
    public Transform leadingObject; // 先行オブジェクト（○）
    

    // オブジェクトの位置（X軸）とY軸の回転を保存するキュー
    private Queue<Vector2> pathPoints = new Queue<Vector2>();
    private Queue<float> pathPoints_Z= new Queue<float>();
    void Update()
    {
        // 先行オブジェクトのX軸の位置とY軸の回転をキューに保存
        pathPoints.Enqueue(new Vector2(leadingObject.position.x, leadingObject.eulerAngles.y));
        pathPoints_Z.Enqueue(leadingObject.position.z);

        float targetZ=pathPoints_Z.Peek();
        if (pathPoints.Count > 0 && transform.position.z>=targetZ)
        {
            // キューの最も古い位置と回転を取得
            Vector2 target = pathPoints.Dequeue();
            float targetX = target.x;
            float targetRotationY = target.y;

            // 後続オブジェクトの新しい位置と回転を設定
            Vector3 newPosition = new Vector3(targetX, transform.position.y, transform.position.z);
            transform.position = newPosition;
            transform.rotation = Quaternion.Euler(0, targetRotationY, 0);
            Debug.Log("aaaa");
        }
    }
}
