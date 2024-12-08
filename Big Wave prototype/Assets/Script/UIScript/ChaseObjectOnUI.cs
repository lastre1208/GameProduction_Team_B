using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ターゲットを追いかけるUI
public class ChaseObjectOnUI : MonoBehaviour
{
    [Header("オブジェクトを移すカメラ")]
    [SerializeField] Camera _targetCamera;
    [Header("追いかける対象")]
    [SerializeField] private Transform _target;
    [Header("滑らかにゲージが移動するようにする")]
    [Tooltip("ゲージが振動するのをごまかすための処置")]
    [SerializeField] SmoothMovement _smoothMovement;
    private RectTransform _parentUI;//親の位置

    void Start()
    {
        // カメラが指定されていなければメインカメラにする
        if (_targetCamera == null)
            _targetCamera = Camera.main;

        // 親UIのRectTransformを保持
        _parentUI = transform.parent.GetComponent<RectTransform>();

        _smoothMovement.SecureBuffer();//バッファの確保
    }

    void Update()
    {
        UpdateUIPos();
    }

    void UpdateUIPos()//UIの位置を更新
    {
        // オブジェクトの位置
        var targetWorldPos = _target.position;
       
        if (!TargetIsFront(targetWorldPos)) return;

        // オブジェクトのワールド座標→スクリーン座標変換
        var targetScreenPos = _targetCamera.WorldToScreenPoint(targetWorldPos);

        // スクリーン座標変換→UIローカル座標変換
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _parentUI,
            targetScreenPos,
            null,//CanvasのrenderModeがOverrayの時はnullにする
            out var uiLocalPos
        );

        // RectTransformのローカル座標を更新
        transform.localPosition = _smoothMovement.Smooth(uiLocalPos);//動きも滑らかにする
    }

    bool TargetIsFront(Vector3 targetWorldPos)//ターゲットがカメラの前にいるか
    {
        Transform cameraTransform = _targetCamera.transform;

        // カメラの向きベクトル
        Vector3 cameraDir = cameraTransform.forward;

        // カメラからターゲットへのベクトル
        Vector3 targetDir = targetWorldPos - cameraTransform.position;

        // 内積を使ってカメラ前方かどうかを判定
        bool isFront = Vector3.Dot(cameraDir, targetDir) > 0;

        // カメラ前方ならUI表示、後方なら非表示
        gameObject.SetActive(isFront);

        return isFront;
    }
}
