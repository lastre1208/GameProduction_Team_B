using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeTrickControl : MonoBehaviour
{
    //波の内側に波乗りしているときはoutSideChargeTrick、inSideChargeTrickの合計分トリックが増える
    [SerializeField] float outSideChargeTrick=1;//波の外側に波乗りした時に溜まるトリックの値
    [SerializeField] float inSideChargeTrick=2;//波の内側(中央)に波乗りした時に溜まるトリックの値
    Player player;
    Wave wave;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider t)
    {
        if(t.gameObject.CompareTag("InsideWave")|| t.gameObject.CompareTag("OutsideWave"))
        {
            wave = t.GetComponent<Wave>();
        }

        if ((Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space")) && t.gameObject.CompareTag("InsideWave")&&wave.isTouched==false)
        {
            player.ChargeTRICK(inSideChargeTrick);
            wave.isTouched = true;
        }

        else if((Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey("space")) && t.gameObject.CompareTag("OutsideWave") && wave.isTouched == false)
        {
            player.ChargeTRICK(outSideChargeTrick);
            wave.isTouched = true;
        }

        else
        {

        }
    }
}
