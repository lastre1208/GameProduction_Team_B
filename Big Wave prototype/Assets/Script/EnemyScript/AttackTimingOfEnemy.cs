using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTimingOfEnemy : MonoBehaviour
{
    [SerializeField] bool secondForm=false;//第二形態の有無
    [SerializeField] float secondFormHp = 500;//第二形態突入条件体力(この体力未満の時第二形態突入)
    [SerializeField] float firstBeginAttackingTime = 5f;//敵が次に攻撃を始める時間(初回)
    [SerializeField] float minFirstFormBeginAttackingTime = 0.1f;//敵が次に攻撃を始める最小時間(第一形態)
    [SerializeField] float maxFirstFormBeginAttackingTime = 0.4f;//敵が次に攻撃を始める最大時間(第一形態)
    [SerializeField] float minSecondFormBeginAttackingTime = 0.1f;//敵が次に攻撃を始める最小時間(第二形態)
    [SerializeField] float maxSecondFormBeginAttackingTime = 0.4f;//敵が次に攻撃を始める最大時間(第二形態)
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
    }

    // Update is called once per frame
    void Update()
    {
        AttackTiming();
    }

    void AttackTiming()//敵の攻撃タイミング
    {
        attackTime += Time.deltaTime;

        if(attackTime>beginAttackingTime&&enemy.hp<secondFormHp&&secondForm==true)//第二形態の行動
        {
            attackTime = 0f;
            beginAttackingTime = Random.Range(minSecondFormBeginAttackingTime, maxSecondFormBeginAttackingTime);
            attackPatternOfEnemy.Attack(2);
        }

        else if(attackTime>beginAttackingTime)//第一形態時の行動
        {
            attackTime = 0f;
            beginAttackingTime = Random.Range(minFirstFormBeginAttackingTime, maxFirstFormBeginAttackingTime);
            attackPatternOfEnemy.Attack(1);
        }
    }

    
}
