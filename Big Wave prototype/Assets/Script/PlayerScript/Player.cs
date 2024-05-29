using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float hp = 100;//現在の体力
    public float hpMax = 100;//最大体力
    public float trick = 0;//現在のトリックゲージ
    public float trickMax = 50;//最大トリックゲージ
    SceneControlManager sceneControlManager;
    public AudioClip sound1;//攻撃に用いる効果音。改善の余地あり。
   public AudioSource audioSource;//プレイヤーから音を出す為の処置。
    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;//ステータス初期化
        trick = 0;
        sceneControlManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneControlManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        LimitHP();//体力が限界突破しないように

        LimitTRICK();//トリックが限界突破しないように

        Dead();//敵プレイヤー死亡時ゲームオーバーシーンに移行
    }

    public void Damage(float a)//プレイヤーにダメージを与える(aの値分与える)
    {
        hp -= a;
    }
   
    public void ChargeTRICK(float a)//トリックを増やす
    {
        trick+=a;
    }

    public void ConsumeTRICK(float a)//トリックをa分消費する
    {
        trick -= a;
    }

    void LimitHP()//体力が限界突破しないように
    {
        if (hp > hpMax)
        {
            hp = hpMax;
        }
    }

    void LimitTRICK()//トリックが限界突破しないように
    {
        if (trick > trickMax)
        {
            trick = trickMax;
        }
    }

    void Dead()//敵プレイヤー死亡時ゲームオーバーシーンに移行
    {
        if(hp<=0)
        {
            sceneControlManager.ChangeGameoverScene();
        }
    }
    //public void AttackVibration(float a)//攻撃の強さに合わせて振動を強くする
    //{
    //    if (gamepad != null)
    //    { 

    //        gamepad.SetMotorSpeeds(a,a);
    //    }
    //}
    //public void StopVibration()
    //{
    //    if (gamepad != null)
    //    { 

    //        gamepad.SetMotorSpeeds(0,0);
    //    }
    //}



}
