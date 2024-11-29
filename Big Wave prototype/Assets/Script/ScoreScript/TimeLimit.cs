using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//制限時間
public class TimeLimit : MonoBehaviour
{
    [Header("▼制限時間（秒）")]
    [SerializeField] float timeLimit = 120;//制限時間(秒)
    private float remainingTime;//残り時間
    private bool startGame=false;
    public float RemainingTime
    {
        get { return remainingTime; }
    }

    void Start()
    {
        remainingTime = timeLimit;
    }

    void Update()
    {
        if (startGame)
        {
            remainingTime -= Time.deltaTime;
        }
    }
    public void EnableStart()
    {
        startGame = true;
    }
}
