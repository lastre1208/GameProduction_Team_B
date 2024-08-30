using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class BulletTypeShotHoming
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
    [Header("▼弾を撃ちだす位置と角度")]
    [SerializeField] Transform shotPos;//弾を撃ちだす位置
    [Header("▼行動開始から撃つまでの遅延時間")]
    [Header("注:行動時間未満にしないと撃たれずに行動が終わってしまう")]
    [SerializeField] float delayTime;//行動開始から撃つまでの遅延時間、行動時間未満にしないと撃たれずに行動が終わってしまう
    private bool shoted;//弾を撃ったか

    public HomingBullet BulletPrefab
    {
        get { return bulletPrefab; }
    }

    public Transform ShotPos
    {
        get { return shotPos; }
    }

    public void OnEnter()//行動開始時に呼ぶ
    {
        shoted = false;
    }

    public bool JudgeShot(float currentDelayTime)//撃つ時はtrueを返す
    {
        if (currentDelayTime >= delayTime && !shoted)//指定の遅延時間に達したかつまだ弾を撃っていない時
        {
            return true;
        }

        return false;
    }

    public void SettingHomingBullet(HomingBullet bullet)//配置したホーミング弾の設定
    {
        bullet.SetHomingBullet(startHomingTime, homingTime, homingSpeed, speed);
        shoted = true;
    }
}

public class EnemyActionTypeRepeatedShotHoming : EnemyActionTypeBase
{
    [Header("弾の設定")]
    [SerializeField] BulletTypeShotHoming[] bullets;//弾の設定
    [Header("▼GamePos")]
    [SerializeField] GameObject gamePos;//GamePos、弾をこれの子オブジェクトとして配置する
    [Header("行動時のエフェクト")]
    [SerializeField] ActionEffect actionEffect;
    private float currentDelayTime;//現在の遅延時間、これがdelayTimeに達した時弾が撃たれる

    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        currentDelayTime = 0;
        actionEffect.Generate();//エフェクト生成
        for(int i=0;i<bullets.Length ;i++)
        {
            bullets[i].OnEnter();
        }
    }

    public override void OnUpdate()
    {
        currentDelayTime += Time.deltaTime;

        for(int i=0;i<bullets.Length ;i++)
        {
            if (bullets[i].JudgeShot(currentDelayTime))
            {
                Shot(bullets[i]);
            }
        }
    }

    void Shot(BulletTypeShotHoming bullet)
    {
        HomingBullet bulletObject= Instantiate(bullet.BulletPrefab, bullet.ShotPos.position, bullet.ShotPos.rotation, gamePos.transform);
        bullet.SettingHomingBullet(bulletObject);
    }
}
