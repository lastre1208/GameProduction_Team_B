using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//コンボ回数(クリティカルの連続回数)を数える
public class CountTrickCombo : MonoBehaviour
{
    [Header("必要なコンポーネント")]
    [SerializeField] Critical critical;
    private int m_comboCount = 0;//コンボ回数
    private int m_comboCountMax = 0;//最大コンボ回数
    private bool m_continueCombo=false;//コンボが続いているか
    //const int m_resetComboCount = 0;//リセット時のコンボ回数

    public int ComboCount{ get { return m_comboCount; } }

    public int ComboCountMax{ get { return m_comboCountMax; } }

    public bool ContinueCombo{ get { return m_continueCombo; } }

    public void Count()//回数を増やす
    {
        if(critical.CriticalNow)//クリティカルだったら
        {
            AddCombo();//回数加算処理
        }
        else//クリティカルじゃなかったら
        {
            ResetCombo();//回数リセット処理
        }
    }

    void AddCombo()//回数加算処理
    {
        //コンボ回数を加算
        m_comboCount++;

        //コンボ回数が最大だったら更新
        if (m_comboCount > m_comboCountMax) m_comboCountMax = m_comboCount;

        m_continueCombo = true;
    }

    void ResetCombo()//回数リセット処理
    {
        //コンボ回数が最大だったら更新
        if(m_comboCount>m_comboCountMax) m_comboCountMax = m_comboCount;

        //コンボ回数をリセット
       // m_comboCount = m_resetComboCount;

        m_continueCombo = false;
    }
}
