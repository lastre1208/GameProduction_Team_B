using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬Ò:™R
//”g‚ÉG‚Á‚Ä‚¢‚é‚©”»’f
public class JudgeTouchWave : MonoBehaviour
{
    [SerializeField] OnTriggerActionEvent onTriggerActionEvent;
    [SerializeField] float touchBorderTime = 0.1f;//G‚Á‚½EG‚Á‚Ä‚È‚¢‚Ì‹«ŠE‚ÌŠÔ
    private bool touchWaveNow=false;//¡”g‚ÉG‚Á‚Ä‚¢‚é‚©
    private float sinceLastTouchWaveTime = 0.1f;//ÅŒã‚É”g‚ÉG‚Á‚Ä‚©‚ç‚ÌŠÔ
   
    public bool TouchWaveNow
    {
        get { return touchWaveNow; }
    }

    // Start is called before the first frame update
    void Start()
    {
        onTriggerActionEvent.EnterAction += TouchWave;
        sinceLastTouchWaveTime = touchBorderTime;
    }

    // Update is called once per frame
    void Update()
    {
        JudgeTouchWaveNow();//”g‚ÉG‚ê‚Ä‚¢‚é‚©”»’è
    }

    public void TouchWave(Collider c)
    {
        if (c.gameObject.CompareTag("InsideWave") || c.gameObject.CompareTag("OutsideWave"))
        {
            sinceLastTouchWaveTime = 0f;//ÅŒã‚É”g‚ÉG‚Á‚Ä‚©‚ç‚ÌŠÔ‚ğXV
        }
    }

    void JudgeTouchWaveNow()//”g‚ÉG‚ê‚Ä‚¢‚é‚©”»’è
    {
        sinceLastTouchWaveTime += Time.deltaTime;

        if (sinceLastTouchWaveTime < touchBorderTime)//ÅŒã‚ÉG‚Á‚Ä‚©‚çtouchBorderTime•b–¢–‚µ‚©Œo‚Á‚Ä‚¢‚È‚¯‚ê‚Î¡”g‚ÉG‚ê‚Ä‚¢‚é”»’è
        {
            touchWaveNow = true;
        }
        else
        {
            touchWaveNow = false;
        }
    }
}
