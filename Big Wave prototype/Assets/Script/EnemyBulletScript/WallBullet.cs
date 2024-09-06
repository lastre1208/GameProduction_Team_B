using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//配列ごとに生成する確率を設定できるようにする

public class WallBullet : MonoBehaviour
{
    GameObject[,] walls;//生成した壁のプレハブを管理する配列

    GameObject[,] wallsPreview;//攻撃範囲予告プレハブを管理する配列

    Rigidbody wallAreaRigidbody;//壁の生成範囲プレハブの速度管理用の変数

    Camera mainCamera;

    GameObject player;

    EnemyActionTypeShotWall enemyActionTypeShotWall;

    private float elapsedTime;//経過時間の計測用

    private float groundY;//地面のY座標

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
            groundY = enemyActionTypeShotWall.Ground.GetComponent<Renderer>().bounds.min.y;//地面の最低Y座標を取得

            player = GameObject.FindWithTag("Player");

            mainCamera = Camera.main;

            PositioningWallArea();//壁の生成範囲の位置を設定

            GenerateWalls();//壁を生成
            PositioningWalls();//壁の位置を調整

            GenerateWallsPreview();//攻撃範囲予告の生成
            PositioningWallsPreview();//攻撃範囲予告の位置を調整

            generated = true;

            elapsedTime = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime < enemyActionTypeShotWall.PreviewDisplayDuration)
        {
            float alpha = Mathf.PingPong(elapsedTime / enemyActionTypeShotWall.TransparencyCycleDuration * 255f, 255f);
            SetPreviewTransparency(alpha / 255f);//攻撃範囲予告の透明度を設定する
        }

        else//一定時間経過が経過したら
        {
            DisableWallPreview();//攻撃範囲の予告の無効化処理
        }

        AddForceToWalls();//壁に力を加える
    }

    void PositioningWallArea()//壁の生成範囲プレハブの位置の設定
    {
        if (enemyActionTypeShotWall.MatchCameraSize)//カメラの描写範囲に合わせる場合
        {
            float screenHeight = 2f * mainCamera.orthographicSize;//カメラの描写範囲の高さを計算
            float screenWidth = screenHeight * mainCamera.aspect;//カメラの描写範囲の横幅を計算

            //壁の生成範囲プレハブのスケール設定
            enemyActionTypeShotWall.WallAreaInstance.transform.localScale = new Vector3(
                screenWidth,
                screenHeight,
                enemyActionTypeShotWall.WallAreaInstance.transform.localScale.z
                );
        }

        float wallAreaHeight = enemyActionTypeShotWall.WallAreaInstance.GetComponent<Renderer>().bounds.size.y;//壁の生成範囲プレハブの高さを取得

        Vector3 wallAreaPosition = enemyActionTypeShotWall.WallAreaInstance.transform.position;//壁の生成範囲プレハブの現在位置を取得

        wallAreaPosition.y = groundY + wallAreaHeight / 2;//壁の生成範囲プレハブのY座標を地面の高さに合わせる        

        enemyActionTypeShotWall.WallAreaInstance.transform.position = wallAreaPosition;//壁の生成範囲プレハブの位置を設定
    }

    void GenerateWalls()
    {
        walls = new GameObject[enemyActionTypeShotWall.Height, enemyActionTypeShotWall.Width];//壁のプレハブを管理する配列を初期化

        for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
        {
            wallsCount = 0;

            for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
            {
                //壁のプレハブを生成し、壁の生成範囲プレハブの子オブジェクトに設定
                GameObject wallInstance = Instantiate(enemyActionTypeShotWall.WallPrefab, this.transform);

                if (wallInstance != null)
                {
                    walls[i, j] = wallInstance;//生成された壁のプレハブを配列に格納

                    if (Random.value < enemyActionTypeShotWall.GenerationProbability && wallsCount < enemyActionTypeShotWall.Width - 1)
                    {
                        walls[i, j].SetActive(true);//壁のプレハブを有効化

                        //ToggleColliderOfWallBulletスクリプトを有効化した壁のプレハブに追加
                        ToggleColliderOfWallBullet toggleColliderScript = wallInstance.AddComponent<ToggleColliderOfWallBullet>();

                        //ToggleColliderOfWallBulletにwallBulletの参照を設定
                        toggleColliderScript.SetWallBullet(this);

                        wallsCount++;
                    }

                    else
                    {
                        walls[i, j].SetActive(false);//壁のプレハブを無効化
                    }
                }
            }
        }
    }

    void PositioningWalls()
    {
        Vector3 size_WallArea = enemyActionTypeShotWall.WallAreaInstance.GetComponent<Renderer>().bounds.size;//壁の生成範囲プレハブの大きさを取得
        Vector3 size_Wall = walls[0, 0].GetComponent<Renderer>().bounds.size;//生成された壁プレハブの大きさを取得        

        Vector3 wallAreaPosition = enemyActionTypeShotWall.WallAreaInstance.transform.position;//壁の生成範囲プレハブの位置を取得
        Vector3 wallAreaMin = enemyActionTypeShotWall.WallAreaInstance.GetComponent<Renderer>().bounds.min;//壁の生成範囲プレハブの最小座標を取得

        //壁プレハブのスケール計算
        Vector3 scaleFactor = new Vector3(
             size_WallArea.x / (enemyActionTypeShotWall.Width * size_Wall.x),//X軸の大きさ調整用
             size_WallArea.y / (enemyActionTypeShotWall.Height * size_Wall.y),//Y軸の大きさ調節用
             size_WallArea.z / size_Wall.z);//Z軸の大きさ調節用


        for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
        {
            for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
            {
                walls[i, j].transform.localScale = scaleFactor;//それぞれの壁プレハブの大きさを設定

                //壁プレハブを配置する位置の計算
                Vector3 pos_Wall = new Vector3(
                    wallAreaMin.x + size_Wall.x * scaleFactor.x * j + size_Wall.x * scaleFactor.x / 2,//X座標の計算
                    groundY + size_Wall.y * scaleFactor.y / 2 + i * size_Wall.y * scaleFactor.y,//Y座標の計算
                    wallAreaPosition.z);//Z座標の設定

                walls[i, j].transform.position = pos_Wall;//それぞれの壁プレハブの位置を設定                
            }
        }
    }

    void GenerateWallsPreview()//攻撃範囲の予告表示の生成
    {
        wallsPreview = new GameObject[enemyActionTypeShotWall.Height, enemyActionTypeShotWall.Width];//攻撃範囲の予告表示用プレハブを管理する配列を初期化

        for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
        {
            for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
            {
                if (walls[i, j].activeSelf)//壁プレハブが有効なら
                {
                    //攻撃範囲の予告プレハブを生成し、壁プレハブの位置とスケールを取得して設定
                    wallsPreview[i, j] = Instantiate(enemyActionTypeShotWall.WallPreviewPrefab, walls[i, j].transform.position, walls[i, j].transform.rotation, this.transform);
                    wallsPreview[i, j].transform.localScale = walls[i, j].transform.localScale;
                    wallsPreview[i, j].SetActive(true);//攻撃範囲予告プレハブを有効化
                }
            }
        }
    }

    void PositioningWallsPreview()//攻撃範囲の予告プレハブの位置を調整
    {
        //プレイヤーからの距離を考慮した位置を計算
        Vector3 previewBasePosition = player.transform.position + player.transform.forward * enemyActionTypeShotWall.PreviewDistanceFromPlayer;

        for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
        {
            for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
            {
                if (wallsPreview[i, j] != null)//攻撃範囲の予告プレハブが存在するなら
                {
                    Vector3 wallsPosition = walls[i, j].transform.position;//壁プレハブの位置を取得

                    //攻撃範囲の予告プレハブの位置を設定、Z座標をプレイヤーオブジェクトの前面に合わせる
                    wallsPreview[i, j].transform.position = new Vector3(
                        wallsPosition.x, wallsPosition.y, previewBasePosition.z
                        );
                }
            }
        }
    }

    void DisableWallPreview()//攻撃範囲の予告の無効化処理
    {
        for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
        {
            for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
            {
                if (wallsPreview[i, j] != null)
                {
                    wallsPreview[i, j].SetActive(false);  // 攻撃範囲の予告プレハブを無効化
                }
            }
        }
    }

    void SetPreviewTransparency(float alpha)//攻撃範囲の予告プレハブの透明度を設定
    {
        for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
        {
            for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
            {
                if (wallsPreview[i, j] != null)//攻撃範囲の予告プレハブが存在するなら
                {
                    //攻撃範囲の予告プレハブのRendererを取得
                    Renderer renderer = wallsPreview[i, j].GetComponent<Renderer>();

                    if (renderer != null)//Rendererが存在するなら
                    {
                        Color color = renderer.material.color;//現在の色を取得
                        color.a = alpha;//透明度を設定
                        renderer.material.color = color;//色を更新
                    }
                }
            }
        }
    }

    void AddForceToWalls()//壁プレハブに力を加える
    {
        if (wallAreaRigidbody != null)
        {
            Vector3 velocity = wallAreaRigidbody.velocity;//壁の生成範囲プレハブの速度を取得

            for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
            {
                for (int j = 0; j < enemyActionTypeShotWall.Height; j++)
                {
                    if (walls[i, j] != null)
                    {
                        //壁のRigidbodyを取得
                        Rigidbody wallRigidbody = walls[i, j].GetComponent<Rigidbody>();

                        if (wallRigidbody != null)
                        {
                            wallRigidbody.velocity = velocity;//それぞれの壁プレハブに速度を設定
                        }
                    }
                }
            }
        }
    }

    public void ToggleCollider()//壁のコライダーを無効化する
    {
        if (walls != null)
        {
            for (int i = 0; i < walls.GetLength(0); i++)
            {
                for (int j = 0; j < walls.GetLength(1); j++)
                {
                    if (walls[i, j] != null)
                    {
                        //壁プレハブのコライダーを取得
                        Collider wallCollider = walls[i, j].GetComponent<Collider>();

                        if (wallCollider != null)
                        {
                            wallCollider.enabled = false;//壁プレハブのコライダーを無効化
                        }
                    }
                }
            }
        }
    }
}
