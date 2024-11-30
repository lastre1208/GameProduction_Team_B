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
    [Header("ƒQ[ƒ€I—¹‚Ì”»’f")]
    [SerializeField] JudgeGameSet gameSet;
    private float hp = 500;//Œ»İ‚Ì‘Ì—Í
    

    public float Hp
    {
        get { return hp; }
        set 
        {
            if (gameSet.GameSet) return;//ƒQ[ƒ€‚ªI—¹‚µ‚½‚ç‘Ì—Í‚ª•Ï“®‚µ‚È‚¢‚æ‚¤‚É‚·‚é

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
