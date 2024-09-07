using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PathPattern
{
    [SerializeField] PathBase pathbase;

    [SerializeField] float Pathprobability;
    [SerializeField] float PathTime;


    public PathBase Pathbase
    {
        get
        {
            return pathbase;
        }
    }
    public float PathProbability
    {
        get
        {
            return Pathprobability;
        }
    }
    public float pathTime
    {
        get
        {
            return PathTime;
        }
    }
}

public class SelectOfPath : MonoBehaviour
{
    [SerializeField] PathPattern[] pathPatterns;
    private float totalProbabilitySum;

    void Start()
    {
        totalProbabilitySum = 0f;

        // 各パターンの確率の合計を計算
        foreach (var pattern in pathPatterns)
        {
            totalProbabilitySum += pattern.PathProbability;
        }
    }

    public PathPattern SelectPath()
    {
        if (pathPatterns == null || pathPatterns.Length == 0)
        {
            Debug.LogError("No road patterns available.");
            return null;
        }

        float randomValue = Random.Range(0f, totalProbabilitySum);
        float cumulativeProbability = 0f;

        foreach (var pattern in pathPatterns)
        {
            cumulativeProbability += pattern.PathProbability;
            if (randomValue <= cumulativeProbability)
            {
                
                return pattern;
               
            }
        }

        // Fallback (should not happen if probabilities are correctly set)
        Debug.LogWarning("Fallback to last pattern. Probabilities might not be correctly set.");
        return pathPatterns[pathPatterns.Length - 1];
    }
}
