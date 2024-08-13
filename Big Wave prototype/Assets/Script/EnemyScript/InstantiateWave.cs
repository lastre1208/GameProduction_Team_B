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
    [Header("”g‚ÌoŒ»ŠÔŠu")]
    [SerializeField] float waveIntervalTime = 0.1f;//”g‚ÌoŒ»ŠÔŠu
    [Header("GamePos")]
    [SerializeField] GameObject gamePos;//GamePos
    private float waveTime = 0f;//”g‚ÌoŒ»ŠÔŠu‚ğŠÇ—‚·‚éŠÔ
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InstantiateWavePrefab();//”g‚Ì¶¬
    }

    //”g‚Ì¶¬AwaveIntervalTime‚ÌŠÔ‚²‚Æ‚É”g‚ğ¶¬‚·‚é
    void InstantiateWavePrefab()
    {
        waveTime += Time.deltaTime;//”g‚ÌoŒ»ŠÔŠu‚ğŠÇ—‚·‚éŠÔ‚ğXV

        if (waveTime>waveIntervalTime)
        {
            waveTime = 0f;//”g‚ÌoŒ»ŠÔŠu‚ğŠÇ—‚·‚éŠÔ‚ğƒŠƒZƒbƒg
            GameObject wave = Instantiate(wavePrefab, instantiateWavePos.transform.position, transform.rotation, gamePos.transform);//”g‚ğ¶¬
            wave.transform.rotation = Quaternion.Euler(0, 180, 0);//”g‚ğŒã‚ëŒü‚«(ƒvƒŒƒCƒ„[•ûŒü)‚É‚·‚é
        }
    }
}
