using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTypeHomingBullet : ShotTypeBase
{
    [Header("注:弾には必ずHomingBulletをつけたオブジェクトを入れること")]
    [SerializeField] BulletSettingTypeHoming[] bullets;//弾の設定
    public override void InitShotTiming()
    {
        base.InitShotTiming();
        ResetShoted(bullets);
    }

    public override void UpdateShotTiming()
    {
        base.UpdateShotTiming();
        for(int i=0; i<bullets.Length;i++)
        {
            if (NotifyShotTiming(bullets[i]))
            {
                Shot(bullets[i]);
            }
        }
    }

    void Shot(BulletSettingTypeHoming bulletSetting)
    {
        GameObject bulletObject = GenerateBullet(bulletSetting);
        HomingBullet homingBulletObject=bulletObject.GetComponent<HomingBullet>();
        //配置したホーミング弾の設定
        homingBulletObject.SetHomingBullet(bulletSetting.StartHomingTime, bulletSetting.HomingTime, bulletSetting.HomingSpeed, bulletSetting.Speed);
    }
}
