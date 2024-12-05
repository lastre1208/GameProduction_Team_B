using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBarrier : MonoBehaviour
{
    [SerializeField] Transform _enemy;
    [SerializeField] Critical _critical;
    [SerializeField] GameObject _barrierPrefab;
    [SerializeField] float _barrierTime;

    float timeCount;
    bool Isbarrier=false;
    void Update()
    {
       
    }
    public void SetBarrier()
    {
        if (_critical.CriticalNow)
        {
  Instantiate(_barrierPrefab, _enemy.transform.position,Quaternion.identity,_enemy.parent);
        }
      
    }
}
