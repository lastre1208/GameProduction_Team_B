using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ì¬Ò:™R
//HP
public class HP : MonoBehaviour
{
    [Header("Å‘å‘Ì—Í")]
    [SerializeField] float hpMax = 500;//Å‘å‘Ì—Í
    private float hp = 500;//Œ»İ‚Ì‘Ì—Í
    

    public float Hp
    {
        get { return hp; }
        set 
        {
            hp = value;
            hp = Mathf.Clamp(hp, 0f, hpMax);//‘Ì—Í‚ªŒÀŠE“Ë”j‚µ‚È‚¢‚æ‚¤‚É
        }
    }

    public float HpMax
    {
        get { return hpMax; }
        set { hpMax = value; }
    }

    void Start()
    {
        //Hp‚Ì‰Šú‰»
        hp = hpMax;   
    }
}
