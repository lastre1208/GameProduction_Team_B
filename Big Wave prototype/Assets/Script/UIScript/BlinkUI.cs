using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
public class BlinkUI : MonoBehaviour
{
    private TMP_Text T_Color;
    [SerializeField] float cycle;
    [SerializeField] JumpUI jump;
   
    private float time;
    private void Start()
    {
         T_Color=this.GetComponent<TMP_Text>();
        T_Color.enabled = true; 
      
    }
    // Update is called once per frame
    void Update()
    {
        Blink_UI();
    }
    void Blink_UI()
    {
        time += Time.deltaTime;
       
        if (time > cycle && !jump.reached)
        {
            time = 0;
            T_Color.enabled = !T_Color.enabled;
        }
        else
        {
            T_Color.enabled = true;
        }
    }
   
}
