using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] CurrentStageData currentStageData;

    void Update()
    {
        Debug.Log(currentStageData.StageID);
    }
}
