using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShotType
{
    forward,
    toPlayer
}

public class VectorOfShotType : MonoBehaviour
{
    [SerializeField] Transform player;

    public Vector3 ShotVec(ShotType shotType, Transform shotPos)
    {
        switch (shotType)
        {
            case ShotType.toPlayer:
                return (player.transform.position - shotPos.position).normalized;
            case ShotType.forward:
                return shotPos.forward;
            default:
                return Vector3.zero;
        }
    }
}
