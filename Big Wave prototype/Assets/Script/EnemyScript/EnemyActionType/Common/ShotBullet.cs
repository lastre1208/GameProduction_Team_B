using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet:MonoBehaviour
{
    [Header("▼弾")]
    [SerializeField] GameObject bulletPrefab;//撃ちだす弾
    [Header("▼撃つ力")]
    [SerializeField] float shotPower;//撃つ力
    [Header("▼弾を撃ちだす位置と角度")]
    [SerializeField] Transform shotPos;//弾を撃ちだす位置
    [Header("▼行動開始から撃つまでの遅延時間")]
    [Header("注:行動時間未満にしないと撃たれずに行動が終わってしまう")]
    [SerializeField] float delayTime;//行動開始から撃つまでの遅延時間、行動時間未満にしないと撃たれずに行動が終わってしまう
    private float currentDelayTime;//現在の遅延時間、これがdelayTimeに達した時弾が撃たれる
    private bool shoted;//弾を撃ったか
    [Header("▼GamePos")]
    [SerializeField] GameObject gamePos;//GamePos、弾をこれの子オブジェクトとして配置する

    public Transform ShotPos
    {
        get { return shotPos; }
    }

    public void InitShotTiming()//撃つタイミングの初期化
    {
        currentDelayTime = 0;
        shoted = false;
    }

    public bool UpdateShotTiming()//撃つタイミングの更新、撃つタイミングになったらtrueを返す
    {
        currentDelayTime += Time.deltaTime;

        if (currentDelayTime >= delayTime && !shoted) return true;//指定の遅延時間に達したかつまだ弾を撃っていない時 

        return false;
    }

    public void Shot(Vector3 shotVec)
    {
        //攻撃を撃ちだす位置と角度を取得
        Vector3 shotPosVec = shotPos.transform.position;//位置
        Quaternion shotRotVec = this.shotPos.transform.rotation;//角度
        //攻撃を配置する
        GameObject bullet = Instantiate(bulletPrefab, shotPosVec, shotRotVec, gamePos.transform);
        //弾のRigidbodyを取得
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        //弾を発射方向に向かせる

        //弾を撃ちだす
        bulletRb.AddForce(shotVec * shotPower, ForceMode.Impulse);

        shoted = true;
    }
}
