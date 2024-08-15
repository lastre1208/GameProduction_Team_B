using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadAlgorithm : MonoBehaviour
{
    [SerializeField] RoadPattern firstRoadPattern;
    private float currentTime=0;
    private float roadTime;
    private RoadPattern currentroadPattern;
    private SelectOfRoad selectRoad;
    private bool waitNow = true;
    [SerializeField] float waitTime;
    private float countTime;
    // Start is called before the first frame update
    void Start()
    {
        selectRoad = GetComponent<SelectOfRoad>();
        ChangeRoad(firstRoadPattern);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!waitNow)
        {
            currentTime += Time.deltaTime;
            bool roadNow = (currentTime < roadTime);

            if (roadNow)
            {
                currentroadPattern.Roadbase.OnUpdate();
            }
            else
            {

                ChangeRoad(selectRoad.SelectRoad());

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
    void ChangeRoad(RoadPattern nextroadPattern)
    {
        if(currentroadPattern != null)
        {
            currentroadPattern.Roadbase.OnExit(nextroadPattern.Roadbase);

            nextroadPattern.Roadbase.OnEnter(currentroadPattern.Roadbase);
        }
        currentroadPattern = nextroadPattern;
        currentTime = 0;
        roadTime = nextroadPattern.RoadTime;
    }
}
