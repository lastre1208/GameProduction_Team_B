using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//一定時間弾がホーミングしながら動く
public class HomingBullet : MonoBehaviour
{
    float startHomingTime;//発射されて何秒後からホーミングし始めるか                      
    float homingTime;//何秒間ホーミングするか
    float homingSpeed;//標的に向く速度

    private float currentHomingTime = 0;//現在のホーミング時間
    private float finishHomingTime;//発射されて何秒後にホーミングをやめるか
    Transform target;//ホーミング時の標的(プレイヤー)

    public float StartHomingTime//発射されて何秒後からホーミングし始めるか
    {
        set { currentHomingTime = value; }
        get { return currentHomingTime; }
    }

    public float HomingTime//何秒間ホーミングするか
    {
        set { homingTime = value; }
        get { return homingTime; }
    }

    public float HomingSpeed//標的に向く速度
    {
        set { homingSpeed = value; }
        get { return homingSpeed;}
    }

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        finishHomingTime = startHomingTime + homingTime;//ホーミング終了時間を設定
    }

    void Update()
    {
        currentHomingTime += Time.deltaTime;

        bool homingNow = (startHomingTime <= currentHomingTime && currentHomingTime <= finishHomingTime);

        if(homingNow)//時間になるまで標的の方向を見続ける
        {
            Homing();
        }
    }

    void Homing()//標的を見続ける
    {
        Vector3 targetPos = target.transform.position - transform.position;//自分の位置から標的の位置までのベクトルの取得
        Quaternion targetRotation = Quaternion.LookRotation(targetPos);//先ほどのベクトルから回転する角度を設定
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, homingSpeed*Time.deltaTime);
    }
}
