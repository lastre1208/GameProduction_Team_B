using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//チャージ中HPを回復させる
public class RecoverHPWhileCharging : MonoBehaviour
{
    [Header("1秒ごとの体力回復量")]
    [SerializeField] float recoveryAmount;
    [Header("必要なコンポーネント")]
    [SerializeField] HP hp_Player;
    [SerializeField] JudgeChargeTrickPointNow judgeChargeTrickPointNow;
    bool healing=false;//回復中か

    public bool Healing { get { return healing; } }

    void Update()
    {
        RecoverHP();
    }

    void RecoverHP()
    {
        healing = judgeChargeTrickPointNow.ChargeNow();//回復する条件

        if(healing)
        {
            hp_Player.Hp += recoveryAmount * Time.deltaTime;
        }
    }
}
