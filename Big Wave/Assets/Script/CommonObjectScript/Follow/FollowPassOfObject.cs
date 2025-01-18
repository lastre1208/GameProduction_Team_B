using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//オブジェクトを追跡する(fpsに左右されない)
public class FollowPassOfObject : MonoBehaviour
{
    [Header("追跡するターゲット")]
    [SerializeField] Transform _target;
    [Header("追跡させるオブジェクト")]
    [SerializeField] Transform _followObject;
    //[Header("補間速度")]
    //[Range(0f, 1f)]
    //[SerializeField] float lerpSpeed;  // 補完速度
    Queue<Vector3> _targetPosQueue=new Queue<Vector3>();//追跡するターゲットの位置を保存するキュー
    Queue<Quaternion> _targetRotQueue=new Queue<Quaternion>();//追跡するターゲットの回転を保存するキュー
    JudgePauseNow _judgePauseNow;
    bool _isFollow = false;//追跡するか

    public bool IsFollow
    {
        get { return _isFollow; }
        set { _isFollow = value; }
    }

    void Awake()
    {
        _judgePauseNow = GameObject.FindWithTag("PauseManager").GetComponentInChildren<JudgePauseNow>();
    }

    private void FixedUpdate()
    {
        if (_judgePauseNow.PauseNow) return;

        EnQueueTargetPos();

        Follow();
    }

    void EnQueueTargetPos()//追跡するターゲットの位置と回転をキューに登録
    {
        _targetPosQueue.Enqueue(_target.position);
        _targetRotQueue.Enqueue(_target.rotation);
    }

    void Follow()//追跡させる
    {
        if(!_isFollow) return;

        //位置と回転を取り出してそれを追跡させるオブジェクトに適用
        Vector3 targetPos= _targetPosQueue.Dequeue();
        Quaternion targetRot = _targetRotQueue.Dequeue();

        _followObject.position = targetPos;
        _followObject.rotation = targetRot;
    }
}
