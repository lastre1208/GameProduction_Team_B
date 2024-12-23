using System.Runtime.CompilerServices;
using UnityEngine;

//作成者：桑原

public partial class WallBullet : MonoBehaviour
{
    EnemyActionTypeShotWall _enemyShotWall;
    WallGenerationParameters generationParams;
    WallShootingParameters shootingParams;
    PreviewTransparencyParameters transparencyParams;

    GameObject[,] walls;//生成した壁のプレハブを管理する配列
    GameObject[,] wallsPreview;//攻撃範囲予告プレハブを管理する配列

    Rigidbody wallAreaRigidbody;//壁の生成範囲プレハブの速度管理用の変数

    Camera mainCamera;

    private float shotPosY;//wallAreaの生成地点オブジェクトのY座標

    private int wallsCount = 0;//壁の枚数管理用の変数

    private float currentDelayTime = 0f;//経過時間の計測（攻撃範囲プレハブの透明度変更用）
    private float currentDelayActiveTime = 0f;//経過時間の計測（壁プレハブの有効化用）
    private float currentDelayShotTime = 0f;//経過時間の計測（壁を打ち出す間隔の計測用）    

    private bool generated = false;//壁が生成されたかどうか
    public bool Generated { get { return generated; } }

    public void SetWallBullet(EnemyActionTypeShotWall enemyShotWall)
    {
        this._enemyShotWall = enemyShotWall;
    }

    void Start()
    {
        generationParams = _enemyShotWall.GenerationParameters;
        shootingParams = _enemyShotWall.ShootingParameters;
        transparencyParams = _enemyShotWall.TransparencyParameters;

        if (_enemyShotWall.WallAreaInstance != null)
        {
            walls = new GameObject[generationParams.Height, generationParams.Width];//壁のプレハブを管理する配列を初期化
            wallsPreview = new GameObject[generationParams.Height, generationParams.Width];//攻撃範囲の予告表示用プレハブを管理する配列を初期化

            mainCamera = Camera.main;

            wallAreaRigidbody = _enemyShotWall.WallAreaInstance.GetComponent<Rigidbody>();

            shotPosY = _enemyShotWall.ShotPosObject.GetComponent<Transform>().transform.localPosition.y;//弾の発射地点のY座標を取得

            PositioningWallArea();//壁の生成範囲の位置を設定

            GenerateWalls();//壁を生成
            PositioningWalls();//生成された壁の位置を調整

            generated = true;
        }
    }

    void Update()
    {
        if (wallActivationStack.Count > 0)
        {
            ActiveWall();//有効な壁を表示

            GenerateWallsPreview();//攻撃範囲予告の生成
            PositioningWallsPreview();//攻撃範囲予告の位置を調整　要修正
        }       

        if (!_enemyShotWall.Shoted)//弾がまだ発射されていないなら
        {
            currentDelayTime += Time.deltaTime;
            float alpha = Mathf.PingPong(currentDelayTime / transparencyParams.TransparencyCycleDuration * 255f, 255f);
            SetPreviewTransparency(alpha / 255f);//攻撃範囲予告の透明度を設定する
        }

        else//弾が発射されたら
        {
            DisableWallsPreview();//攻撃範囲の予告の無効化処理

            if (shootingParams.IsShotAllAtOnce)
                AddForceToWalls();//壁に力を加える

            else
                AddForceToWallsOnebyOne();//壁プレハブを一枚ずつ間隔をあけて力を加える
        }
    }
}