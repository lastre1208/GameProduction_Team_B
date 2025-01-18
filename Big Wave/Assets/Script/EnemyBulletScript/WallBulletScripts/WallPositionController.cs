using UnityEngine;

//作成者：桑原

public partial class WallBullet
{
    private void PositioningWallArea()//壁の生成範囲プレハブの位置の設定
    {
        if (generationParams.MatchCameraSize)//カメラの描写範囲に合わせる場合
        {
            Vector3 screenSize = CalculateCameraSize();//カメラの描写範囲の計算

            //壁の生成範囲プレハブのスケール設定
            _enemyShotWall.WallAreaInstance.transform.localScale = new Vector3(
                screenSize.x, screenSize.y, _enemyShotWall.WallAreaInstance.transform.localScale.z);
        }

        AlignWallAreaToBulletSpawn();//壁の生成範囲プレハブの底辺を、wallAreaの生成地点オブジェクトの高さに合わせる
    }

    private void PositioningWalls()//壁プレハブの位置を調整
    {
        Vector3 size_WallArea = _enemyShotWall.WallAreaInstance.GetComponent<MeshFilter>().sharedMesh.bounds.size;//壁の生成範囲プレハブの大きさを取得
        Vector3 size_Wall = walls[0, 0].GetComponentInChildren<MeshFilter>().sharedMesh.bounds.size;

        Vector3 scaleFactor = CalculateScaleFactor(size_WallArea, size_Wall);//壁プレハブのスケールを計算
        PositionAndScaleWalls(scaleFactor);//壁プレハブのスケールと位置を設定
    }

    private void PositioningWallsPreview()//攻撃範囲の予告プレハブの位置を調整
    {
        //SpawnPosOfWallPreviewのワールド座標を取得
        Vector3 spawnPosWorld = _enemyShotWall.SpawnPosOfWallPreview.transform.position;

        //wallAreaInstanceのローカル座標系に変換
        Vector3 spawnPosLocal = _enemyShotWall.WallAreaInstance.transform.InverseTransformPoint(spawnPosWorld);

        for (int i = 0; i < generationParams.Height; i++)
        {
            for (int j = 0; j < generationParams.Width; j++)
            {
                if (wallsPreview[i, j] != null && wallsPreview[i, j].activeSelf)//攻撃範囲の予告プレハブが存在するなら
                {
                    wallsPreview[i, j].transform.localScale = walls[i, j].transform.localScale;

                    Vector3 wallsPreviewPos = walls[i, j].transform.localPosition;

                    //攻撃範囲の予告プレハブの位置を設定
                    wallsPreview[i, j].transform.localPosition = new Vector3(
                        wallsPreviewPos.x, wallsPreviewPos.y, spawnPosLocal.z);
                }
            }
        }
    }

    private void AlignWallAreaToBulletSpawn()//壁の生成範囲の底辺を、wallAreaの生成地点オブジェクトの高さに合わせる
    {
        float wallAreaHeight = _enemyShotWall.WallAreaInstance.GetComponent<Renderer>().bounds.size.y;
        Vector3 wallAreaPos = _enemyShotWall.WallAreaInstance.transform.position;
        wallAreaPos.y = shotPosY + wallAreaHeight / 2;
        _enemyShotWall.WallAreaInstance.transform.position = wallAreaPos;
    }

    private void PositionAndScaleWalls(Vector3 scaleFactor)//壁プレハブのスケールと位置を設定
    {
        for (int i = 0; i < generationParams.Height; i++)
        {
            for (int j = 0; j < generationParams.Width; j++)
            {
                if (walls[i, j] != null)
                {
                    //壁プレハブのスケールをもとに、位置を調整
                    walls[i, j].transform.localScale = scaleFactor;
                    walls[i, j].transform.localPosition = new Vector3(
                        (j - (generationParams.Width / 2f) + 0.5f) * scaleFactor.x,
                        (i - (generationParams.Height / 2f) + 0.5f) * scaleFactor.y,
                        0);
                }
            }
        }
    }
}