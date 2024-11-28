using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//作成者:杉山
//カメラが指定の範囲外に出たらターゲットを追従し始める
public partial class CameraChaseTargetOutOfRange : MonoBehaviour
{
    [SerializeField] CinemachineTargetGroup m_TargetGroup;
    [SerializeField] float weight;
    [SerializeField] float radius;
    [SerializeField] Transform target;
    [SerializeField] Range range;

    void Update()
    {
        UpdateCameraChase();
    }

    void UpdateCameraChase()
    {
        range.UpdateOutOfRange(target.localPosition);

        if(range.GoOut)//範囲外に出た瞬間
        {
            m_TargetGroup.AddMember(target, weight, radius);
        }
        //範囲内に入った瞬間
        if(range.GoIn)
        {
            m_TargetGroup.RemoveMember(target);
        }
    }
}
