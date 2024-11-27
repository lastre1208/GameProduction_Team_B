using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//カメラの軸を追従目標と同じ方向に向くように固定させる
public class CinemachineExtend_Look : CinemachineExtension
{
    [Header("追従目標")]
    [SerializeField] Transform target;
    [Header("固定する軸")]
    [SerializeField] bool x;
    [SerializeField] bool y;
    [SerializeField] bool z;

    public bool X
    {
        get { return x; }
        set { x = value; }
    }

    public bool Y
    { 
        get { return y; }
        set {  y = value; } 
    }

    public bool Z
    {
        get { return z; }
        set { z = value; }
    }

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

        //チェックを入れた固定軸に対して固定する
        var eulerAngles = state.RawOrientation.eulerAngles;
        if (x) eulerAngles.x = target.eulerAngles.x;//x軸の固定
        if (y) eulerAngles.y = target.eulerAngles.y;//x軸の固定
        if (z) eulerAngles.z = target.eulerAngles.z;//x軸の固定
        state.RawOrientation = Quaternion.Euler(eulerAngles);
    }

    
}
