using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOfBullet : MonoBehaviour
{
    //☆塩が書いた
    [SerializeField] float damage;//ダメージ量
    [SerializeField] bool ifHitDestroy=true;//プレイヤーに当たった時に弾を消すか
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider t)
    {
        if(t.gameObject.CompareTag("Player"))
        {
            HP player_Hp;
            player_Hp = t.GetComponent<HP>();
            ManagementOfScore managementOfScore;
            managementOfScore = GameObject.FindWithTag("ScoreManager").GetComponent<ManagementOfScore>();

            player_Hp.Hp -= damage;//プレイヤーにダメージを与える
            managementOfScore.AddDamageCount();//被弾回数を増やす
            

            if(ifHitDestroy)//trueかつ当たった時弾が消える
            {
                Destroy(gameObject);
            }
        }
    }
}
