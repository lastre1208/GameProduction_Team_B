using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//çÏê¨é“ÅFåKå¥

public class InstantiatePlayerWaterSplash : InstantiateWaterSplash
{
    [SerializeField] GameObject player;

    JudgeJumpNow judgeJumpNow;

    // Start is called before the first frame update
    void Start()
    {
        judgeJumpNow = player.GetComponent<JudgeJumpNow>();
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateWaterSplashParticle();
    }

    protected override void InstantiateWaterSplashParticle()
    {
        if (judgeJumpNow != null && !judgeJumpNow.JumpNow())
        {
            Instantiate(waterSplashParticle, transform.position, transform.rotation);

        }
    }
}
