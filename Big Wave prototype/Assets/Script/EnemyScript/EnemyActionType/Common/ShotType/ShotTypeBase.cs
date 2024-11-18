using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ShotTypeBase : MonoBehaviour
{
    [Header("▼GamePos")]
    [SerializeField] GameObject gamePos;//GamePos、弾をこれの子オブジェクトとして配置する
    protected float currentDelayTime;//現在の遅延時間、これがdelayTimeに達した時弾が撃たれる

    public virtual void InitShotTiming()//撃つタイミングの初期化
    {
        currentDelayTime = 0;
    }

    public virtual void UpdateShotTiming()//撃つタイミングの更新
    {
        currentDelayTime += Time.deltaTime;
    }

    protected void ResetShoted(BulletSettingTypeBase[] bulletSetting)//全ての弾の設定のshoted(撃った判定)をリセットする(まだ撃ってない状態に戻す)
    {
        for(int i=0;i<bulletSetting.Length ;i++)
        {
            bulletSetting[i].Shoted = false;
        }
    }

    protected bool NotifyShotTiming(BulletSettingTypeBase bulletSetting)//撃つタイミングを知らせる
    {
        if (currentDelayTime >= bulletSetting.DelayTime && !bulletSetting.Shoted) return true;
        return false;
    }

    protected GameObject GenerateBullet(BulletSettingTypeBase bulletSetting)//弾発射前に弾を生成する処理の一連
    {
        bulletSetting.Shoted = true;
        //攻撃を撃ちだす位置と角度を取得
        Vector3 shotPosVec = bulletSetting.ShotPos.transform.position;//位置
        Quaternion shotRotVec = bulletSetting.ShotPos.transform.rotation;//角度
        GameObject bulletObject= Instantiate(bulletSetting.BulletPrefab, shotPosVec, shotRotVec, gamePos.transform);
        return bulletObject;
    }
 
}
