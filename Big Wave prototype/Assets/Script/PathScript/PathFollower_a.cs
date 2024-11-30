using System.Collections.Generic;
using UnityEngine;

public class PathFollower_a : MonoBehaviour
{
    [Header("先行するオブジェクト")]
    [SerializeField] Transform leadingObject;  //先行するオブジェクト
    private int waitCount;
    private float startPoint;//先行するオブジェクトのゲーム開始時の位置(ここを通過したフレームから追従を始める)
    private Queue<Vector3> pathPoints_P = new Queue<Vector3>();  // 位置を保存するキュー
    private Queue<Quaternion> pathPoints_R = new Queue<Quaternion>();  // 回転を保存するキュー
    [Header("キューの作成を何フレーム遅延させるか")]
    [SerializeField] int waitTime;
    [Header("補間速度")]
    [SerializeField] float lerpSpeed = 5f;  // Lerpの速度
    JudgePauseNow judgePauseNow;

    void Awake()
    {
        startPoint = leadingObject.position.z;
        judgePauseNow=GameObject.FindWithTag("PauseManager").GetComponentInChildren<JudgePauseNow>();
    }

    void Update()
    {
        if (judgePauseNow.PauseNow) return;

        if (waitCount >= waitTime)
        {
            pathPoints_P.Enqueue(leadingObject.position);  // 先行するオブジェクトの位置と回転を保持
            pathPoints_R.Enqueue(leadingObject.rotation);
        }
        waitCount++;

        // ゲーム開始時の先行オブジェクトの位置に到達したら追従を開始
        if (transform.position.z >= startPoint && pathPoints_P.Count > 0)
        {
            // キューの最も古い位置と回転を取得してフォロワーを追従させる
            Vector3 target_P = pathPoints_P.Dequeue();  // 位置と回転を反映させ次第キューから消す
            Quaternion target_R = pathPoints_R.Dequeue();

            // Lerpを使用してスムーズに移動
            transform.position = Vector3.Lerp(transform.position, target_P, lerpSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, target_R, lerpSpeed * Time.deltaTime);
        }
    }
}
