using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 1000f;//GĚHP
    public float hpMax = 1000f;//GĚĹĺHP
    
    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;
    }

    // Update is called once per frame
    void Update()
    {
        DeadEnemy();//GS
    }

    public void Damage(float a)//GÉ_[Wđ^Śé(aĚlŞ_[Wđ^Śé)
    {
        hp -= a;
    }

    void DeadEnemy()//GSAGđÁˇ
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    

    

    
}
