using UnityEngine;

// 作成者: 杉山、桑原が一部修正
// 横移動(Rigidbodyなし）

public class MoveLeftAndRight : MonoBehaviour
{
    [Header("動かす対象")]
    [SerializeField] Transform target;
    [Header("移動スピード")]
    [SerializeField] float speed = 11.5f;//移動スピード
    [Header("移動に慣性をつけるかどうか")]
    [SerializeField] bool isInertiaEnabled;
    [SerializeField] InertialMover inertialMover;

    private Vector3 move;

    private void Update()
    {
        Move();
    }

    void Move()//プレイヤーの移動
    {
        if (!isInertiaEnabled)
            target.Translate(move * Time.deltaTime * speed);//慣性なしの移動

        else
        {
            inertialMover.InertialMovement(move, target);//慣性ありの移動
        }
    }

    public void GetMoveVector(Vector2 getVec)//動く方向を受け取る
    {
        //x方向の入力だけ受け取る
        move = new Vector3(getVec.x, 0f, 0f);
    }
}
