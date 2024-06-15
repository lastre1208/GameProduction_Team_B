using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //☆塩が書いた
    private float hp = 100;//現在の体力
    [Header("プレイヤーの最大体力")]
    [SerializeField] float hpMax = 100;//最大体力
    private float trick = 0;//現在のトリックゲージ
    [Header("プレイヤーの最大トリック")]
    [SerializeField] float trickMax = 200;//最大トリックゲージ
    SceneControlManager sceneControlManager;

    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public float HpMax
    {
       get { return hpMax; }
    }

    public float Trick
    {
        get { return trick; }
        set { trick = value; }
    }

    public float TrickMax
    {
        get { return trickMax; }
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;//ステータス初期化
        trick = 0;
        sceneControlManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneControlManager>();
    }

    // Update is called once per frame
    void Update()
    {
        hp=Mathf.Clamp(hp,0,hpMax);//体力が限界突破しないように

        trick=Mathf.Clamp(trick, 0, trickMax);//トリックが限界突破しないように

        Dead();//敵プレイヤー死亡時ゲームオーバーシーンに移行
    }

    void Dead()//プレイヤー死亡時ゲームオーバーシーンに移行
    {
        if(hp <=0)
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
