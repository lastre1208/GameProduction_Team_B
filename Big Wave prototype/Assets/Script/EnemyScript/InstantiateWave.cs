using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWave : MonoBehaviour
{
    public float Add_y;
    [SerializeField] GameObject instantiateWavePos;//”g‚Ì¶¬ˆÊ’u
    [SerializeField] GameObject outSideWave;//ŠO‘¤‚Ì”g‚ÌƒvƒŒƒnƒu
    [SerializeField] GameObject inSideWave;//“à‘¤(’†‰›)‚Ì”g‚ÌƒvƒŒƒnƒu
    [SerializeField] float outSideWaveIntervalTime = 0.1f;//ŠO‘¤‚Ì”g‚ÌoŒ»ŠÔŠu
    [SerializeField] float inSideWaveIntervalTime = 0.1f;//“à‘¤‚Ì”g‚ÌoŒ»ŠÔŠu
    private float outSideWaveTime = 0f;//ŠO‘¤‚Ì”g‚ÌoŒ»ŠÔŠu‚ðŠÇ—‚·‚éŽžŠÔ
    private float inSideWaveTime = 0f;//“à‘¤(’†‰›)‚Ì”g‚ÌoŒ»ŠÔŠu‚ðŠÇ—‚·‚éŽžŠÔ
    private Vector3 inSideWavePos;//“à‘¤‚Ì”g‚Ì¶¬ˆÊ’uAinstantiateWavePos‚æ‚è‚à­‚µ‚‚¢yÀ•W‚Å¶¬‚·‚é
    // Start is called before the first frame update
    void Start()
    {
        instantiateWavePos.transform.position = new(instantiateWavePos.transform.position.x, instantiateWavePos.transform.position.y + Add_y, instantiateWavePos.transform.position.z);
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
            Instantiate(outSideWave, instantiateWavePos.transform.position, transform.rotation);
        }
    }

    //“à‘¤(’†‰›)‚Ì”g‚Ì¶¬
    //inSideWaveIntervalTime‚ÌŽžŠÔ‚²‚Æ‚É”g‚ð¶¬‚·‚é
    void InstantiateInSideWave()
    {
        inSideWavePos = instantiateWavePos.transform.position;
        inSideWavePos.y += 0.1f;//instantiateWavePos‚æ‚è‚à­‚µ‚‚¢yÀ•W‚Å¶¬‚·‚é
        inSideWaveTime += Time.deltaTime;
        if (inSideWaveTime > inSideWaveIntervalTime)
        {
            inSideWaveTime = 0f;
            Instantiate(inSideWave, inSideWavePos, transform.rotation);
        }
    }
}
