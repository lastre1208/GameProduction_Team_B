using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shot_E : MonoBehaviour
{
    [SerializeField] Bullet_E[] bullets;
    private float currentDelayTime;//現在の遅延時間、これがdelayTimeに達した時弾が撃たれる
    [Header("▼GamePos")]
    [SerializeField] GameObject gamePos;//GamePos、弾をこれの子オブジェクトとして配置する

    public void InitShotTiming()//撃つタイミングの初期化
    {
        for(int i=0; i<bullets.Length;i++)
        {
            bullets[i].Shoted = false;
        }

        currentDelayTime = 0;
    }

    public void ShotTiming()
    {
        currentDelayTime += Time.deltaTime;

        for(int i=0; i<bullets.Length;i++)
        {
            if (currentDelayTime >= bullets[i].DelayTime && !bullets[i].Shoted)
            {
                Shot(bullets[i]);
            }
        }
    }

    void Shot(Bullet_E bullet)
    {
        bullet.Shoted = true;
        //攻撃を撃ちだす位置と角度を取得
        Vector3 shotPosVec = bullet.ShotPos.transform.position;//位置
        Quaternion shotRotVec = bullet.ShotPos.transform.rotation;//角度
    }


    class Shot_Homing_E
    {

    }

    class Shot_Normal_E
    {

    }
}
