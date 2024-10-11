using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRigidBullet : MonoBehaviour
{
    float m_speed;//弾の移動速度
    Vector3 m_shotVec;//弾の移動方向

    public void SetBullet(float speed,Vector3 shotVec)//弾のステータスを設定
    {
        m_speed = speed;
        m_shotVec = shotVec;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.LookRotation(m_shotVec, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }

    void MoveForward()//前(見てる方向)に進み続ける
    {
        Vector3 move = Vector3.forward;
        transform.Translate(move * Time.deltaTime * m_speed);
    }
}
