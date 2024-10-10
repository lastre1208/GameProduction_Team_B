using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BulletSettingTypeBase 
{
    [Header("▼弾")]
    [SerializeField] GameObject bulletPrefab;//撃ちだす弾
    [Header("▼弾を撃ちだす位置")]
    [SerializeField] protected Transform shotPos;//弾を撃ちだす位置
    [Header("▼行動開始から撃つまでの遅延時間")]
    [Header("注:行動時間未満にしないと撃たれずに行動が終わってしまう")]
    [SerializeField] protected float delayTime;//行動開始から撃つまでの遅延時間、行動時間未満にしないと撃たれずに行動が終わってしまう
    protected bool shoted;//弾を撃ったか

    public virtual GameObject BulletPrefab { get { return bulletPrefab; } }
    public Transform ShotPos { get { return shotPos; } }
    public float DelayTime { get { return delayTime; } }
    public bool Shoted { get { return shoted; } set { shoted = value; } }
}
