using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 1000f;//“G‚ÌHP
    public float hpMax = 1000f;//“G‚ÌÅ‘åHP
    
    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;
    }

    // Update is called once per frame
    void Update()
    {
        DeadEnemy();//“G€–S
    }

    public void Damage(float a)//“G‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚é(a‚Ì’l•ªƒ_ƒ[ƒW‚ğ—^‚¦‚é)
    {
        hp -= a;
    }

    void DeadEnemy()//“G€–SA“G‚ğÁ‚·
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    

    

    
}
