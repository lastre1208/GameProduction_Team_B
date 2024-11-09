using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplay : MonoBehaviour
{
    [Header("��HP�Q�[�W")]
    [SerializeField] Image hpGauge;//HP�Q�[�W
    [Header("��HP��\���������I�u�W�F�N�g")]
    [SerializeField] HP objectDisplayHp;//HP��\���������I�u�W�F�N�g

    void Update()
    {
        HPGauge();
    }

    void HPGauge()//HP�Q�[�W�̏���
    {
        float hpRatio = objectDisplayHp.Hp / objectDisplayHp.HpMax;
        hpGauge.fillAmount = hpRatio;
    }
}