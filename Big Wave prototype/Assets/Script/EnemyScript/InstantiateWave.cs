using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWave : MonoBehaviour
{
    //™ì¬Ò:™R
    [Header("”g‚Ì¶¬ˆÊ’u")]
    [SerializeField] GameObject instantiateWavePos;//”g‚Ì¶¬ˆÊ’u
    [Header("”g‚ÌƒvƒŒƒnƒu")]
    [SerializeField] LineWave wavePrefab;//”g‚ÌƒvƒŒƒnƒu
    [Header("”g‚ÌoŒ»ŠÔŠu")]
    [SerializeField] float waveInterval;//‰ŠúˆÈ~‚Ì”g‚ÌoŒ»ŠÔŠu
    [Header("GamePos")]
    [SerializeField] GameObject gamePos;//GamePos
    [Header("LineInstantiate")]
    [SerializeField] LineInstantiate m_lineInstantiate;
    private float m_waveTime=0;//”g‚ÌoŒ»ŠÔŠu‚ğŠÇ—‚·‚éŠÔ(“à•””’l)
    bool _switch = false;//‚±‚ê‚ªfalse‚É‚È‚Á‚Ä‚¢‚é‚Í”g‚ğ¶¬‚µ‚È‚¢Atrue‚Ì‚Í”g‚ğ¶¬‚·‚é

    public bool Switch
    {
        get { return _switch; }
        set { _switch = value; }
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateWavePrefab();//”g‚Ì¶¬
    }

    //”g‚Ì¶¬AwaveIntervalTime‚ÌŠÔ‚²‚Æ‚É”g‚ğ¶¬‚·‚é
    void InstantiateWavePrefab()
    {
        if (!_switch) return;//‚Ü‚¾ƒQ[ƒ€ŠJn‚³‚ê‚Ä‚È‚©‚Á‚½‚ç”g‚ğ¶¬‚µ‚È‚¢

        m_waveTime += Time.deltaTime;//”g‚ÌoŒ»ŠÔŠu‚ğŠÇ—‚·‚éŠÔ‚ğXV
        
        if (m_waveTime > waveInterval)
        {
            m_waveTime = 0f;//”g‚ÌoŒ»ŠÔŠu‚ğŠÇ—‚·‚éŠÔ‚ğƒŠƒZƒbƒg
            LineWave lineWave = Instantiate(wavePrefab, instantiateWavePos.transform.position, transform.rotation, gamePos.transform);//”g‚ğ¶¬
            lineWave.transform.localRotation = Quaternion.Euler(0, 180, 0);//”g‚ğŒã‚ëŒü‚«(ƒvƒŒƒCƒ„[•ûŒü)‚É‚·‚é
            m_lineInstantiate.Add(lineWave.transform);
            lineWave.GetLineInstantiate(m_lineInstantiate);
        }
    }
}
