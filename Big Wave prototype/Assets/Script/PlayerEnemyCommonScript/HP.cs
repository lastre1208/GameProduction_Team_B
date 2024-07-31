using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    [Header("最大体力")]
    [SerializeField] float hpMax = 500;//最大体力
    private float hp = 500;//現在の体力
    Controller controller;
    ManagementOfScore managementOfScore;

    public float Hp
    {
        get { return hp; }
        set 
        {
            hp = value;
            hp = Mathf.Clamp(hp, 0f, hpMax);//体力が限界突破しないように
            Dead();//死亡時の処理
        }
    }

    public float HpMax
    {
        get { return hpMax; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Hpの初期化
        hp = hpMax;

        controller = GameObject.FindWithTag("Player").GetComponent<Controller>();

        managementOfScore= GameObject.FindWithTag("ScoreManager").GetComponent<ManagementOfScore>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //後で別のスクリプトに移すかも
    void Dead()//死亡時の処理
    {
        if (hp <= 0)
        {
            controller.StopVibe_Trick();//ゲーム終了時コントローラーの振動を止める応急処置

            if (this.gameObject.tag=="Player")//プレイヤーならゲームオーバーシーンに移行
            {
                SceneManager.LoadScene("GameoverScene");
            }
            else if(this.gameObject.tag == "Enemy")//敵ならクリアシーンに移行
            {
                managementOfScore.CalculateScore();
                SceneManager.LoadScene("ClearScene");
            }
        }
    }
}
