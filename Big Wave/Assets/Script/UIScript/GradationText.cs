using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GradationText : MonoBehaviour
{
    // Start is called before the first frame update
   
    [SerializeField] TMP_Text _text;
    [SerializeField] float colorSpeed;

    

   
    // Update is called once per frame
    void Update()
    {
        Color currentCulor = _text.color;

        Color.RGBToHSV(currentCulor, out float h, out float s, out float v);
        h = (Time.time * colorSpeed) % 1;
        currentCulor = Color.HSVToRGB(h, s, v);
       
        _text.color = currentCulor;
    }
}
