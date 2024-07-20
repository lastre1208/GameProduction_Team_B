using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActOfEnemy : MonoBehaviour
{
    //☆塩が書いた
    [Header("▼弾を撃ちだす位置")]
    [SerializeField] GameObject shotPosObject;//弾を撃ちだす位置
    [Header("▼GamePos")]
    [SerializeField] GameObject gamePos;

    [Header("▼直線撃ちに使う弾")]
    [SerializeField] GameObject normalBulletPrefab;//直線状撃ちに使う弾
    [Header("▼ホーミング撃ちに使う弾")]
    [SerializeField] GameObject homingBulletPrefab;//ホーミング撃ちに使う弾
    [Header("▼縦に長い斬撃")]
    [SerializeField] GameObject highSlashPrefab;//高い斬撃
    [Header("▼横に広い周波")]
    [SerializeField] GameObject wideWavePrefab;//横に広い周波

    [Header("▼弾を直線に撃つ力")]
    [SerializeField] float shotStraightPower = 9f;//弾を直線に撃つ力
    [Header("▼ホーミングしながら弾を撃つ力")]
    [SerializeField] float shotHomingPower = 9f;//ホーミングしながら弾を撃つ力
    [Header("▼斬撃を撃つ力")]
    [SerializeField] float shotHighSlashPower = 9f;//斬撃を撃つ力
    [Header("▼横に広い周波を撃つ力")]
    [SerializeField] float shotWideWavePower = 9f;//横に広い周波を撃つ力

    Rigidbody bulletRb;
    MoveOfEnemy moveOfEnemy;
    GameObject player;
    Vector3 shotPos;//弾を撃ちだす位置を入れる

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        moveOfEnemy=gameObject.AddComponent<MoveOfEnemy>();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void Move()//動く
    {
        moveOfEnemy.MoveNow = true;
        moveOfEnemy.ChangeMove();//動き方を決定
    }

    public void Stop()//止まる
    {
        moveOfEnemy.MoveNow = false;
    }

    public void ShotStraight()//直線状に撃つ
    {
        //弾を撃ちだす
        Shot(normalBulletPrefab, shotStraightPower, true);
        //メッセージ
        Debug.Log("Straight");
    }

    public void ShotHoming()//ホーミングしながら撃つ
    {
        //ホーミング弾を撃ちだす
        Shot(homingBulletPrefab, shotHomingPower, true);
        //メッセージ
        Debug.Log("Homing");
    }

    public void ShotHighSlash()//高い斬撃を撃つ
    {
        //斬撃を撃ちだす
        Shot(highSlashPrefab, shotHighSlashPower, false);
        //メッセージ
        Debug.Log("HighSlash");
    }

    public void ShotWideWave()//横に広い周波を撃つ
    {
        //横に広い波を撃ちだす
        Shot(wideWavePrefab, shotWideWavePower,false);
        //メッセージ
        Debug.Log("WideWave");
    }

    void Shot(GameObject bulletPrefab,float shotPower,bool homing)//攻撃を撃ちだす、homingはホーミングして撃つか(trueならホーミングして撃つ)
    {
        //攻撃を撃ちだす位置を取得
        shotPos = shotPosObject.transform.position;
        //攻撃を撃ちだす
        GameObject Bullet = Instantiate(bulletPrefab, shotPos, transform.rotation,gamePos.transform);

        bulletRb = Bullet.GetComponent<Rigidbody>();
        if(homing)//ホーミングして撃つ
        {
            //撃つ場所からプレイヤー方向のベクトルを算出&大きさを1に
            Vector3 toPlayer = (player.transform.position - shotPos).normalized;

            //攻撃の向きをプレイヤーのいる方向に変更
            Bullet.transform.rotation = Quaternion.LookRotation(toPlayer,Vector3.up);

            bulletRb.AddForce(toPlayer * shotHomingPower, ForceMode.Impulse);
        }
        else//直線に撃つ
        {
            bulletRb.AddForce(-transform.forward * shotPower, ForceMode.Impulse);
        }
    }
}
