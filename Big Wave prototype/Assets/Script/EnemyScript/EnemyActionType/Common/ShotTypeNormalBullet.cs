using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTypeNormalBullet : ShotTypeBase
{
    [Header("注:弾には必ずRigidbodyをつけたオブジェクトを入れること")]
    [SerializeField] BulletSettingTypeNormal[] bullets;//弾の設定
    [Header("プレイヤー")]
    [Tooltip("プレイヤーに向かって撃つ弾が無ければ設定しなくてもよい")]
    [SerializeField] Transform player;//プレイヤー
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

    void Shot(BulletSettingTypeNormal bulletSetting)
    {
        GameObject bulletObject = GenerateBullet(bulletSetting);
        //弾のRigidbodyを取得
        Rigidbody bulletObjectRb = bulletObject.GetComponent<Rigidbody>();
        //撃つ向きを決める
        Vector3 shotVec=ShotVec(bulletSetting.ShotType,bulletSetting.ShotPos);
        //攻撃の向きをプレイヤーのいる方向に変更
        bulletObject.transform.rotation = Quaternion.LookRotation(shotVec, Vector3.up);
        //弾を撃ちだす
        bulletObjectRb.AddForce(shotVec * bulletSetting.ShotPower, ForceMode.Impulse);
    }

    Vector3 ShotVec(ShotType shotType,Transform shotPos)
    {
        switch(shotType)
        {
            case ShotType.toPlayer:
                return (player.transform.position - shotPos.position).normalized;
            case ShotType.forward:
                return shotPos.forward;
            default:
                return Vector3.zero;
        }
    }
}
