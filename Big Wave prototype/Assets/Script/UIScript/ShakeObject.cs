using System;
using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    // 単一のパーリンノイズ情報を格納する構造体
    [Serializable]
    private struct NoiseParam
    {
        // 振幅
        public float amplitude;

        // 振動の速さ
        public float speed;

        // パーリンノイズのオフセット
        [NonSerialized] public float offset;

        // 乱数のオフセット値を指定する
        public void SetRandomOffset()
        {
            offset = UnityEngine.Random.Range(0f, 256f);
        }

        // 指定時刻のパーリンノイズ値を取得する
        public float GetValue(float time)
        {
            // ノイズ位置を計算
            var noisePos = speed * time + offset;

            // -1～1の範囲のノイズ値を取得
            var noiseValue = 2 * (Mathf.PerlinNoise(noisePos, 0) - 0.5f);

            // 振幅を掛けた値を返す
            return amplitude * noiseValue;
        }
    }

    // パーリンノイズのXYZ情報
    [Serializable]
    private struct NoiseTransform
    {
        public NoiseParam x, y, z;

        // xyz成分に乱数のオフセット値を指定する
        public void SetRandomOffset()
        {
            x.SetRandomOffset();
            y.SetRandomOffset();
            z.SetRandomOffset();
        }

        // 指定時刻のパーリンノイズ値を取得する
        public Vector3 GetValue(float time)
        {
            return new Vector3(
                x.GetValue(time),
                y.GetValue(time),
                z.GetValue(time)
            );
        }
    }

    // 位置の揺れ情報
    [SerializeField] private NoiseTransform _noisePosition;

    // 回転の揺れ情報
    [SerializeField] private NoiseTransform _noiseRotation;

    private Transform _transform;

    // Transformの初期状態
    private Vector3 _initLocalPosition;
    private Quaternion _initLocalQuaternion;

    private bool ShakeNow=false;
    public float Shaketime;
    private float Counttime;
    // 初期化
    private void Awake()
    {
        _transform = transform;

        // Transformの初期値を保持
        _initLocalPosition = _transform.localPosition;
        _initLocalQuaternion = _transform.localRotation;

        // パーリンノイズのオフセット初期化
        _noisePosition.SetRandomOffset();
        _noiseRotation.SetRandomOffset();
    }

    // 振動処理
    private void Update()
    {
        if (ShakeNow)
        {
            // ゲーム開始からの時間取得
            var time = Time.time;

            // パーリンノイズの値を時刻から取得
            var noisePos = _noisePosition.GetValue(time);
            var noiseRot = _noiseRotation.GetValue(time);

            // 各Transformにパーリンノイズの値を加算
            _transform.localPosition = _initLocalPosition + noisePos;
            _transform.localRotation = Quaternion.Euler(noiseRot) * _initLocalQuaternion;
            Counttime += Time.deltaTime;
            if (Counttime > Shaketime)
            {
                DisableShake(); 
            }
        }
    }
    public void EnableShake()
    {
        ShakeNow = true;
    }
    public void DisableShake() {
        ShakeNow = false;
       Counttime = 0;
    transform.localPosition = _initLocalPosition;
    
    
    }
}