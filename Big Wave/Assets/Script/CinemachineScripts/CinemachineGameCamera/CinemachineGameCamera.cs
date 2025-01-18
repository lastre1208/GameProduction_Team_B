using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲーム中のカメラの動き
public partial class CinemachineGameCamera : MonoBehaviour
{
    [Header("下にいる時のカメラ")]
    [SerializeField] CinemachineVirtualCamera _underCamera;
    [Header("上にいる時のカメラ")]
    [SerializeField] CinemachineVirtualCamera _upCamera;
    [Header("カメラ切り替え条件")]
    [Tooltip("ターゲットのローカル座標がこの値以上の時、カメラを切り替える")]
    [SerializeField] Range _range_switchCamera;
    [Header("ターゲット")]
    [SerializeField] Transform _target;

    void Update()
    {
        MonitoringTarget();
    }

    void MonitoringTarget()//プレイヤーの位置を監視(位置によってカメラを切り替える)
    {
        _range_switchCamera.UpdateOutOfRange(_target.localPosition);

        if (_range_switchCamera.GoOut) UpdateCamera(false);//範囲外に出た瞬間

        if (_range_switchCamera.GoIn) UpdateCamera(true);//範囲内に入った瞬間
    }

    void UpdateCamera(bool underCameraOn)
    {
        _underCamera.enabled = underCameraOn;
        _upCamera.enabled = !underCameraOn;
    }
}
