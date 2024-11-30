using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyActionTypeShotWall : EnemyActionTypeBase
{
    [SerializeField] AnimatorController_Enemy animController;
    [SerializeField] string animName;

    [Header("▼壁")]
    [SerializeField] GameObject wallPrefab;//壁のプレハブ
    [Header("▼壁の生成範囲")]
    [SerializeField] GameObject wallAreaPrefab;//壁を生成する範囲のプレハブ
    [Header("▼攻撃範囲の予告表示")]
    [SerializeField] GameObject wallPreviewPrefab;//壁の範囲予告用のプレハブ

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

    public GameObject WallAreaInstance
    {
        get { return wallAreaInstance; }
        set { wallAreaInstance = value; }
    }

    public Transform SpawnPosOfWallPreview { get { return spawnPosOfWallPreview; } }
    public Transform ShotPosObject { get { return shotPosObject; } }
    public GameObject GamePos { get { return gamePos; } }

    public int Width { get { return width; } }
    public int Height { get { return height; } }
    public float GenerationProbability { get { return generationProbability; } }
    public float TransparencyCycleDuration { get { return transparencyCycleDuration; } }
    public bool MatchCameraSize { get { return matchCameraSize; } }
    public bool Shoted { get { return shoted; } }
}