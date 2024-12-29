using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//徐々にオブジェクトを大きくするスクリプト。delayをかけると遅延後一気にスピードを上げて発射されるようになる。
public class ScaleUp : MonoBehaviour
{

    [SerializeField] float scaleSpeed; 
    [SerializeField] float delayScale;
    float countTime;

    
    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if(countTime > delayScale)
        {
            
            transform.localScale +=new Vector3(scaleSpeed*Time.deltaTime,scaleSpeed*Time.deltaTime,scaleSpeed*Time.deltaTime);
        }
    }
}
