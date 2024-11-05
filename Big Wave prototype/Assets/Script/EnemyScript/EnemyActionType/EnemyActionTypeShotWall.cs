using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//作成者：桑原

public class EnemyActionTypeShotWall : EnemyActionTypeBase
{
    [SerializeField] AnimatorController_Enemy animController;
    [SerializeField] string animName;

    [Header("▼壁")]
    [SerializeField] GameObject wallPrefab;//壁のプレハブ
    [Header("▼壁の生成範囲")]
    [SerializeField] GameObject wallAreaPrefab;//壁を生成する範囲のプレハブ
    [Header("▼攻撃範囲の予告表示")]
    [SerializeField] GameObject wallPreviewPrefab;//壁の範囲予告用のプレハブ
    [Header("▼壁の生成範囲の底辺")]
    [SerializeField] GameObject ground;//壁の生成範囲の底辺のプレハブ

    [Header("▼生成する壁の横の分割数")]
    [SerializeField] int width = 4;//生成する壁の横の分割数
    [Header("▼生成する壁の縦の分割数")]
    [SerializeField] int height = 4;//生成する壁の縦の分割数

    [Header("▼それぞれの壁が生成される確率")]
    [SerializeField] float generationProbability = 0.5f;//壁が生成される確率

    [Header("▼透明度が変化するサイクルの時間")]
    [SerializeField] float transparencyCycleDuration = 0.5f;//透明度が変化するサイクルの時間

    [Header("▼攻撃予告表示を生成する位置")]
    [SerializeField] protected Transform spawnPosOfWallPreview;//攻撃予告表示を生成する位置

    [Header("▼生成範囲をゲーム画面に合わせるかどうか")]
    [SerializeField] bool matchCameraSize = true;//カメラの大きさに合わせるかどうか

    [Header("▼撃つ力")]
    [SerializeField] protected float shotPower = 30f;//撃つ力
    [Header("▼弾を撃ちだす位置")]
    [SerializeField] protected Transform shotPosObject;//弾を撃ちだす位置

    [Header("▼壁を生成してから撃つまでの遅延時間")]
    [Header("注:行動時間未満にしないと撃たれずに行動が終わってしまう")]
    [SerializeField] float delayTime = 2.0f;//行動開始から撃つまでの遅延時間、行動時間未満にしないと撃たれずに行動が終わってしまう

    [Header("▼GamePos")]
    [SerializeField] protected GameObject gamePos;//GamePos

    [Header("行動時のエフェクト")]
    [SerializeField] ActionEffect actionEffect;

    GameObject wallAreaInstance;

    Rigidbody bulletRb;

    private float currentDelayTime;//現在の遅延時間、これがdelayTimeに達した時弾が撃たれる

    bool shoted;//弾を撃ったか

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

    /*public float PreviewDisplayDuration
    {
        get { return previewDisplayDuration; }
    }*/

    public float TransparencyCycleDuration
    {
        get { return transparencyCycleDuration; }
    }

    public bool MatchCameraSize
    {
        get { return matchCameraSize; }
    }

    public bool Shoted
    {
        get { return shoted; }
    }


    public GameObject WallAreaInstance
    {
        get { return wallAreaInstance; }
        set { wallAreaInstance = value; }
    }

    public Transform SpawnPosOfWallPreview
    {
        get { return spawnPosOfWallPreview; }
    }

    public Transform ShotPosObject
    {
        get { return shotPosObject; }
    }

    public GameObject GamePos
    {
        get { return gamePos; }
    }

    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        Debug.Log("Wall");

        currentDelayTime = 0;

        actionEffect.Generate();//エフェクト生成

        animController.AnimControl_Trigger(animName);
    }

    public override void OnUpdate()
    {
        if (!shoted)
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

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {
        shoted = false;
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

        if (currentDelayTime > delayTime)
        {
            //弾を撃ちだす
            bulletRb.AddForce(-transform.forward * shotPower, ForceMode.Impulse);

            shoted = true;
        }
    }
}
