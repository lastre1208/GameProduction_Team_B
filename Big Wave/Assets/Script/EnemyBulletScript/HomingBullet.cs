using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//一定時間弾がホーミングしながら動く
public class HomingBullet : MonoBehaviour
{
    float m_startHomingTime;//発射されて何秒後からホーミングし始めるか                      
    float m_homingTime;//何秒間ホーミングするか
    float m_homingSpeed;//標的に向く速度
    float m_speed;//弾の移動速度

    private float currentHomingTime = 0;//現在のホーミング時間
    private float finishHomingTime;//発射されて何秒後にホーミングをやめるか
    Transform target;//ホーミング時の標的(プレイヤー)

    //引数のstartHomingTimeは発射されて何秒後からホーミングし始めるか、
    //homingTimeは何秒間ホーミングするか
    //homingSpeedは標的に向く速度
    //speedは前方移動速度
    public void SetBullet(float startHomingTime,float homingTime,float homingSpeed,float speed)//ホーミング弾のステータス(標的に向く速度など)を設定
    {
        m_startHomingTime=startHomingTime;
        m_homingTime=homingTime;
        m_homingSpeed=homingSpeed;
        m_speed=speed;
    }

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        finishHomingTime = m_startHomingTime + m_homingTime;//ホーミング終了時間を設定
    }

    void Update()
    {
        currentHomingTime += Time.deltaTime;

        bool homingNow = (m_startHomingTime <= currentHomingTime && currentHomingTime <= finishHomingTime);

        if(homingNow)//時間になるまで標的の方向を見続ける
        {
            Homing();//標的を見続ける
        }

        MoveForward();//前(見てる方向)に進み続ける
    }

    void Homing()//標的を見続ける
    {
        Vector3 targetPos = target.transform.position - transform.position;//自分の位置から標的の位置までのベクトルの取得
        Quaternion targetRotation = Quaternion.LookRotation(targetPos);//現在のベクトルから回転する角度を設定
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, m_homingSpeed*Time.deltaTime);
    }

    void MoveForward()//前(見てる方向)に進み続ける
    {
        Vector3 move = Vector3.forward;
        transform.Translate(move * Time.deltaTime * m_speed);
    }
}
