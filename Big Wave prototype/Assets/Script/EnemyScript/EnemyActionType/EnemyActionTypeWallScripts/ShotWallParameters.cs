using Cinemachine;
using UnityEngine;

public partial class EnemyActionTypeShotWall : EnemyActionTypeBase
{
    [Header("アニメーションの設定")]
    [SerializeField] DelayAnimationTypeTrigger _animTrigger;

    [Header("壁攻撃時のカメラ")]
    [SerializeField] CinemachineVirtualCamera _wallCamera;

    [Header("行動時のエフェクト")]
    [SerializeField] GenerateEffect_Action _generateEffect;

    [Header("▼各パラメータ")]
    [Header("壁の生成に関するパラメータ")]
    [SerializeField] WallGenerationParameters _generationParameters;
    [Header("壁の発射に関するパラメータ")]
    [SerializeField] WallShootingParameters _shootingParameters;
    [Header("攻撃予告の透明度操作に関するパラメータ")]
    [SerializeField] PreviewTransparencyParameters _previewTransparencyParameters;

    [Header("発射する壁")]
    [SerializeField] GameObject wallPrefab;
    [Header("壁の生成範囲")]
    [SerializeField] GameObject wallAreaPrefab;
    [Header("攻撃範囲の予告表示")]
    [SerializeField] GameObject wallPreviewPrefab;
    [Header("攻撃予告表示を生成する位置")]
    [SerializeField] protected Transform spawnPosOfWallPreview;
    [Header("弾を撃ちだす位置")]
    [SerializeField] protected Transform shotPosObject;
    [Header("GamePos")]
    [SerializeField] protected GameObject gamePos;

    GameObject wallAreaInstance;
    Rigidbody bulletRb;

    private float currentDelayTime;//現在の遅延時間、これがdelayTimeに達した時弾が撃たれる
    bool shoted;//弾を撃ったか

    public GameObject WallPrefab { get { return wallPrefab; } }
    public GameObject WallAreaPrefab { get { return wallAreaPrefab; } }
    public GameObject WallPreviewPrefab { get { return wallPreviewPrefab; } }
    public GameObject WallAreaInstance { get { return wallAreaInstance; } }
    public Transform SpawnPosOfWallPreview { get { return spawnPosOfWallPreview; } }
    public Transform ShotPosObject { get { return shotPosObject; } }
    public WallGenerationParameters GenerationParameters { get { return _generationParameters; } }
    public WallShootingParameters ShootingParameters { get { return _shootingParameters; } }
    public PreviewTransparencyParameters TransparencyParameters { get { return _previewTransparencyParameters; } }

    public bool Shoted { get { return shoted; } }
}