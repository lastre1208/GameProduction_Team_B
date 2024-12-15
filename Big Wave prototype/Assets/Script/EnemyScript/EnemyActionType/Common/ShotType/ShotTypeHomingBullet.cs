using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//ホーミング弾を撃つ
public class ShotTypeHomingBullet : ShotTypeBase
{
    [Header("▼GamePos")]
    [SerializeField] Transform gamePos;//GamePos、弾をこれの子オブジェクトとして配置する
    [Header("注:弾には必ずHomingBulletをつけたオブジェクトを入れること")]
    [SerializeField] BulletSettingTypeHoming[] bullets;//弾の設定
    float currentDelayTime;//現在の遅延時間、これがdelayTimeに達した時弾が撃たれる

    public override void InitShotTiming()//撃つタイミングの初期化
    {
        currentDelayTime = 0;

        for(int i=0;i<bullets.Length ;i++)//撃った判定の初期化
        {
            bullets[i].Shoted = false;
        }
    }

    public override void UpdateShotTiming()//撃つタイミングの更新
    {
        currentDelayTime += Time.deltaTime;

        for (int i=0; i<bullets.Length;i++)
        {
            BulletSettingTypeHoming bullet = bullets[i];

            if (currentDelayTime >= bullet.DelayTime && !bullet.Shoted)
            {
                Shot(bullet);
            }
        }
    }

    void Shot(BulletSettingTypeHoming bullet)
    {
        bullet.Shoted = true;//撃った判定にする

        //攻撃を撃ちだす位置と角度を取得
        Vector3 shotPos = bullet.ShotPos.transform.position;//位置
        Quaternion shotRot = bullet.ShotPos.transform.rotation;//角度

        GameObject homingBulletObject=Instantiate(bullet.BulletPrefab,shotPos,shotRot, gamePos);//弾の生成

        HomingBullet homing = homingBulletObject.GetComponentInChildren<HomingBullet>();//HomingBulletを取得

        if(homing==null)//取得に失敗した場合エラーメッセージを出す
        {
            Debug.Log(name+"HomingBulletがアタッチされた弾をセットしてください");
            return;
        }

        homing.SetBullet(bullet.StartHomingTime, bullet.HomingTime, bullet.HomingSpeed, bullet.Speed);//弾の設定を決定
    }
}
