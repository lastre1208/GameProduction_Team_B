using UnityEngine;

//作成者：桑原

public partial class WallBullet
{
    void GenerateWalls()//壁の生成
    {
        walls = new GameObject[enemyActionTypeShotWall.Height, enemyActionTypeShotWall.Width];//壁のプレハブを管理する配列を初期化

        for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
        {
            wallsCount = 0;

            for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
            {
                //壁のプレハブを生成し、壁の生成範囲プレハブの子オブジェクトに設定
                GameObject wallInstance = Instantiate(enemyActionTypeShotWall.WallPrefab, enemyActionTypeShotWall.WallAreaInstance.transform);

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

    void GenerateWallsPreview()//攻撃範囲の予告表示の生成
    {
        wallsPreview = new GameObject[enemyActionTypeShotWall.Height, enemyActionTypeShotWall.Width];//攻撃範囲の予告表示用プレハブを管理する配列を初期化

        for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
        {
            for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
            {
                if (walls[i, j].activeSelf)//壁プレハブが有効なら
                {
                    wallsPreview[i, j] = Instantiate(enemyActionTypeShotWall.WallPreviewPrefab, enemyActionTypeShotWall.WallAreaInstance.transform);
                    wallsPreview[i, j].SetActive(true);//攻撃範囲予告プレハブを有効化
                }
            }
        }
    }
}