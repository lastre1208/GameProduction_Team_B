using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyActionTypeShotWall : EnemyActionTypeBase
{
    [Header("▼壁")]
    [SerializeField] GameObject wallPrefab;//壁のプレハブ
    [Header("壁の生成範囲")]
    [SerializeField] GameObject wallAreaPrefab;//壁を生成する範囲のプレハブ
    [Header("攻撃範囲の予告表示")]
    [SerializeField] GameObject wallPreviewPrefab;//壁の範囲予告用のプレハブ
    [Header("壁の生成範囲の底辺")]
    [SerializeField] GameObject ground;//壁の生成範囲の底辺のプレハブ

    [Header("▼生成する壁の横の分割数")]
    [SerializeField] int width = 4;//生成する壁の横の分割数
    [Header("▼生成する壁の縦の分割数")]
    [SerializeField] int height = 4;//生成する壁の縦の分割数

    [Header("▼それぞれの壁が生成される確率")]
    [SerializeField] float generationProbability = 0.5f;//壁が生成される確率

    [Header("▼攻撃範囲の予告を表示する時間")]
    [SerializeField] float previewDisplayDuration = 5f;//攻撃範囲の予告を表示する時間

    [Header("▼透明度が変化するサイクルの時間")]
    [SerializeField] float transparencyCycleDuration = 0.5f;//透明度が変化するサイクルの時間

    [Header("▼攻撃予告表示のプレイヤーからの距離")]
    [SerializeField] float previewDistanceFromPlayer = 2.0f;//プレイヤーからの距離

    [Header("▼生成範囲をゲーム画面に合わせるかどうか")]
    [SerializeField] bool matchCameraSize = true;//カメラの大きさに合わせるかどうか

    [Header("▼撃つ力")]
    [SerializeField] protected float shotPower = 30f;//撃つ力
    [Header("▼弾を撃ちだす位置")]
    [SerializeField] protected Transform shotPosObject;//弾を撃ちだす位置

    [Header("▼行動開始から撃つまでの遅延時間")]
    [Header("注:行動時間未満にしないと撃たれずに行動が終わってしまう")]
    [SerializeField] float delayTime;//行動開始から撃つまでの遅延時間、行動時間未満にしないと撃たれずに行動が終わってしまう

    [Header("▼壁を生成してから力を加えるまでの時間")]
    [SerializeField] float shotTime = 2.0f;//壁を生成してから力を加えるまでの時間

    [Header("▼GamePos")]
    [SerializeField] protected GameObject gamePos;//GamePos

    GameObject enemy;

    GameObject wallAreaInstance;

    Rigidbody bulletRb;

    private float currentDelayTime;//現在の遅延時間、これがdelayTimeに達した時弾が撃たれる

    private float elapsedTime;//経過時間の計測用

    private bool shoted;

    bool nowCenter;//画面の中央にいるかどうか

    public GameObject WallPrefab
    {
        get { return wallPrefab; }
        set { wallPrefab = value; }
    }

    public GameObject WallAreaPrefab
    {
        get { return wallAreaPrefab; }
        set { wallAreaPrefab = value; }
    }

    public GameObject WallPreviewPrefab
    {
        get { return wallPreviewPrefab; }
        set { wallPreviewPrefab = value; }
    }

    public GameObject Ground
    {
        get { return ground; }
    }

    public int Width
    {
        get { return width; }
    }

    public int Height
    {
        get { return height; }
    }

    public float GenerationProbability
    {
        get { return generationProbability; }
    }

    public float PreviewDisplayDuration
    {
        get { return previewDisplayDuration; }
    }

    public float TransparencyCycleDuration
    {
        get { return transparencyCycleDuration; }
    }

    public float PreviewDistanceFromPlayer
    {
        get { return previewDistanceFromPlayer; }
    }

    public bool MatchCameraSize
    {
        get { return matchCameraSize; }
    }

    public GameObject WallAreaInstance
    {
        get { return wallAreaInstance; }
        set { wallAreaInstance = value; }
    }


    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        enemy = GameObject.FindWithTag("Enemy");

        currentDelayTime = 0;
        elapsedTime = 0f;
        shoted = false;
        nowCenter = false;
    }

    public override void OnUpdate()
    {
        currentDelayTime += Time.deltaTime;

        Camera mainCamera = Camera.main;
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, mainCamera.nearClipPlane);
        Vector3 worldCenter = mainCamera.ScreenToWorldPoint(screenCenter);

        // 敵オブジェクトが壁を生成していないかつ、画面の中央にいるなら
        if (nowCenter)
        {
            enemy.GetComponent<Rigidbody>().isKinematic = true;
            enemy.transform.position = new Vector3(worldCenter.x, enemy.transform.position.y, enemy.transform.position.z);
        }

        if (IsEnemyInCenter(worldCenter.x))
        {
            nowCenter = true;

            if (currentDelayTime >= delayTime && !shoted)//指定の遅延時間に達したかつまだ弾を撃っていない時
            {
                if (wallAreaInstance == null)
                {
                    GenerateWallArea();
                }

                else
                {
                    Shot();
                }
            }
        }
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {
        enemy.GetComponent<Rigidbody>().isKinematic = false;
    }

    bool IsEnemyInCenter(float worldCenterX)
    {
        float threshold = 0.5f;

        return Mathf.Abs(enemy.transform.position.x - worldCenterX) <= threshold;
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

            elapsedTime = 0f;
        }
    }

    void Shot() //弾を撃つ
    {
        /*if (wallAreaInstance == null)
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

            elapsedTime = 0f;
        }*/

        //else
        //{
            elapsedTime += Time.deltaTime;

            if (elapsedTime > shotTime)
            {
                //弾を撃ちだす
                bulletRb.AddForce(-transform.forward * shotPower, ForceMode.Impulse);

                shoted = true;
            }
        //}
    }
}
