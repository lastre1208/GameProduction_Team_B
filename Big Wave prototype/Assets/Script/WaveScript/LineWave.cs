using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineWave : MonoBehaviour
{
    private LineInstantiate m_lineInstantiate;

    //¶¬‚ÉŒÄ‚Ño‚·
    public void Method1(LineInstantiate lineInstantiate)
    {
        m_lineInstantiate = lineInstantiate;
    }

    //Á‹‚ÉŒÄ‚Ño‚·
    public void Method2()
    {
        m_lineInstantiate.Method2();
    }
}
