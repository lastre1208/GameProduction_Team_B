using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRope : MonoBehaviour
{
    //☆桑原君が書いた
    Enemy enemy;
    Player player;

    [SerializeField] GameObject ropePrefab;//ロープのプレハブ
    private GameObject ropeInstance;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        ropeInstance = Instantiate(ropePrefab);//ロープ生成
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.Hp <= 0 || player.Hp <= 0)//敵かプレイヤーのhpが0以下になったら
        {
            Destroy(ropeInstance);//ロープ消滅
        }
    }
}
