using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSettingTypeHoming : BulletSettingTypeBase
{
    [Header("発射されて何秒後からホーミングし始めるか")]
    [SerializeField] float startHomingTime;//発射されて何秒後からホーミングし始めるか
    [Header("何秒間ホーミングするか")]
    [SerializeField] float homingTime;//何秒間ホーミングするか
    [Header("標的に向く速度")]
    [Tooltip("1秒間にhomingSpeed度の速度で向きます")]
    [SerializeField] float homingSpeed;//標的に向く速度
    [Header("弾の移動速度")]
    [SerializeField] float speed;//弾の移動速度

    public float StartHomingTime { get { return startHomingTime; } }
    public float HomingTime { get { return homingTime; } }
    public float HomingSpeed { get { return homingSpeed; } }
    public float Speed { get { return speed; } }
}
