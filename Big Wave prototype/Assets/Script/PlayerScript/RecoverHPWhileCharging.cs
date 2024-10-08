using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverHPWhileCharging : MonoBehaviour
{
    [SerializeField] HP hp_Player;
    [SerializeField] JudgeChargeTrickPointNow judgeChargeTrickPointNow;
    [Header("1•b‚²‚Æ‚Ì‘Ì—Í‰ñ•œ—Ê")]
    [SerializeField] float recoveryAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RecoverHP(judgeChargeTrickPointNow.ChargeNow());
    }

    void RecoverHP(bool chargeNow)
    {
        if(chargeNow)
        {
            hp_Player.Hp += recoveryAmount * Time.deltaTime;
        }
    }
}
