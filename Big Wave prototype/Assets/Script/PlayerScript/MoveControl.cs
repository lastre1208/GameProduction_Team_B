using UnityEngine;

public class MoveControl : MonoBehaviour
{
    [SerializeField] float speed = 11.5f;//移動スピード

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()//プレイヤーの動き
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(move * Time.deltaTime * speed);
    }
}
