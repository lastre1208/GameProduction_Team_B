using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//指定オブジェクトとy軸とz軸を同じ方向を向かせる
public class CinemachineExtend_Look : CinemachineExtension
{
    [Header("これに入れたオブジェクトとy軸のみ常に同じ方向を向くようになる")]
    [SerializeField] Transform lookObj;

    // カメラワーク処理
    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage,
        ref CameraState state,
        float deltaTime
    )
    {
        // Aimの直後だけ処理を実施
        if (stage != CinemachineCore.Stage.Aim)
            return;

        //y軸とz軸を同じ方向を向かせる
        var eulerAngles = state.RawOrientation.eulerAngles;
        eulerAngles.y=lookObj.eulerAngles.y;
        eulerAngles.z = 0;
        state.RawOrientation = Quaternion.Euler(eulerAngles);
        //Quaternion rot = state.RawOrientation;
        //rot.y=lookObj.rotation.y;
        //rot.z=0;
        //state.RawOrientation = rot;
    }
}
