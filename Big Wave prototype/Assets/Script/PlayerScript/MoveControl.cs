using UnityEngine;

public class MoveControl : MonoBehaviour
{
    //☆塩が書いた
    [SerializeField] float speed = 11.5f;//移動スピード
    //[SerializeField] float trick_SpeedFactor=1f;//トリックをためた時のスピードの上昇具合、1、２、3、nだとそれぞれトリック満タン時、トリック空っぽの時のスピードの2、3、4、(1+1*n)倍になる
    Player player;


    // Start is called before the first frame update
    void Start()
    {
        player=gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()//プレイヤーの動き
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        float trickPercentage = player.Trick / player.TrickMax;//プレイヤーのトリックの(最大値に対しての現在のトリックの値)割合
        transform.Translate(move * Time.deltaTime * speed);//トリックがたまっているほど移動スピードがはやくなる
    }
}
