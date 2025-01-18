using UnityEngine;

//作成者：桑原

[System.Serializable]
public class InertialMover : MonoBehaviour
{
    [Header("プレイヤーを引っ張るオブジェクト")]
    [SerializeField] Transform pullObject;
    [Header("pullObjectのx座標へ引き寄せられる力を加えるか")]
    [SerializeField] bool isTargetPositionPullEnabled;
    [Header("引っ張られたときにプレイヤーの角度を変化させるか")]
    [SerializeField] bool isTargetRotationPullEnabled;
    [Header("▼必要なコンポーネント")]
    [SerializeField] InertialMoveParameter moveParameter;
    [SerializeField] InertialRotateParameter rotateParameter;

    Vector3 velocity = Vector3.zero;
    float lerpSmoothness = 0.1f;

    public void InertialMovement(Vector3 move, Transform target)//慣性ありの移動
    {
        if (isTargetPositionPullEnabled)
        {
            ApplyTargetPositionPull(target);//引っ張られる挙動

            if (isTargetRotationPullEnabled)
                ApplyRotationBasedOnDistance(target);//引っ張られるオブジェクトの角度を変える
        }

        if (move.x == 0 && Mathf.Approximately(velocity.x, 0f))//移動可能範囲で慣性のリセット
            velocity.x = 0f;

        if (move.x != 0)
            velocity.x = Mathf.MoveTowards(velocity.x, move.x * moveParameter.TargetSpeed, moveParameter.Acceleration * Time.deltaTime);//加速

        else
            velocity.x = Mathf.MoveTowards(velocity.x, 0f, moveParameter.Deceleration * Time.deltaTime); //減速

        float nextPosition = target.localPosition.x + velocity.x * Time.deltaTime;//次の位置を計算

        //端での制限と反応
        if (nextPosition > moveParameter.MaxLocalPosition_X)
        {
            nextPosition = moveParameter.MaxLocalPosition_X;//右端に到達

            if (move.x <= 0)
                velocity.x = 0f;
        }

        else if (nextPosition < -moveParameter.MaxLocalPosition_X)
        {            
            nextPosition = -moveParameter.MaxLocalPosition_X;//左端に到達

            if (move.x >= 0)
                velocity.x = 0f;
        }

        //位置を更新
        target.localPosition = new Vector3(nextPosition, target.localPosition.y, target.localPosition.z);
    }

    void ApplyTargetPositionPull(Transform target)//プレイヤーを対象のオブジェクトのx座標位置に引き寄せる
    {
        float distanceFromPullPosition = target.localPosition.x - pullObject.localPosition.x;//プレイヤーと対象オブジェクトとのx座標の差を計算

        if (!Mathf.Approximately(distanceFromPullPosition, 0f)) //引っ張るオブジェクトと引っ張られるオブジェクトのx座標の差がほぼ0なら
        {
            float pullForce = Mathf.Clamp(Mathf.Abs(distanceFromPullPosition) * moveParameter.TargetPullStrength, 0f, moveParameter.MaxPullStrength);//引っ張る力を計算

            target.localPosition = Vector3.Lerp(
                target.localPosition,
                new Vector3(target.localPosition.x - Mathf.Sign(distanceFromPullPosition) * pullForce * Time.deltaTime, target.localPosition.y, target.localPosition.z),
                lerpSmoothness);
        }
    }

    void ApplyRotationBasedOnDistance(Transform target)//引っ張られるオブジェクトの角度を変える
    {
        float distanceFromPullPosition = target.localPosition.x - pullObject.localPosition.x;//プレイヤーと対象オブジェクトとのx座標の差を計算

        float rotationAmount = Mathf.Clamp(distanceFromPullPosition * rotateParameter.RotationStrength, -rotateParameter.MaxRotationAngle, rotateParameter.MaxRotationAngle);//回転量の計算、制限

        Quaternion targetRotation = Quaternion.Euler(0f, -rotationAmount, 0f);

        target.localRotation = Quaternion.Slerp(target.localRotation, targetRotation, Time.deltaTime * rotateParameter.RotationReturnSpeed);//目的の回転量までなめらかに回転させる
    }
    public void SetTargetPositionPull()
    {
        isTargetPositionPullEnabled = true;
    }
}