using UnityEngine;

// 作成者: 杉山、桑原が一部修正
// 横移動(Rigidbodyなし）

public class MoveLeftAndRight : MonoBehaviour
{
    [Header("移動に慣性をつけるかどうか")]
    [SerializeField] bool isInertiaEnabled;
    [Header("中央へ引き寄せられる力を加えるかどうか")]
    [SerializeField] bool isCenterPullEnabled;
    [Header("移動スピード")]
    [SerializeField] float speed = 11.5f;//移動スピード
    [Header("加速度")]
    [SerializeField] float acceleration = 300f;
    [Header("減速度")]
    [SerializeField] float deceleration = 150f;
    [Header("最高速度")]
    [SerializeField] float targetSpeed = 150f;
    [Header("中央に引き寄せる力")]
    [SerializeField] float centerPullStrength = 10f;
    [Header("引き寄せる力の最大値")]
    [SerializeField] float maxCenterPullStrength = 100f;
    [Header("中央からの距離の閾値")]
    [SerializeField] float centerThreshold = 0.1f;

    Vector3 move;
    Vector3 velocity = Vector3.zero;

    private void Update()
    {
        Move();
    }

    void Move()//プレイヤーの移動
    {
        if (!isInertiaEnabled)
            transform.Translate(move * Time.deltaTime * speed);

        else
        {
            if (move.x != 0)
            {
                //加速
                velocity.x = Mathf.MoveTowards(velocity.x, move.x * targetSpeed,  /*speed **/ acceleration * Time.deltaTime);
            }

            else
            {
                //減速
                velocity.x = Mathf.MoveTowards(velocity.x, 0f, deceleration * Time.deltaTime);
            }

            float targetPosition = transform.localPosition.x + velocity.x * Time.deltaTime;
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(targetPosition, transform.localPosition.y, transform.localPosition.z), 0.1f); // Lerpでスムーズに移動

            //最大速度制限
            if (velocity.x > targetSpeed)
            {
                velocity.x = targetSpeed;
            }

            if (move.x == 0 && Mathf.Approximately(velocity.x, 0f) || Mathf.Approximately(transform.localPosition.x, 9f))
            {
                velocity.x = 0f;
            }

            if (isCenterPullEnabled)
            ApplyCenterPull();
        }
    }

    void ApplyCenterPull()//プレイヤーを中央に引き寄せる機能
    {
        float centerPosition = 0f;

        float distanceFromCenter = transform.localPosition.x - centerPosition;

        if (Mathf.Abs(distanceFromCenter) > centerThreshold)
        {
            float pullForce = Mathf.Clamp(Mathf.Abs(distanceFromCenter) * centerPullStrength, 0f, maxCenterPullStrength);

            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x - Mathf.Sign(distanceFromCenter) * pullForce * Time.deltaTime, transform.localPosition.y, transform.localPosition.z), 0.1f);
        }
    }

    public void GetMoveVector(Vector2 getVec)//動く方向を受け取る
    {
        //x方向の入力だけ受け取る
        move = new Vector3(getVec.x, 0f, 0f);
    }
}
