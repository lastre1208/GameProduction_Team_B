using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWave : MonoBehaviour
{
    //™ì¬ŽÒ:™ŽR
    [SerializeField] GameObject instantiateWavePos;//”g‚Ì¶¬ˆÊ’u
    [SerializeField] GameObject outSideWave;//ŠO‘¤‚Ì”g‚ÌƒvƒŒƒnƒu
    [SerializeField] GameObject inSideWave;//“à‘¤(’†‰›)‚Ì”g‚ÌƒvƒŒƒnƒu
    [SerializeField] float outSideWaveIntervalTime = 0.1f;//ŠO‘¤‚Ì”g‚ÌoŒ»ŠÔŠu
    [SerializeField] float inSideWaveIntervalTime = 0.1f;//“à‘¤‚Ì”g‚ÌoŒ»ŠÔŠu
    [SerializeField] GameObject gamePos;
    private float outSideWaveTime = 0f;//ŠO‘¤‚Ì”g‚ÌoŒ»ŠÔŠu‚ðŠÇ—‚·‚éŽžŠÔ
    private float inSideWaveTime = 0f;//“à‘¤(’†‰›)‚Ì”g‚ÌoŒ»ŠÔŠu‚ðŠÇ—‚·‚éŽžŠÔ
    private Vector3 inSideWavePos;//“à‘¤‚Ì”g‚Ì¶¬ˆÊ’uAinstantiateWavePos‚æ‚è‚à­‚µ‚‚¢yÀ•W‚Å¶¬‚·‚é
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InstantiateOutSideWave();//ŠO‘¤‚Ì”g‚Ì¶¬   
        InstantiateInSideWave();//“à‘¤(’†‰›)‚Ì”g‚Ì¶¬
    }

    //ŠO‘¤‚Ì”g‚Ì¶¬
    //outSideWaveIntervalTime‚ÌŽžŠÔ‚²‚Æ‚É”g‚ð¶¬‚·‚é
    void InstantiateOutSideWave()
    {
        outSideWaveTime += Time.deltaTime;
        if (outSideWaveTime > outSideWaveIntervalTime)
        {
            outSideWaveTime = 0f;
            GameObject wave= Instantiate(outSideWave, instantiateWavePos.transform.position, transform.rotation,gamePos.transform);
            wave.transform.rotation = Quaternion.Euler(0,180,0);
        }
    }

    //“à‘¤(’†‰›)‚Ì”g‚Ì¶¬
    //inSideWaveIntervalTime‚ÌŽžŠÔ‚²‚Æ‚É”g‚ð¶¬‚·‚é
    void InstantiateInSideWave()
    {
        inSideWavePos = instantiateWavePos.transform.position;//”g‚Ì”­¶ˆÊ’u‚ðŽæ“¾
        inSideWavePos.y += 0.1f;//instantiateWavePos‚æ‚è‚à­‚µ‚‚¢yÀ•W‚Å¶¬‚·‚é
        inSideWaveTime += Time.deltaTime;
        if (inSideWaveTime > inSideWaveIntervalTime)
        {
            inSideWaveTime = 0f;
            GameObject wave = Instantiate(inSideWave, inSideWavePos, transform.rotation,gamePos.transform);
            wave.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
