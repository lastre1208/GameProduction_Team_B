using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class InstantiateRope : MonoBehaviour
//{
//    //☆桑原君が書いた
//    HP enemy_Hp;
//    HP player_Hp;

//    [SerializeField] GameObject ropePrefab;//ロープのプレハブ
//    private GameObject ropeInstance;

//    // Start is called before the first frame update
//    void Start()
//    {
//        enemy_Hp = GameObject.FindWithTag("Enemy").GetComponent<HP>();
//        player_Hp = GameObject.FindWithTag("Player").GetComponent<HP>();

//        ropeInstance = Instantiate(ropePrefab);//ロープ生成
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (enemy_Hp.Hp <= 0 || player_Hp.Hp <= 0)//敵かプレイヤーのhpが0以下になったら
//        {
//            Destroy(ropeInstance);//ロープ消滅
//        }
//    }
//}
