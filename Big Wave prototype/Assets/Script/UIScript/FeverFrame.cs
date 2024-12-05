using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FeverFrame : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] float colorSpeed;
    
    [SerializeField] FeverMode feverMode;

    float a;
    private void Start()
    {
        a = image.color.a;
        Debug.Log(a);
    }
    void Update()
    {
        if (feverMode.FeverNow)
        {
            if (image.enabled==false)
            {
                image.enabled=(true);
                Debug.Log("aaaa");
              
            }
            Color currentCulor = image.color;
          
            Color.RGBToHSV(currentCulor, out float h, out float s, out float v);
            h = (Time.time * colorSpeed) % 1;
            currentCulor=Color.HSVToRGB(h, s, v);    
            currentCulor.a = a;
            image.color = currentCulor;
            
        }
        else
        {
            image.enabled=(false);
        }
    }

}
