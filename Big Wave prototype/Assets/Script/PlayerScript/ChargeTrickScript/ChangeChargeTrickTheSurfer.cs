using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

//™ì¬Ò:™R
//”g‚Éæ‚é‚Ù‚ÇƒgƒŠƒbƒN‚Ìƒ`ƒƒ[ƒW—Ê‚ª•Ï‰»‚·‚é
public class ChangeChargeTrickTheSurfer : MonoBehaviour
{
    [Header("Å‘å‚Ü‚Å‚½‚Ü‚è‚â‚·‚­‚È‚Á‚½‚Ì”{—¦(Å‘å”{—¦)")]
    [SerializeField] float chargeRateMax=1;//Å‘å”{—¦
    [Header("Å‘å”{—¦‚É‚È‚é‚Ü‚Å‚É‚©‚©‚éŠÔ")]
    [SerializeField] float byMaxRateTime=10;//Å‘å”{—¦‚É‚È‚é‚Ü‚Å‚É‚©‚©‚éŠÔ
    [Header("”{—¦‚ªŒ¸‚é‘¬“x(”{—¦‚ª‘‚¦‚é‚Ì‘¬“x‚ğ1‚Æ‚µ‚Ä)")]
    [SerializeField] float minusChargeRateSpeed;//”g‚ÉG‚ê‚Ä‚È‚¢‚©‚ÂƒWƒƒƒ“ƒv‚µ‚Ä‚¢‚È‚¢‚É”{—¦‚ªŒ¸‚é‘¬“x
    private const float normalChargeRate = 1;//“™”{
    private float currentChargeRate = normalChargeRate;//Œ»İ‚Ì”{—¦
    private float changeRatePerSecond;//1•b‚²‚Æ‚É‘‚¦‚é”{—¦—Ê

    JumpControl jumpControl;
    JudgeTouchWave judgeTouchWave;

    public float CurrentChargeRate
    {
        get { return currentChargeRate; }
    }

    public float ChargeRateMax
    {
        get { return chargeRateMax; }
    }

    public float NormalChargeRate
    {
        get { return normalChargeRate; }
    }

    // Start is called before the first frame update
    void Start()
    {
        jumpControl = GetComponent<JumpControl>();
        judgeTouchWave = GetComponent<JudgeTouchWave>();

        changeRatePerSecond = (chargeRateMax - normalChargeRate) / byMaxRateTime;
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
        //”g‚ÉG‚ê‚Ä‚¢‚é‚©ƒWƒƒƒ“ƒv‚µ‚Ä‚¢‚éAbyRateMaxTime‚©‚¯‚Ä‚¾‚ñ‚¾‚ñ”{—¦‚ª1”{‚©‚çchargeRateMax”{‚Ü‚Å•Ï‰»‚·‚é
        if (ChangeChargeRateNow())
        {
            currentChargeRate += changeRatePerSecond * Time.deltaTime;//1ƒtƒŒ[ƒ€‚²‚Æ‚É‘‚¦‚é”{—¦—Ê
        }
        //‚»‚¤‚Å‚È‚¢A”{—¦‚ªŠÔ‚²‚Æ‚ÉŒ¸‚Á‚Ä‚¢‚­
        else
        {
            currentChargeRate -= minusChargeRateSpeed * changeRatePerSecond * Time.deltaTime;//1ƒtƒŒ[ƒ€‚²‚Æ‚ÉŒ¸‚é”{—¦—Ê
        }

        currentChargeRate = Mathf.Clamp(currentChargeRate, 1, chargeRateMax);
    }
}
