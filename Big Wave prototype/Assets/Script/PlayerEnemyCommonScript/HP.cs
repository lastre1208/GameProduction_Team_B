using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

//ì¬Ò:™R
//HP
public class HP : MonoBehaviour
{
    [Header("Å‘å‘Ì—Í")]
    [SerializeField] float hpMax = 500;//Å‘å‘Ì—Í
    private float hp = 500;//Œ»İ‚Ì‘Ì—Í
    bool _dead=false;//€–S”»’è
    bool _fix=false;//‘Ì—Í‚ª‘Œ¸‚µ‚È‚¢‚æ‚¤ŒÅ’è
    const float _deadHp = 0;//€–SğŒc‚è‘Ì—Í
    
    public bool Fix
    {
        get { return _fix; }
        set { _fix = value; }
    }

    public float Hp
    {
        get { return hp; }
        set 
        {
            if (_fix||_dead) return;//ŒÅ’è‚Ü‚½‚Í€–S‚Í‘Ì—Í‚ğ•Ï“®‚³‚¹‚È‚¢

            hp = value;
           
            if (hp <= _deadHp && !_dead)//€–S
            {
                _dead = true;
            }

            hp = Mathf.Clamp(hp, _deadHp, hpMax);//‘Ì—Í‚ªŒÀŠE“Ë”j‚µ‚È‚¢‚æ‚¤‚É
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
