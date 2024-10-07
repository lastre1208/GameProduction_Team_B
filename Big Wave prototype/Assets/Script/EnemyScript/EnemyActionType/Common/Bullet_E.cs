using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType_E
{
    normal,
    homing
}

public enum ShotType_E
{
    forward,
    toPlayer
}

[System.Serializable]
public class Bullet_E 
{
    [Header("弾の種類")]
    [SerializeField] BulletType_E bulletType;
    [Header("▼弾を撃ちだす位置")]
    [SerializeField] Transform shotPos;//弾を撃ちだす位置
    [Header("▼行動開始から撃つまでの遅延時間")]
    [Header("注:行動時間未満にしないと撃たれずに行動が終わってしまう")]
    [SerializeField] float delayTime;//行動開始から撃つまでの遅延時間、行動時間未満にしないと撃たれずに行動が終わってしまう

    [SerializeField] Bullet_Normal_E normal;
    [SerializeField] Bullet_Homing_E homing;
    
    private bool shoted;//弾を撃ったか

    public BulletType_E BulletType { get { return bulletType; }  }
    public Transform ShotPos { get { return shotPos; } }
    public float DelayTime { get {  return delayTime; } }
    public bool Shoted { get { return shoted; } set { shoted = value; } }
    public Bullet_Normal_E Normal { get { return normal; } }
    public Bullet_Homing_E Homing_E { get { return homing; } }


    //通常弾
    [System.Serializable]
    public class Bullet_Normal_E
    {
        [Header("射撃の種類")]
        [SerializeField] ShotType_E shotType;
        [Header("▼弾")]
        [SerializeField] GameObject bulletPrefab;//撃ちだす弾
        [Header("▼撃つ力")]
        [SerializeField] float shotPower;//撃つ力

        public ShotType_E ShotType { get { return shotType; } }
        public GameObject BulletPrefab { get { return bulletPrefab; } }
        public float ShotPower { get {  return shotPower; }  }
    }

    //ホーミング弾
    [System.Serializable]
    public class Bullet_Homing_E
    {
        [Header("▼ホーミングする弾")]
        [SerializeField] HomingBullet bulletPrefab;//ホーミング弾
        [Header("発射されて何秒後からホーミングし始めるか")]
        [SerializeField] float startHomingTime;//発射されて何秒後からホーミングし始めるか
        [Header("何秒間ホーミングするか")]
        [SerializeField] float homingTime;//何秒間ホーミングするか
        [Header("標的に向く速度")]
        [Tooltip("1秒間にhomingSpeed度の速度で向きます")]
        [SerializeField] float homingSpeed;//標的に向く速度
        [Header("弾の移動速度")]
        [SerializeField] float speed;//弾の移動速度

        public HomingBullet BulletPrefab { get { return bulletPrefab; } }
        public float StartHomingTime { get {  return startHomingTime; } }
        public float HomingTime { get { return homingTime; } }
        public float HomingSpeed { get {  return homingSpeed; } }
        public float Speed { get { return speed; } }
    }
}
