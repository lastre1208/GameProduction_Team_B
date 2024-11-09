using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山

public class TimeLimit : MonoBehaviour
{
    [Header("▼制限時間（秒）")]
    [SerializeField] float timeLimit = 120;//制限時間(秒)
    private static float remainingTime;//残り時間
    private bool Startgame=false;
    public static float RemainingTime
    {
        get { return remainingTime; }
    }

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (Startgame)
        {
            remainingTime -= Time.deltaTime;
        }
    }
    public void EnableStart()
    {
        Startgame = true;
    }
}
