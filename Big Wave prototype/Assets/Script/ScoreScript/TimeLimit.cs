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
    bool _switch=false;//これがfalseの時は時間が減らなくなる

    public bool Switch
    {
        get { return _switch; }
        set { _switch = value; }
    }

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
       UpdateTime();
    }

    void UpdateTime()//時間の更新(スイッチがオフの時は時間を止める)
    {
        if (!_switch) return;

        remainingTime -= Time.deltaTime;
    }
}
