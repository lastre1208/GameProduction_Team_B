using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShotType_E
{
    forward,
    toPlayer
}

[System.Serializable]
public class BulletSettingTypeNormal : BulletSettingTypeBase
{
    [Header("ËŒ‚‚Ìí—Ş")]
    [SerializeField] ShotType_E shotType;
    [Header("¥Œ‚‚Â—Í")]
    [SerializeField] float shotPower;//Œ‚‚Â—Í

    public ShotType_E ShotType { get { return shotType; } }
    public float ShotPower { get { return shotPower; } }
}
