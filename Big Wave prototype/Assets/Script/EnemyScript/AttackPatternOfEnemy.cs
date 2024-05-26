using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AttackPattern//攻撃を撃つパターン
{
    shotStraight,//直線状に撃つ
    shotHoming,//ホーミングしながら撃つ
    shotHighSlash,//高い斬撃を撃つ
    shotWideWave//横に広い周波を撃つ
}

[System.Serializable]
class FormAttackPattern//形態
{
    public AttackPattern[] attackPatterns;//攻撃パターン
    public float[] attackProbability;//攻撃確率
    [HideInInspector] public float attackProbabilitySum=0;//攻撃確率(attackProbability)の合計、攻撃をランダムに決める時に使う
}

public class AttackPatternOfEnemy : MonoBehaviour
{
    [SerializeField] GameObject shotPosObject;//弾を撃ちだす位置
    [SerializeField] GameObject normalBulletPrefab;//直線状とホーミング撃ちに使う弾
    [SerializeField] GameObject highSlashPrefab;//高い斬撃
    [SerializeField] GameObject WideWavePrefab;//横に広い周波
    [SerializeField] float shotStraightPower = 9f;//弾を直線に撃つ力
    [SerializeField] float shotHomingPower = 9f;//ホーミングしながら弾を撃つ力
    [SerializeField] float shotHighSlashPower = 9f;//斬撃を撃つ力
    [SerializeField] float shotWideWavePower = 9f;//横に広い周波を撃つ力
    [SerializeField] Quaternion []attackRotation=new Quaternion [4];//横に広い周波の角度
    [SerializeField] FormAttackPattern[] form;//形態ごとの攻撃パターンと攻撃確率の配列
    Rigidbody bulletRb;
    GameObject player;
    Vector3 shotPos;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        for(int i=0; i<form.Length;i++)//それぞれの形態のattackProbabilitySumに値を入れる(初期化)
        {
            for(int j=0;j<form[i].attackProbability.Length ;j++)
            {
                form[i].attackProbabilitySum += form[i].attackProbability[j];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(int a)//攻撃を撃つ、aは何形態目か
    {
        //攻撃をランダムで決定(確率で実装予定)
        float attackPatternNumber = Random.Range(0, form[a-1].attackProbabilitySum);
        int attack = 0;//敵の攻撃パターン、どの攻撃パターンをするか決定するときに使用
        float attackSum = 0;

        //どの攻撃をするか決定するための処理
        //
        //
        for (int i=0; i<form[a-1].attackPatterns.Length;i++)
        {
            //その攻撃パターンの確率を足す
            attackSum += form[a - 1].attackProbability[i];

            //ランダムで出した値がattackSum未満であれば攻撃決定
            if(attackPatternNumber<attackSum)
            {
                break;
            }

            //決まらなければ次の攻撃の判定へ
            attack++;
        }

        //攻撃を撃ちだす位置を取得
        shotPos = shotPosObject.transform.position;

        //攻撃
        switch (form[a - 1].attackPatterns[attack])
        {
            case AttackPattern.shotStraight: ShotStraight(); break;//直線状に撃つ
            case AttackPattern.shotHoming: ShotHoming(); break;//ホーミングしながら撃つ
            case AttackPattern.shotHighSlash: ShotHighSlash(); break;//高い斬撃を撃つ
            case AttackPattern.shotWideWave: ShotWideWave(); break;//横に広い周波を撃つ
        }
       
    }
    void ShotStraight()//直線状に撃つ
    {
        GameObject straightBullet = Instantiate(normalBulletPrefab, shotPos, attackRotation[0]);
        bulletRb = straightBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(-transform.forward * shotStraightPower, ForceMode.Impulse);
        Debug.Log("Straight");
    }

    void ShotHoming()//ホーミングしながら撃つ
    {
        Vector3 toPlayer = (player.transform.position - shotPos).normalized;
        GameObject straightBullet = Instantiate(normalBulletPrefab, shotPos, attackRotation[1]);
        bulletRb = straightBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(toPlayer * shotHomingPower, ForceMode.Impulse);
        Debug.Log("Homing");
    }

    void ShotHighSlash()//高い斬撃を撃つ
    {
        GameObject highSlashBullet = Instantiate(highSlashPrefab, shotPos, attackRotation[2]);
        bulletRb = highSlashBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(-transform.forward * shotHighSlashPower, ForceMode.Impulse);
        Debug.Log("HighSlash");
    }

    void ShotWideWave()//横に広い周波を撃つ
    {
        GameObject wideWaveBullet = Instantiate(WideWavePrefab, shotPos, attackRotation[3]);
        bulletRb = wideWaveBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(-transform.forward * shotWideWavePower, ForceMode.Impulse);
        Debug.Log("WideWave");
    }
}
