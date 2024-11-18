using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTypeHomingBullet : ShotTypeBase
{
    [Header("注:弾には必ずHomingBulletをつけたオブジェクトを入れること")]
    [SerializeField] BulletSettingTypeHoming[] bullets;//弾の設定
    public override void InitShotTiming()//撃つタイミングの初期化
    {
        base.InitShotTiming();
        ResetShoted(bullets);
    }

    public override void UpdateShotTiming()//撃つタイミングの更新
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

        HomingBullet homingBulletObject=bulletObject.GetComponentInChildren<HomingBullet>();

        //配置したホーミング弾の設定(HomingBulletを取得出来てなかったらエラーメッセージを出す)
        if(homingBulletObject==null)
        {
            Debug.Log("弾プレハブにHomingBullet入ってません！");
            return;
        }

        homingBulletObject.SetBullet(bulletSetting.StartHomingTime, bulletSetting.HomingTime, bulletSetting.HomingSpeed, bulletSetting.Speed);
    }
}
