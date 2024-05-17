using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPatternOfEnemy : MonoBehaviour
{
    public enum AttackPattern//攻撃を撃つパターン
    {
        shotStraight,//直線状に撃つ
        shotHoming,//ホーミングしながら撃つ
        shotHighSlash,//高い斬撃を撃つ
        shotWideWave//横に広い周波を撃つ
    }

    [SerializeField] GameObject shotPosObject;//弾を撃ちだす位置
    [SerializeField] GameObject normalBulletPrefab;//直線状とホーミング撃ちに使う弾
    [SerializeField] GameObject highSlashPrefab;//高い斬撃
    [SerializeField] GameObject WideWavePrefab;//横に広い周波
    [SerializeField] float shotStraightPower = 9f;//弾を直線に撃つ力
    [SerializeField] float shotHomingPower = 9f;//ホーミングしながら弾を撃つ力
    [SerializeField] float shotHighSlashPower = 9f;//斬撃を撃つ力
    [SerializeField] float shotWideWavePower = 9f;//横に広い周波を撃つ力
    public FormArray[] form;

    [System.Serializable]
    public class FormArray
    {
        public AttackPattern[] attackPatterns;
    }

    //[SerializeField] AttackPattern[,] attackPatterns;//第一形態の敵の行動パターン(1行目は第一形態、2行目は第二形態)
    //[SerializeField] AttackPattern[,] secondFormAttackPatterns;//第二形態の敵の行動パターン
    private int attackPatternNumber;//これで敵の行動パターンを決める
    Rigidbody bulletRb;
    GameObject player;
    Vector3 shotPos;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(int a)//攻撃を撃つ(第一形態の行動)、aは何形態目か(2まで)
    {
        if(a==1)
        {
            attackPatternNumber = Random.Range(0, form[0].attackPatterns.Length);
        }
        else if(a==2)
        {
            attackPatternNumber = Random.Range(0, form[1].attackPatterns.Length);
        }

        shotPos = shotPosObject.transform.position;

        switch(form[a-1].attackPatterns[attackPatternNumber])
        {
            case AttackPattern.shotStraight: ShotStraight(); break;//直線状に撃つ
            case AttackPattern.shotHoming: ShotHoming(); break;//ホーミングしながら撃つ
            case AttackPattern.shotHighSlash: ShotHighSlash(); break;//高い斬撃を撃つ
            case AttackPattern.shotWideWave: ShotWideWave(); break;//横に広い周波を撃つ
        }
    }
    void ShotStraight()//直線状に撃つ
    {
        GameObject straightBullet = Instantiate(normalBulletPrefab, shotPos, transform.rotation);
        bulletRb = straightBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(-transform.forward * shotStraightPower, ForceMode.Impulse);
        Debug.Log("Straight");
    }

    void ShotHoming()//ホーミングしながら撃つ
    {
        Vector3 toPlayer = (player.transform.position - shotPos).normalized;
        GameObject straightBullet = Instantiate(normalBulletPrefab, shotPos, transform.rotation);
        bulletRb = straightBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(toPlayer * shotHomingPower, ForceMode.Impulse);
        Debug.Log("Homing");
    }

    void ShotHighSlash()//高い斬撃を撃つ
    {
        GameObject highSlashBullet = Instantiate(highSlashPrefab, shotPos, transform.rotation);
        bulletRb = highSlashBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(-transform.forward * shotHighSlashPower, ForceMode.Impulse);
        Debug.Log("HighSlash");
    }

    void ShotWideWave()//横に広い周波を撃つ
    {
        GameObject wideWaveBullet = Instantiate(WideWavePrefab, shotPos, transform.rotation);
        bulletRb = wideWaveBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(-transform.forward * shotWideWavePower, ForceMode.Impulse);
        Debug.Log("WideWave");
    }
}
