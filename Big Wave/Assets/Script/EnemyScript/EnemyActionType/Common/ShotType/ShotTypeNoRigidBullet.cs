using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//通常弾(NoRigidBullet)を撃つ
public class ShotTypeNoRigidBullet : ShotTypeBase
{
    [Header("▼GamePos")]
    [SerializeField] Transform gamePos;//GamePos、弾をこれの子オブジェクトとして配置する
    [Header("注:弾には必ずNoRigidBulletをつけたオブジェクトを入れること")]
    [SerializeField] BulletSettingTypeNoRigid[] bullets;//弾の設定
    VectorOfShotType vectorOfShotType;
    float currentDelayTime;//現在の遅延時間、これがdelayTimeに達した時弾が撃たれる

    void Start()
    {
        vectorOfShotType = GameObject.FindWithTag("VectorOfShot").GetComponent<VectorOfShotType>();
    }

    public override void InitShotTiming()//撃つタイミングの初期化
    {
        currentDelayTime = 0;

        for (int i = 0; i < bullets.Length; i++)//撃った判定の初期化
        {
            bullets[i].Shoted = false;
        }
    }

    public override void UpdateShotTiming()//撃つタイミングの更新
    {
        currentDelayTime += Time.deltaTime;

        for (int i = 0; i < bullets.Length; i++)
        {
            BulletSettingTypeNoRigid bullet = bullets[i];

            if (currentDelayTime >= bullet.DelayTime && !bullet.Shoted)
            {
                Shot(bullet);
            }
        }
    }

    void Shot(BulletSettingTypeNoRigid bullet)
    {
        bullet.Shoted = true;//撃った判定にする

        //攻撃を撃ちだす位置と角度を取得
        Vector3 shotPos = bullet.ShotPos.transform.position;//位置
        Quaternion shotRot = bullet.ShotPos.transform.rotation;//角度

        GameObject bulletObject = Instantiate(bullet.BulletPrefab, shotPos, shotRot, gamePos);//弾の生成

        NoRigidBullet noRigidBullet=bulletObject.GetComponentInChildren<NoRigidBullet>();//NoRigidBulletを取得

        if (noRigidBullet==null)//取得に失敗した場合エラーメッセージを出す
        {
            Debug.Log(name + "NoRigidBulletがアタッチされた弾をセットしてください");
            return;
        }

        Vector3 shotVec = vectorOfShotType.ShotVec(bullet.ShotType, bullet.ShotPos);//撃つ向きを決める

        noRigidBullet.SetBullet(bullet.Speed, shotVec);//弾の設定を決定
    }
}
