using UnityEngine;

//作成者：桑原

public partial class WallBullet : MonoBehaviour
{
    GameObject[,] walls;//生成した壁のプレハブを管理する配列

    GameObject[,] wallsPreview;//攻撃範囲予告プレハブを管理する配列

    Rigidbody wallAreaRigidbody;//壁の生成範囲プレハブの速度管理用の変数

    Camera mainCamera;

    EnemyActionTypeShotWall enemyActionTypeShotWall;

    private float currentDelayTime;//経過時間の計測用

    private float shotPosY;//wallAreaの生成地点オブジェクトのY座標

    private bool generated = false;//壁が生成されたかどうか

    private int wallsCount;//壁の枚数管理用の変数

    public bool Generated
    {
        get { return generated; }
        private set { generated = value; }
    }

    public void SetWallBullet(EnemyActionTypeShotWall enemyActionTypeShotWall)
    {
        this.enemyActionTypeShotWall = enemyActionTypeShotWall;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (enemyActionTypeShotWall.WallAreaInstance != null)
        {
            wallAreaRigidbody = enemyActionTypeShotWall.WallAreaInstance.GetComponent<Rigidbody>();

            shotPosY = enemyActionTypeShotWall.ShotPosObject.GetComponent<Transform>().transform.localPosition.y;//弾の発射地点のY座標を取得

            mainCamera = Camera.main;

            PositioningWallArea();//壁の生成範囲の位置を設定

            GenerateWalls();//壁を生成
            PositioningWalls();//壁の位置を調整

            GenerateWallsPreview();//攻撃範囲予告の生成
            PositioningWallsPreview();//攻撃範囲予告の位置を調整

            generated = true;

            currentDelayTime = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentDelayTime += Time.deltaTime;

        if (!enemyActionTypeShotWall.Shoted)//弾がまだ発射されていないなら
        {
            float alpha = Mathf.PingPong(currentDelayTime / enemyActionTypeShotWall.TransparencyCycleDuration * 255f, 255f);
            SetPreviewTransparency(alpha / 255f);//攻撃範囲予告の透明度を設定する
        }

        else//一定時間経過が経過したら
        {
            DisableWallsPreview();//攻撃範囲の予告の無効化処理
            AddForceToWalls();//壁に力を加える
        }
    }
}