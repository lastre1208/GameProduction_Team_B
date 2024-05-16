using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTimingOfEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;//“G
    [SerializeField] float firstBeginAttackingTime = 5f;//“G‚ªŸ‚ÉUŒ‚‚ğn‚ß‚éŠÔ(‰‰ñ)
    [SerializeField] float minBeginAttackingTime = 0.1f;//“G‚ªŸ‚ÉUŒ‚‚ğn‚ß‚éÅ¬ŠÔ
    [SerializeField] float maxBeginAttackingTime = 0.4f;//“G‚ªŸ‚ÉUŒ‚‚ğn‚ß‚éÅ‘åŠÔ
    private float beginAttackingTime;//“G‚ªŸ‚ÉUŒ‚‚ğn‚ß‚éŠÔ
    private float attackTime = 0f;//“G‚ÌUŒ‚‚ğŠÇ—‚·‚éŠÔ
    AttackPatternOfEnemy attackPatternOfEnemy;
   
    
    // Start is called before the first frame update
    void Start()
    {
        attackPatternOfEnemy = enemy.GetComponent<AttackPatternOfEnemy>();
        beginAttackingTime = firstBeginAttackingTime;
    }

    // Update is called once per frame
    void Update()
    {
        AttackTiming();
    }

    void AttackTiming()//“G‚ÌUŒ‚ƒ^ƒCƒ~ƒ“ƒO
    {
        attackTime += Time.deltaTime;

        if(attackTime>beginAttackingTime)
        {
            attackTime = 0f;
            beginAttackingTime = Random.Range(minBeginAttackingTime,maxBeginAttackingTime);
            attackPatternOfEnemy.Attack();
        }
    }

    
}
