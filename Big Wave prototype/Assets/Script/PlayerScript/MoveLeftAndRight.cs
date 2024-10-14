using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//横移動
public class MoveLeftAndRight : MonoBehaviour
{
    [SerializeField] float speed = 11.5f;//移動スピード
    Vector3 move;

    void Update()
    {
        Move();
    }

    void Move()//プレイヤーの移動
    {
        transform.Translate(move * Time.deltaTime * speed);//プレイヤーの移動
    }

    public void GetMoveVector(Vector2 getVec)//動く方向を受け取る
    {
        //x方向の入力だけ受け取る
        move = new Vector3(getVec.x,0f,0f);
    }
}
