using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DebugScript : MonoBehaviour
{
    [SerializeField] HP player;
    [SerializeField] HP enemy;
    [SerializeField]  TMP_Text debug;
    [SerializeField]ActionPattern actionPattern_a;
    [SerializeField] ActionPattern actionPattern_b;
    [SerializeField] ActionPattern actionPattern_c;
    [SerializeField] AlgorithmOfEnemy algorithm;
   
    // Start is called before the first frame update
    void Start()
    {
       
        debug.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            player.HpMax=99999;
            player.Hp = 99999;
           
            debug.enabled = true;
        
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            algorithm.ChangeAction(actionPattern_a);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            algorithm.ChangeAction(actionPattern_b);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            algorithm.ChangeAction(actionPattern_c);
        }
        else if(Input.GetKeyDown(KeyCode.W)) {

            enemy.HpMax = 10;
            enemy.Hp = 1;
        }
    }
}
