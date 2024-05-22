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
    public Gamepad gamepad = Gamepad.current;

    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;//ステータス初期化
        trick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LimitHP();//体力が限界突破しないように

        LimitTRICK();//トリックが限界突破しないように
    }

    public void Damage(float a)//プレイヤーにダメージを与える(aの値分与える)
    {
        hp -= a;
    }
   
    public void ChargeTRICK(float a)//トリックを増やす
    {
        trick+=a;
    }

    public void ConsumeTRICK(float a)//トリックを0にする
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
    public void AttackVibration(float a)//攻撃の強さに合わせて振動を強くする
    {
        if (gamepad != null)
        { 

            gamepad.SetMotorSpeeds(a,a);
        }
    }
    public void StopVibration()
    {
        if (gamepad != null)
        { 

            gamepad.SetMotorSpeeds(0,0);
        }
    }



}
