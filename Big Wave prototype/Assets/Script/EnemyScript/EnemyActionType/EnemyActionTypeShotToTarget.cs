using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//敵の弾(攻撃)の標的(プレイヤー)に向かっての直線撃ち
public class EnemyActionTypeShotToTarget : EnemyActionTypeBase
{
    [SerializeField] AnimatorController_Enemy animController;
    [SerializeField] string animName;

    [Header("▼弾")]
    [SerializeField] GameObject bulletPrefab;//撃ちだす弾
    [Header("▼撃つ力")]
    [SerializeField] float shotPower;//撃つ力
    [Header("▼弾を撃ちだす位置")]
    [SerializeField] Transform shotPosObject;//弾を撃ちだす位置
    [Header("▼行動開始から撃つまでの遅延時間")]
    [Header("注:行動時間未満にしないと撃たれずに行動が終わってしまう")]
    [SerializeField] float delayTime;//行動開始から撃つまでの遅延時間、行動時間未満にしないと撃たれずに行動が終わってしまう
    private float currentDelayTime;//現在の遅延時間、これがdelayTimeに達した時弾が撃たれる
    private bool shoted;//弾を撃ったか
    [Header("▼GamePos")]
    [SerializeField] GameObject gamePos;//GamePos
    [Header("プレイヤー")]
    [SerializeField] GameObject player;//プレイヤー
    [Header("行動時のエフェクト")]
    [SerializeField] ActionEffect actionEffect;

    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        currentDelayTime = 0;
        shoted = false;
        actionEffect.Generate();//エフェクト生成
        animController.AnimControl_Trigger(animName);
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
        //攻撃を撃ちだす位置を取得
        Vector3 shotPos = shotPosObject.transform.position;
        Quaternion shotRot = shotPosObject.transform.rotation;//角度
        //攻撃を配置する
        GameObject bullet = Instantiate(bulletPrefab, shotPos, shotRot, gamePos.transform);
        //弾のRigidbodyを取得
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        //撃つ場所からプレイヤー方向のベクトルを算出&大きさを1に
        Vector3 toPlayer = (player.transform.position - shotPos).normalized;
        //攻撃の向きをプレイヤーのいる方向に変更
        bullet.transform.rotation = Quaternion.LookRotation(toPlayer, Vector3.up);
        //弾を撃ちだす
        bulletRb.AddForce(toPlayer * shotPower, ForceMode.Impulse);

        shoted= true;
    }
}
