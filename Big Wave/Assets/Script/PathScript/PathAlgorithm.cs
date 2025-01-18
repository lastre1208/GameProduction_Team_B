using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathAlgorithm : MonoBehaviour
{
    [SerializeField] PathPattern firstPathPattern;
    private float currentTime=0;
    private float pathTime;
    private PathPattern currentpathPattern;
    private SelectOfPath selectPath;
    private bool waitNow = true;
    [SerializeField] float waitTime;
    private float countTime;
    // Start is called before the first frame update
    void Start()
    {
        selectPath = GetComponent<SelectOfPath>();
        ChangePath(firstPathPattern);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!waitNow)
        {
            currentTime += Time.deltaTime;
            bool roadNow = (currentTime < pathTime);

            if (roadNow)
            {
                currentpathPattern.Pathbase.OnUpdate();
            }
            else
            {

                ChangePath(selectPath.SelectPath());

            }
        }
        else
        {
           countTime += Time.deltaTime;
            if(countTime > waitTime) {
                countTime = 0;
                waitNow = false;
               
            }
        }
    }
    void ChangePath(PathPattern nextpathPattern)
    {
        if(currentpathPattern != null)
        {
            currentpathPattern.Pathbase.OnExit(nextpathPattern.Pathbase);

            nextpathPattern.Pathbase.OnEnter(currentpathPattern.Pathbase);
        }
        currentpathPattern = nextpathPattern;
        currentTime = 0;
        pathTime = nextpathPattern.PathTime;
    }
}
