using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬Ò:™R
//”g‚Ì¶¬
public class InstantiateWave : MonoBehaviour
{
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

    void Update()
    {
        InstantiateWavePrefab();//”g‚Ì¶¬
    }

    //”g‚Ì¶¬AwaveIntervalTime‚ÌŠÔ‚²‚Æ‚É”g‚ğ¶¬‚·‚é
    void InstantiateWavePrefab()
    {
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
