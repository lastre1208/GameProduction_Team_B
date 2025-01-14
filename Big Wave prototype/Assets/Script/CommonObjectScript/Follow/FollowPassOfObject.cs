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
    Queue<Transform> _targetTransformQueue=new Queue<Transform>();//追跡するターゲットの位置情報を保存するキュー
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

    void EnQueueTargetPos()//追跡するターゲットの位置情報をキューに登録
    {
        _targetTransformQueue.Enqueue(_target);
    }

    void Follow()//追跡させる
    {
        if(!_isFollow) return;

        //位置と回転を取り出してそれを追跡させるオブジェクトに適用
        Transform _targetTransform = _targetTransformQueue.Dequeue();

        Vector3 _targetPos= _targetTransform.position;
        Quaternion _targetRot = _targetTransform.rotation;

        _followObject.position = _targetPos;
        _followObject.rotation = _targetRot;
    }
}
