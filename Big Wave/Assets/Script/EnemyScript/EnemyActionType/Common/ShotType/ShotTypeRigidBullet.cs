using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//通常弾(Rigidbody)を撃つ
public class ShotTypeRigidBullet : ShotTypeBase
{
    [Header("▼GamePos")]
    [SerializeField] Transform gamePos;//GamePos、弾をこれの子オブジェクトとして配置する
    [Header("注:弾には必ずRigidbodyをつけたオブジェクトを入れること")]
    [SerializeField] BulletSettingTypeRigid[] bullets;//弾の設定
    VectorOfShotType vectorOfShotType;
    float currentDelayTime;//現在の遅延時間、これがdelayTimeに達した時弾が撃たれる
   [SerializeField] float torquePower;//回転する力。
    void Start()
    {
        vectorOfShotType=GameObject.FindWithTag("VectorOfShot").GetComponent<VectorOfShotType>();
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
            BulletSettingTypeRigid bullet = bullets[i];

            if (currentDelayTime >= bullet.DelayTime && !bullet.Shoted)
            {
                Shot(bullet);
            }
        }
    }

    void Shot(BulletSettingTypeRigid bullet)
    {
        bullet.Shoted = true;//撃った判定にする

        //攻撃を撃ちだす位置と角度を取得
        Vector3 shotPos = bullet.ShotPos.transform.position;//位置
        Quaternion shotRot = bullet.ShotPos.transform.rotation;//角度

        GameObject bulletObject = Instantiate(bullet.BulletPrefab, shotPos, shotRot, gamePos);//弾の生成

        Rigidbody rb = bulletObject.GetComponentInChildren<Rigidbody>();//RigidBodyを取得

        if(rb==null)//取得に失敗した場合エラーメッセージを出す
        {
            Debug.Log(name + "Rigidbodyがアタッチされた弾をセットしてください");
            return;
        }

        Vector3 shotVec=vectorOfShotType.ShotVec(bullet.ShotType,bullet.ShotPos);//撃つ向きを決める

        bulletObject.transform.rotation = Quaternion.LookRotation(shotVec, Vector3.up);//攻撃の向きを撃つ方向に変更

        rb.AddForce(shotVec * bullet.ShotPower, ForceMode.Impulse);//弾を撃ちだす
        rb.AddTorque(-transform.right*torquePower, ForceMode.Impulse);
    }
}
