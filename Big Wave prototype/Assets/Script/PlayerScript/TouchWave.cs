using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchWave : MonoBehaviour
{
    [HideInInspector] public bool touchWaveNow=false;//¡”g‚ÉG‚Á‚Ä‚¢‚é‚©
    private float sinceLastTouchWaveTime = 0.1f;//ÅŒã‚É”g‚ÉG‚Á‚Ä‚©‚ç‚ÌŠÔ
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        JudgeTouchWave();////”g‚ÉG‚ê‚Ä‚¢‚é‚©”»’è
    }

    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.CompareTag("InsideWave") || t.gameObject.CompareTag("OutsideWave"))//”g‚ÉG‚ê‚Ä‚¢‚é‚È‚çWave‚Ìî•ñ(isTouched)‚ğæ“¾
        {
            sinceLastTouchWaveTime = 0f;//ÅŒã‚É”g‚ÉG‚Á‚Ä‚©‚ç‚ÌŠÔ
        }
    }

    void JudgeTouchWave()//”g‚ÉG‚ê‚Ä‚¢‚é‚©”»’è
    {
        sinceLastTouchWaveTime += Time.deltaTime;

        if (sinceLastTouchWaveTime < 0.1f)
        {
            touchWaveNow = true;
        }
        else
        {
            touchWaveNow = false;
        }
    }
}
