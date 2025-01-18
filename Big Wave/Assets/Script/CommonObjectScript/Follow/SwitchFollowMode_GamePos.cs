using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//追跡状態を切り替える
//とりあえず追跡させるオブジェクトが追跡するターゲットの初期z座標を越えたら追跡モードに切り替える(それまでは追跡させるオブジェクトは単純に前に進ませる)
public class SwitchFollowMode_GamePos : MonoBehaviour
{
    [Header("追跡するターゲット")]
    [SerializeField] Transform _target;
    [Header("追跡させるオブジェクト")]
    [SerializeField] Transform _followObject;
    [Header("追跡モードに切り替えるまでの前方移動速度")]
    [SerializeField] float _speed;
    [Header("追跡の設定")]
    [SerializeField] FollowPassOfObject _follow;
    float _targetDefaultPos_Z;//追跡ターゲットの初期z座標

    private void Start()
    {
        //追跡ターゲットの初期z座標を保存
        _targetDefaultPos_Z=_target.position.z;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        //既に追跡モードになってれば無視
        if (_follow.IsFollow) return;

        //追跡させるオブジェクトが追跡ターゲットの初期z座標を越えるまでは
        //普通に前方移動
        //越えたら追跡モードに切り替え

        bool exceeded=_followObject.position.z >= _targetDefaultPos_Z;//初期z座標を超えたか

        if (exceeded)
        {
            _follow.IsFollow = true;
        }
        else
        {
            Vector3 moveVec = Vector3.forward;
            _followObject.transform.Translate(moveVec * _speed * Time.deltaTime);
        }
    }
}
