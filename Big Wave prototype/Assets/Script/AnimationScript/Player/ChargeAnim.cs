using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAnim : MonoBehaviour
{
    [Header("必要なコンポーネント")]
    [SerializeField] JudgeChargeTrickPointNow judgeChargeTrickPointNow;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChargeBool();
    }

    void ChargeBool()
    {
        animator.SetBool("ChargeNow",judgeChargeTrickPointNow.ChargeNow());
    }
}
