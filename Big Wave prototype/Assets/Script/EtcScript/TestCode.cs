using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    public float t = 0.1f;
    public GameObject target;
    void Update()
    {
        Vector3 targetPos = target.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, t);
    }
}
