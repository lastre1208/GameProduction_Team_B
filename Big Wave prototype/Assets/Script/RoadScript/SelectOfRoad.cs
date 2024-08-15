using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RoadPattern
{
    [SerializeField] RoadBase roadbase;

    [SerializeField] float Roadprobability;
    [SerializeField] float roadTime;


    public RoadBase Roadbase
    {
        get
        {
            return roadbase;
        }
    }
    public float RoadProbability
    {
        get
        {
            return Roadprobability;
        }
    }
    public float RoadTime
    {
        get
        {
            return roadTime;
        }
    }
}

public class SelectOfRoad : MonoBehaviour
{
    [SerializeField] RoadPattern[] roadPatterns;
    private float totalProbabilitySum;

    void Start()
    {
        totalProbabilitySum = 0f;

        // 各パターンの確率の合計を計算
        foreach (var pattern in roadPatterns)
        {
            totalProbabilitySum += pattern.RoadProbability;
        }
    }

    public RoadPattern SelectRoad()
    {
        if (roadPatterns == null || roadPatterns.Length == 0)
        {
            Debug.LogError("No road patterns available.");
            return null;
        }

        float randomValue = Random.Range(0f, totalProbabilitySum);
        float cumulativeProbability = 0f;

        foreach (var pattern in roadPatterns)
        {
            cumulativeProbability += pattern.RoadProbability;
            if (randomValue <= cumulativeProbability)
            {
                
                return pattern;
               
            }
        }

        // Fallback (should not happen if probabilities are correctly set)
        Debug.LogWarning("Fallback to last pattern. Probabilities might not be correctly set.");
        return roadPatterns[roadPatterns.Length - 1];
    }
}
