using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletSettingTypeNoRigid : BulletSettingTypeBase
{
    [Header("射撃の種類")]
    [SerializeField] ShotType shotType;
    [Header("弾のスピード")]
    [SerializeField] float speed;

    public ShotType ShotType { get { return shotType; } }
    public float Speed { get { return speed; } }
}
