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

    public override void InitShotTiming()//撃つタイミングの初期化
    {
        base.InitShotTiming();
        ResetShoted(bullets);
    }

    public override void UpdateShotTiming()//撃つタイミングの更新
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

        NoRigidBullet noRigidBullet=bulletObject.GetComponentInChildren<NoRigidBullet>();

        //弾の設定をする(NoRigidBulletを取得出来てなかったらエラーメッセージを出す)
        if(noRigidBullet==null)
        {
            Debug.Log("弾プレハブにNoRigidBullet入ってません！");
            return;
        }

        noRigidBullet.SetBullet(bulletSetting.Speed, shotVec);
    }
}
