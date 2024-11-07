using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWave : MonoBehaviour
{
    //™ì¬Ò:™R
    [Header("”g‚Ì¶¬ˆÊ’u")]
    [SerializeField] GameObject instantiateWavePos;//”g‚Ì¶¬ˆÊ’u
    [Header("”g‚ÌƒvƒŒƒnƒu")]
    [SerializeField] GameObject wavePrefab;//”g‚ÌƒvƒŒƒnƒu
    [Header("‰ŠúˆÈ~‚Ì”g‚ÌoŒ»ŠÔŠu")]
    [SerializeField] float waveInterval;//‰ŠúˆÈ~‚Ì”g‚ÌoŒ»ŠÔŠu
    [Header("‰Šú‚Ì”g‚ÌoŒ»ŠÔŠu")]
    [Tooltip("ƒQ[ƒ€ŠJn‚©‚ç1ŒÂ–Ú‚Ì”g‚ğoŒ»‚³‚¹‚é‚Ü‚Å‚ÌŠÔB1ŒÂ–Ú‚Ì”g‚ğ¶¬‚µ‚½‚ç‚»‚êˆÈ~‚Íã‚Ì‰ŠúˆÈ~‚Ì”g‚ÌoŒ»ŠÔŠu‚É‡‚í‚¹‚Ä”g‚ğ¶¬‚·‚é")]
    [SerializeField] float firstWaveInterval;//‰Šú‚Ì”g‚ÌoŒ»ŠÔŠu
    [Header("GamePos")]
    [SerializeField] GameObject gamePos;//GamePos
    [Header("LineInstantiate")]
  [SerializeField] LineInstantiate m_lineInstantiate;
   
    private float m_waveTime;//”g‚ÌoŒ»ŠÔŠu‚ğŠÇ—‚·‚éŠÔ(“à•””’l)
    JudgeGameStart judgeGameStart;
    //LineInstantiate line;

    // Start is called before the first frame update
    void Start()
    {
        //line = GameObject.FindWithTag("LineManager").GetComponent<LineInstantiate>();
        judgeGameStart=GameObject.FindWithTag("GameStartManager").GetComponent<JudgeGameStart>();
       
        //‰Šú‚Ì”g‚ÌoŒ»ŠÔŠu‚É‡‚í‚¹‚é‚½‚ß‚É”g‚ÌoŒ»ŠÔŠu‚ğŠÇ—‚·‚éŠÔ‚ğ‚»‚Ì•ª‚¸‚ç‚·
        m_waveTime = 0 - (firstWaveInterval - waveInterval);
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateWavePrefab();//”g‚Ì¶¬
    }

    //”g‚Ì¶¬AwaveIntervalTime‚ÌŠÔ‚²‚Æ‚É”g‚ğ¶¬‚·‚é
    void InstantiateWavePrefab()
    {
        if (!judgeGameStart.IsStarted) return;//‚Ü‚¾ƒQ[ƒ€ŠJn‚³‚ê‚Ä‚È‚©‚Á‚½‚ç”g‚ğ¶¬‚µ‚È‚¢

        m_waveTime += Time.deltaTime;//”g‚ÌoŒ»ŠÔŠu‚ğŠÇ—‚·‚éŠÔ‚ğXV
        
        if (m_waveTime > waveInterval)
        {
            m_waveTime = 0f;//”g‚ÌoŒ»ŠÔŠu‚ğŠÇ—‚·‚éŠÔ‚ğƒŠƒZƒbƒg
            GameObject wave = Instantiate(wavePrefab, instantiateWavePos.transform.position, transform.rotation, gamePos.transform);//”g‚ğ¶¬
            wave.transform.localRotation = Quaternion.Euler(0, 180, 0);//”g‚ğŒã‚ëŒü‚«(ƒvƒŒƒCƒ„[•ûŒü)‚É‚·‚é
            m_lineInstantiate.Method1(wave.transform);
            LineWave lineWave= wave.GetComponent<LineWave>();
            lineWave.Method1(m_lineInstantiate);
            //line.LineSet(wave.transform);
        }
    }
}
