using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//ì¬Ò:™R
//”g‚ÉG‚Á‚Ä‚¢‚é‚©”»’f
public class JudgeTouchWave : MonoBehaviour
{
    public event Action<bool> SwitchTouchNowAction;//”g‚ÌÚGó‘Ô‚ªØ‚è‘Ö‚í‚Á‚½‚ÉŒÄ‚Ô(true‚¾‚ÆG‚ê‚½Afalse‚¾‚Æ—£‚ê‚½)
    public event Action TouchAction;//”g‚ÉG‚ê‚½uŠÔ‚ÉŒÄ‚Ô
    public event Action LeaveAction;//”g‚©‚ç—£‚ê‚½uŠÔ‚ÉŒÄ‚Ô
    [SerializeField] OnTriggerActionEvent onTriggerActionEvent;
    [SerializeField] float touchBorderTime = 0.1f;//G‚Á‚½EG‚Á‚Ä‚È‚¢‚Ì‹«ŠE‚ÌŠÔ
    private bool touchWaveNow=false;//¡”g‚ÉG‚Á‚Ä‚¢‚é‚©
    private float sinceLastTouchWaveTime = 0.1f;//ÅŒã‚É”g‚ÉG‚Á‚Ä‚©‚ç‚ÌŠÔ
   
    public bool TouchWaveNow
    {
        get { return touchWaveNow; }
    }

    void Start()
    {
        onTriggerActionEvent.EnterAction += TouchWave;
        sinceLastTouchWaveTime = touchBorderTime;
    }

    void Update()
    {
        JudgeTouchWaveNow();//”g‚ÉG‚ê‚Ä‚¢‚é‚©”»’è
    }

    public void TouchWave(Collider c)
    {
        if (c.gameObject.CompareTag("InsideWave") || c.gameObject.CompareTag("OutsideWave"))
        {
            sinceLastTouchWaveTime = 0f;//ÅŒã‚É”g‚ÉG‚Á‚Ä‚©‚ç‚ÌŠÔ‚ğXV
            touchWaveNow = true;
            //“o˜^‚µ‚½ˆ—‚ğŒÄ‚Ô
            TouchAction?.Invoke();
            SwitchTouchNowAction?.Invoke(true);
        }
    }

    void JudgeTouchWaveNow()//”g‚ÉG‚ê‚Ä‚¢‚é‚©”»’è
    {
        if (!touchWaveNow) return;

        sinceLastTouchWaveTime += Time.deltaTime;

        //ÅŒã‚É”g‚ÉG‚ê‚Ä‚©‚çtouchBorderTime•bˆÈãŒo‚Á‚½‚ç”g‚©‚ç—£‚ê‚½”»’è‚Æ‚·‚é
        if(sinceLastTouchWaveTime >= touchBorderTime)
        {
            touchWaveNow = false;
            //“o˜^‚µ‚½ˆ—‚ğŒÄ‚Ô
            LeaveAction?.Invoke();
            SwitchTouchNowAction?.Invoke(false);
        }
    }
}
