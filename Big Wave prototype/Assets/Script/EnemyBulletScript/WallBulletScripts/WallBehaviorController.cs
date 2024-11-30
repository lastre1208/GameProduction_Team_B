using UnityEngine;

//作成者：桑原

public partial class WallBullet
{
    void DisableWallsPreview()//攻撃範囲の予告の無効化処理
    {
        for (int i = 0; i < enemyActionTypeShotWall.Height; i++)
        {
            for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
            {
                if (wallsPreview[i, j] != null)
                {
                    wallsPreview[i, j].SetActive(false);//攻撃範囲の予告プレハブを無効化
                }
            }
        }
    }

    void SetPreviewTransparency(float alpha)//攻撃範囲の予告の透明度を設定
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
                for (int j = 0; j < enemyActionTypeShotWall.Width; j++)
                {
                    if (walls[i, j] != null)
                    {
                        //壁のRigidbodyを取得
                        Rigidbody wallRigidbody = walls[i, j].GetComponentInChildren<Rigidbody>();

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
                        Collider wallCollider = walls[i, j].GetComponentInChildren<Collider>();

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