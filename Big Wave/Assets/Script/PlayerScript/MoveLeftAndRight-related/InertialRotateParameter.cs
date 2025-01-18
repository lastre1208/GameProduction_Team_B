using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬ÒFŒKŒ´

[System.Serializable]
public class InertialRotateParameter : MonoBehaviour
{
    [Header("¥‰ñ“]‚ÉŠÖ‚·‚éİ’è")]
    [Header("‰ñ“]‚Ì‹­‚³")]
    [SerializeField] float rotationStrength = 10f;
    [Header("Å‘å‰ñ“]Šp“x")]
    [SerializeField] float maxRotationAngle = 45f;
    [Header("‰ñ“]‚ğ‚à‚Æ‚É–ß‚·‘¬‚³")]
    [SerializeField] float rotationReturnSpeed = 10f;

    public float RotationStrength { get { return rotationStrength; } }
    public float MaxRotationAngle { get { return maxRotationAngle; } }
    public float RotationReturnSpeed { get {  return rotationReturnSpeed; } }
}