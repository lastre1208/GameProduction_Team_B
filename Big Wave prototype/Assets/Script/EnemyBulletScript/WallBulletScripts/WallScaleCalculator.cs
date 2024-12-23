using UnityEngine;

//作成者：桑原

public partial class WallBullet
{
    private Vector3 CalculateCameraSize()//カメラの描写範囲を計算
    {
        float screenHeight = 2f * mainCamera.orthographicSize;
        float screenWidth = screenHeight * mainCamera.aspect;

        return new Vector3(screenWidth, screenHeight, 0);
    }

    private Vector3 CalculateScaleFactor(Vector3 size_WallArea, Vector3 size_Wall)//壁プレハブのスケールを計算
    {
        return new Vector3(
            size_WallArea.x / (generationParams.Width * size_Wall.x),
            size_WallArea.y / (generationParams.Height * size_Wall.y),
            size_Wall.z);
    }
}
