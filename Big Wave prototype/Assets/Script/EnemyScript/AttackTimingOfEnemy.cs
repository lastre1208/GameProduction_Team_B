using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
class FormAttackTiming//形態
{
    public float formHp;//指定形態突入条件体力(この体力以下の時その形態突入)
    public float minBeginAttackingTime;//敵が次に攻撃を始める最小時間
    public float maxBeginAttackingTime;//敵が次に攻撃を始める最大時間
}

public class AttackTimingOfEnemy : MonoBehaviour
{
    [SerializeField] float firstBeginAttackingTime = 5f;//敵が次に攻撃を始める時間(初回)
    [SerializeField] FormAttackTiming[] form;//形態ごとの攻撃タイミングと突入条件体力の配列
    private float beginAttackingTime;//敵が次に攻撃を始める時間
    private float attackTime = 0f;//敵の攻撃を管理する時間
    AttackPatternOfEnemy attackPatternOfEnemy;
    Enemy enemy;
   
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
        attackPatternOfEnemy = gameObject.GetComponent<AttackPatternOfEnemy>();
        beginAttackingTime = firstBeginAttackingTime;

        form[0].formHp = enemy.hpMax;
    }

    // Update is called once per frame
    void Update()
    {
        AttackTiming();
    }

    void AttackTiming()//敵の攻撃タイミング
    {
        attackTime += Time.deltaTime;

        if(attackTime > beginAttackingTime)
        {
            for (int i = form.Length-1; 0<=i ; i--)//指定体力以下でその形態の行動をする(最終形態の条件から順に見ていく)
            {
                if (enemy.hp <= form[i].formHp)//i+1形態目の条件を確認
                {
                    attackTime = 0f;
                    beginAttackingTime = Random.Range(form[i].minBeginAttackingTime, form[i].maxBeginAttackingTime);
                    attackPatternOfEnemy.Attack(i+1);
                    break;
                }
            }
        }
    }

    
}
