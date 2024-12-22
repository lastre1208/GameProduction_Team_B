using UnityEngine;

//作成者：桑原

public partial class EnemyActionTypeShotWall : EnemyActionTypeBase
{
    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        Debug.Log("Wall");

        currentDelayTime = 0;

        _animTrigger.Start();//モーションの再生処理の初期化

        _generateEffect.OnEnter();

        if(_wallCamera!=null) _wallCamera.enabled = true;//壁攻撃のカメラを起動
    }

    public override void OnUpdate()
    {
        if (!shoted)
        {
            if (wallAreaInstance == null)
                GenerateWallArea();

            else
                Shot();
        }

        _generateEffect.OnUpdate();

        _animTrigger.Update();//モーションの再生処理の更新
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {
        shoted = false;

        if (_wallCamera != null) _wallCamera.enabled = false;//壁攻撃のカメラを終了
    }

    void GenerateWallArea()
    {
        if (wallAreaInstance == null)
        {
            //攻撃を撃ちだす位置を取得
            Vector3 shotPos = shotPosObject.transform.position;
            Quaternion shotRot = shotPosObject.transform.rotation;

            wallAreaInstance = Instantiate(wallAreaPrefab, shotPos, shotRot, gamePos.transform);

            WallBullet wallBulletScript = wallAreaInstance.AddComponent<WallBullet>();

            //ToggleColliderOfWallBulletにwallBulletの参照を設定
            wallBulletScript.SetWallBullet(this);

            //弾のRigidbodyを取得
            bulletRb = wallAreaInstance.GetComponent<Rigidbody>();
        }
    }

    void Shot() //弾を撃つ
    {
        currentDelayTime += Time.deltaTime;

        if (currentDelayTime > _shootingParameters.DelayTime)
        {
            //弾を撃ちだす
            bulletRb.AddForce(-transform.forward * _shootingParameters.ShotPower, ForceMode.Impulse);

            shoted = true;
        }
    }
}
