using UnityEngine;

//作成者:杉山
//横移動
public class MoveLeftAndRight : MonoBehaviour
{
    [SerializeField] float speed = 11.5f;//移動スピード

    void Update()
    {
        Move();
    }

    void Move()//プレイヤーの動き
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(move * Time.deltaTime * speed);//トリックがたまっているほど移動スピードがはやくなる
    }
}
