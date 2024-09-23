using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬Ò:™R
//”g‚Éæ‚é‚Ù‚Çƒ`ƒƒ[ƒW”{—¦‚ªã‚ª‚Á‚Ä‚¢‚­
public class ChangeChargeRateTheSurfer : MonoBehaviour
{
    [Header("Å‘å‚Ü‚Å‚½‚Ü‚è‚â‚·‚­‚È‚Á‚½‚Ì”{—¦(Å‘å”{—¦)")]
    [SerializeField] float chargeRateMax = 3;//Å‘å”{—¦
    [Header("Å‘å”{—¦‚É‚È‚é‚Ü‚Å‚É‚©‚©‚éŠÔ")]
    [SerializeField] float byMaxRateTime = 10;//Å‘å”{—¦‚É‚È‚é‚Ü‚Å‚É‚©‚©‚éŠÔ
    [Header("”{—¦‚ªŒ¸‚é‘¬“x(”{—¦‚ª‘‚¦‚é‚Ì‘¬“x‚ğ1‚Æ‚µ‚Ä)")]
    [SerializeField] float minusChargeRateSpeed;//”g‚ÉG‚ê‚Ä‚È‚¢‚©‚ÂƒWƒƒƒ“ƒv‚µ‚Ä‚¢‚È‚¢‚É”{—¦‚ªŒ¸‚é‘¬“x
    private const float normalChargeRate = 1;//“™”{
    private float currentChargeRate = normalChargeRate;//Œ»İ‚Ì”{—¦
    private float changeRatePerSecond;//1•b‚²‚Æ‚É‘‚¦‚é”{—¦—Ê
    JudgeJumpNow judgeJumpNow;
    JudgeTouchWave judgeTouchWave;

    public float ChargeRateMax//Å‘åƒ`ƒƒ[ƒW”{—¦
    {
        get { return chargeRateMax; }
    }

    public float NormalChargeRate//“™”{(‰Šúó‘Ô)‚Ìƒ`ƒƒ[ƒW”{—¦
    {
        get { return normalChargeRate; }
    }

    public float ChargeRate()//Œ»İ‚Ìƒ`ƒƒ[ƒW”{—¦‚ğ•Ô‚·
    {
        return currentChargeRate;
    }

    // Start is called before the first frame update
    void Start()
    {
        judgeJumpNow = GetComponent<JudgeJumpNow>();
        judgeTouchWave = GetComponent<JudgeTouchWave>();
        changeRatePerSecond = (chargeRateMax - normalChargeRate) / byMaxRateTime;//1•b‚²‚Æ‚É‘‚¦‚é”{—¦—Ê‚ğİ’è
    }

    // Update is called once per frame
    void Update()
    {
        ChangeChargeRate();
        Debug.Log(currentChargeRate);
    }

    //ƒ`ƒƒ[ƒW”{—¦‚ğ•Ï‰»‚³‚¹‚é
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

    bool ChangeChargeRateNow()//Œ»İƒ`ƒƒ[ƒW”{—¦‚ª•Ï‰»‚µ‚Ä‚¢‚é‚©
    {
        //Œ»İƒWƒƒƒ“ƒv‚µ‚Ä‚¢‚é‚à‚µ‚­‚Í”g‚ÉG‚ê‚Ä‚¢‚é‚Æ‚«Aƒ`ƒƒ[ƒW”{—¦‚ª•Ï‰»‚·‚é
        bool chargeRateNow = (judgeJumpNow.JumpNow() || judgeTouchWave.TouchWaveNow);
        return chargeRateNow;
    }
}
