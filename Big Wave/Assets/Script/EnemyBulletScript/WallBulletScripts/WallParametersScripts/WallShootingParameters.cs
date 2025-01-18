using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WallShootingParameters
{
    [Header("撃つ力")]
    [SerializeField] protected float shotPower = 90f;
    [Header("壁を生成してから撃つまでの遅延時間")]
    [Header("注:行動時間未満にしないと撃たれずに行動が終わってしまう")]
    [SerializeField] float delayTime = 2.0f;
    [Header("生成した壁を一度にすべて発射するかどうか")]
    [SerializeField] bool isShotAllAtOnce = false;
    [Header("壁を一枚ずつ発射する場合の間隔")]
    [SerializeField] float intervalShotTime = 0.25f;

    public float ShotPower { get { return shotPower; } }
    public float DelayTime { get { return delayTime; } }
    public bool IsShotAllAtOnce { get { return isShotAllAtOnce; } }
    public float IntervalShotTime { get { return intervalShotTime; } }
}