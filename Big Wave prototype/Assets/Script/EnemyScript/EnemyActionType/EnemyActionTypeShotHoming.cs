using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionTypeShotHoming : EnemyActionTypeBase
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
    [SerializeField] Transform shotPosObject;//弾を撃ちだす位置
    [Header("▼行動開始から撃つまでの遅延時間")]
    [Header("注:行動時間未満にしないと撃たれずに行動が終わってしまう")]
    [SerializeField] float delayTime;//行動開始から撃つまでの遅延時間、行動時間未満にしないと撃たれずに行動が終わってしまう
    private bool shoted;//弾を撃ったか
    private float currentDelayTime;//現在の遅延時間、これがdelayTimeに達した時弾が撃たれる
    [Header("▼GamePos")]
    [SerializeField] GameObject gamePos;//GamePos、弾をこれの子オブジェクトとして配置する
    [Header("行動時のエフェクト")]
    [SerializeField] ActionEffect actionEffect;


    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        currentDelayTime = 0;
        shoted = false;
        actionEffect.Generate();//エフェクト生成
    }

    public override void OnUpdate()
    {
        currentDelayTime += Time.deltaTime;

        if (currentDelayTime >= delayTime && !shoted)//指定の遅延時間に達したかつまだ弾を撃っていない時
        {
            Shot();
        }
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {
        
    }

    void Shot()
    {
        //攻撃を撃ちだす位置と角度を取得
        Vector3 shotPos = shotPosObject.transform.position;//位置
        Quaternion shotRot = shotPosObject.transform.rotation;//角度
        //攻撃を配置する
        HomingBullet bullet = Instantiate(bulletPrefab, shotPos, shotRot, gamePos.transform);
        //配置したホーミング弾の設定
        bullet.SetHomingBullet(startHomingTime, homingTime, homingSpeed,speed);
        shoted = true;
    }
}
