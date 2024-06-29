using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChargeTrick : MonoBehaviour
{
    [Header("Å‘å‚Ü‚Å‚½‚Ü‚è‚â‚·‚­‚È‚Á‚½‚Ì”{—¦(Å‘å”{—¦)")]
    [SerializeField] float chargeRateMax=1;//Å‘å”{—¦
    [Header("Å‘å”{—¦‚É‚È‚é‚Ü‚Å‚É‚©‚©‚éŠÔ")]
    [SerializeField] float byRateMaxTime=10;//Å‘å”{—¦‚É‚È‚é‚Ü‚Å‚É‚©‚©‚éŠÔ
    private float currentChargeRate=1f;//Œ»İ‚Ì”{—¦
    private float curremtChangeChargeRateTime=0;//”{—¦‚ª•Ï‰»‚µ‚Ä‚¢‚éŠÔ

    JumpControl jumpControl;
    JudgeTouchWave judgeTouchWave;
    ChangeChargeTrickEffect changeChargeTrickEffect;

    public float CurrentChargeRate
    {
        get { return currentChargeRate; }
    }

    public float ChargeRateMax
    {
        get { return chargeRateMax; }
    }

    // Start is called before the first frame update
    void Start()
    {
        jumpControl = GetComponent<JumpControl>();
        judgeTouchWave = GetComponent<JudgeTouchWave>();
        changeChargeTrickEffect = GetComponent<ChangeChargeTrickEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeChargeRate();
    }

    bool ChangeChargeRateNow()//”g‚ÉG‚ê‚Ä‚¢‚é‚©ƒWƒƒƒ“ƒv‚µ‚Ä‚¢‚é‚É”{—¦‚ª•Ï‰»‚·‚é‚æ‚¤‚É‚·‚é
    {
        if(jumpControl.JumpNow||judgeTouchWave.TouchWaveNow)
        {
            return true; 
        }
       
        return false;
    }

    void ChangeChargeRate()
    {
        //”g‚ÉG‚ê‚Ä‚¢‚é‚©ƒWƒƒƒ“ƒv‚µ‚Ä‚¢‚éAbyRateMaxTime‚©‚¯‚Ä”{—¦‚ª1”{‚©‚çchargeRateMax”{‚Ü‚Å•Ï‰»‚·‚é
        if (ChangeChargeRateNow())
        {
            curremtChangeChargeRateTime += Time.deltaTime;
            curremtChangeChargeRateTime = Mathf.Clamp(curremtChangeChargeRateTime, 0, byRateMaxTime);

            currentChargeRate = 1 + (chargeRateMax - 1) *RatioOfChargeRate();
            currentChargeRate = Mathf.Clamp(currentChargeRate,1,chargeRateMax);

            changeChargeTrickEffect.ChangeEffectScale();
        }
        //‚»‚¤‚Å‚È‚¢A”{—¦‚ª“™”{‚É–ß‚é
        else
        {
            curremtChangeChargeRateTime = 0;
            currentChargeRate = 1f;
            changeChargeTrickEffect.ResetEffectScale();
        }
    }

    public float RatioOfChargeRate()
    {
        return curremtChangeChargeRateTime / byRateMaxTime;
    }
}
