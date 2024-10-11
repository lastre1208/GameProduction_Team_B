using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class BulletSettingTypeRigid : BulletSettingTypeBase
{
    [Header("ËŒ‚‚Ìí—Ş")]
    [SerializeField] ShotType shotType;
    [Header("¥Œ‚‚Â—Í")]
    [SerializeField] float shotPower;//Œ‚‚Â—Í

    public ShotType ShotType { get { return shotType; } }
    public float ShotPower { get { return shotPower; } }
}
