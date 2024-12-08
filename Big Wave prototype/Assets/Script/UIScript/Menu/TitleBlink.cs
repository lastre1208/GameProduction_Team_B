using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBlink : MonoBehaviour
{
    [SerializeField] Image Title;
    [SerializeField] float blinkSpeed;
    [SerializeField] float blinkMin;
    [SerializeField] float blinkMax;
    private float nowValue;
    private bool Isblink=true;

    private void Start()
    {
          nowValue = Title.color.a;
    }

    void Update()
    {
      
        SetBlink();
        Blinking();
    }
    void SetBlink()
    {
        if (nowValue <= blinkMin)
        {
            Isblink = false;
        }
        else if(nowValue >= blinkMax) 
        {
            Isblink = true;
        }
    }
    void Blinking()
    {
        if (Isblink)
        {
            nowValue-=blinkSpeed*Time.deltaTime;
        }
        else
        {
            nowValue+=blinkSpeed*Time.deltaTime;
        }
        GetBlink();
    }
    void GetBlink()
    {
        Color color = Title.color;

        color.a = nowValue;
        Title.color = color;
       
    }
}
