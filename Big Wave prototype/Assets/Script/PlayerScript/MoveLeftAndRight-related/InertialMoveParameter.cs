using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

[System.Serializable]
public class InertialMoveParameter : MonoBehaviour
{
    [Header("▼移動に関する設定")]
    [Header("加速度")]
    [SerializeField] float acceleration = 60f;
    [Header("減速度")]
    [SerializeField] float deceleration = 30f;
    [Header("最高速度")]
    [SerializeField] float targetSpeed = 100f;
    [Header("目標位置に引き寄せる力")]
    [SerializeField] float targetPullStrength = 10f;
    [Header("引き寄せる力の最大値")]
    [SerializeField] float maxPullStrength = 100f;
    [Header("移動にかかる慣性をなくすx座標")]
    [SerializeField] float maxLocalPosition_X = 9f;

    public float Acceleration { get { return acceleration; } }
    public float Deceleration { get { return deceleration; } }
    public float TargetSpeed { get {  return targetSpeed; } }
    public float TargetPullStrength { get {  return targetPullStrength; } }
    public float MaxPullStrength { get { return maxPullStrength; } }
    public float MaxLocalPosition_X { get {  return maxLocalPosition_X; } }
}