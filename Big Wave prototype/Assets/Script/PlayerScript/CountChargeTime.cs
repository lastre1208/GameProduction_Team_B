using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//トリックポイントのチャージ時間を計測する
public class CountChargeTime : MonoBehaviour
{
    [Header("必要なコンポーネント")]
    [SerializeField] JudgeChargeTrickPointNow judge;
    private float m_chargeTime = 0;

    public float ChargeTime { get { return m_chargeTime; }  }

    // Update is called once per frame
    void Update()
    {
        Count();
    }

    void Count()
    {
        if(judge.ChargeNow())//チャージ時間を計測
        {
            m_chargeTime += Time.deltaTime;
        }
    }
}
