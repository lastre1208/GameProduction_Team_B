using UnityEngine;
using System.Collections.Generic;

//生成確立の高精度化

//作成者：桑原

public partial class WallBullet
{
    private Stack<GameObject> wallActivationStack;
    private Stack<GameObject> wallShotStack;

    private float adjustProbability;

    void GenerateWalls()//壁の生成
    {
        wallActivationStack = new Stack<GameObject>();
        wallShotStack = new Stack<GameObject>();

        int maxStackCount = generationParams.GenerateWallsNum;//最大スタック数

        for (int i = 0; i < generationParams.Height; i++)
        {
            wallsCount = 0;

            for (int j = 0; j < generationParams.Width; j++)
            {
                if (walls[i, j] != null) return;

                //壁のプレハブを生成し、壁の生成範囲プレハブの子オブジェクトに設定
                GameObject wallInstance = Instantiate(_enemyShotWall.WallPrefab, _enemyShotWall.WallAreaInstance.transform);

                if (wallInstance != null)
                {
                    walls[i, j] = wallInstance;//生成された壁のプレハブを配列に格納
                    walls[i, j].SetActive(false);

                    adjustProbability = Mathf.Clamp(
                        generationParams.GenerationProbability * (1f - (wallActivationStack.Count / (float)maxStackCount)),
                        0.1f,
                        generationParams.GenerationProbability
                        );

                    if (wallActivationStack.Count < maxStackCount && Random.value < adjustProbability /*&& wallsCount < generationParams.Width - 1*/)
                    {
                        wallActivationStack.Push(walls[i, j]);
                        wallShotStack.Push(walls[i, j]);
                        wallsCount++;
                    }
                }
            }
        }
    }

    void ActiveWall()
    {
        currentDelayActiveTime += Time.deltaTime;

        if (currentDelayActiveTime > generationParams.IntervalActiveTime)
        {
            GameObject wallToActive = wallActivationStack.Pop();

            if (wallToActive != null)
                wallToActive.SetActive(true);

            currentDelayActiveTime = 0f;
        }
    }

    void GenerateWallsPreview()//攻撃範囲の予告表示の生成
    {
        for (int i = 0; i < generationParams.Height; i++)
        {
            for (int j = 0; j < generationParams.Width; j++)
            {
                if (wallsPreview[i, j] != null) return;

                if (walls[i, j] != null && walls[i, j].activeSelf)
                    wallsPreview[i, j] = Instantiate(_enemyShotWall.WallPreviewPrefab, _enemyShotWall.WallAreaInstance.transform);
            }
        }
    }
}