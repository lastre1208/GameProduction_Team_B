using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//非推奨
public class ShotTypeRigidBullet : ShotTypeBase
{
    [Header("注:弾には必ずRigidbodyをつけたオブジェクトを入れること")]
    [SerializeField] BulletSettingTypeRigid[] bullets;//弾の設定
    VectorOfShotType vectorOfShotType;

    void Start()
    {
        vectorOfShotType=GameObject.FindWithTag("VectorOfShot").GetComponent<VectorOfShotType>();
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

    void Shot(BulletSettingTypeRigid bulletSetting)
    {
        GameObject bulletObject = GenerateBullet(bulletSetting);
        //弾のRigidbodyを取得
        Rigidbody bulletObjectRb = bulletObject.GetComponent<Rigidbody>();
        //撃つ向きを決める
        Vector3 shotVec=vectorOfShotType.ShotVec(bulletSetting.ShotType,bulletSetting.ShotPos);
        //攻撃の向きを撃つ方向に変更
        bulletObject.transform.rotation = Quaternion.LookRotation(shotVec, Vector3.up);
        //弾を撃ちだす
        bulletObjectRb.AddForce(shotVec * bulletSetting.ShotPower, ForceMode.Impulse);
    }

    
}
