using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//作成者:杉山
//制限時間
public class TimeLimit : MonoBehaviour
{
    [Header("▼制限時間（秒）")]
    [SerializeField] float _timeLimit = 120;//制限時間(秒)
    private float _remainingTime;//残り時間
    bool _timeUp=false;//時間切れか
    const float _timeUpRemainingTime = 0;//時間切れ条件残り時間

    public bool TimeUp { get { return _timeUp; } }

    public float RemainingTime
    {
        get { return _remainingTime; }
    }

    void Awake()
    {
        _remainingTime = _timeLimit;
    }

    void Update()
    {
       UpdateTime();
    }

    void UpdateTime()//時間の更新(スイッチがオフの時は時間を止める)
    {
        if (_timeUp) return;//スイッチがOFFまたは時間切れの時は残り時間が減らないようにする

        _remainingTime -= Time.deltaTime;

        if(_remainingTime<=_timeUpRemainingTime)//時間切れ時
        {
            _timeUp = true;
        }
    }
}
