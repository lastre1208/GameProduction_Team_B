using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTypeNoRigidBullet : ShotTypeBase
{
    [Header("注:弾には必ずNoRigidBulletをつけたオブジェクトを入れること")]
    [SerializeField] BulletSettingTypeNoRigid[] bullets;//弾の設定
    VectorOfShotType vectorOfShotType;

    // Start is called before the first frame update
    void Start()
    {
        vectorOfShotType = GameObject.FindWithTag("VectorOfShot").GetComponent<VectorOfShotType>();
    }

    public override void InitShotTiming()
    {
        base.InitShotTiming();
        ResetShoted(bullets);
    }

    public override void UpdateShotTiming()
    {
        base.UpdateShotTiming();
        for (int i = 0; i < bullets.Length; i++)
        {
            if (NotifyShotTiming(bullets[i]))
            {
                Shot(bullets[i]);
            }
        }
    }

    void Shot(BulletSettingTypeNoRigid bulletSetting)
    {
        GameObject bulletObject = GenerateBullet(bulletSetting);
        //撃つ向きを決める
        Vector3 shotVec = vectorOfShotType.ShotVec(bulletSetting.ShotType, bulletSetting.ShotPos);
        NoRigidBullet noRigidBullet=bulletObject.GetComponent<NoRigidBullet>();
        //弾の設定をする
        noRigidBullet.SetBullet(bulletSetting.Speed, shotVec);
    }
}
