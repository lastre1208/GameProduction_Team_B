using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBarrier : MonoBehaviour
{
    [SerializeField] Transform _enemy;
    [SerializeField] Critical _critical;
    [SerializeField] GameObject _barrierPrefab;
    [SerializeField] float _barrierTime;

    private Queue<float> _countTime = new Queue<float>();
    void Update()
    {
        float[] _arrayTime = _countTime.ToArray();
        for (int i = 0; i < _arrayTime.Length; i++)
        {

            _arrayTime[i] -= Time.deltaTime;
            if (_arrayTime[i] < 0)
            {
                GenerateBarrier();
                _countTime.Dequeue();
            }
            else
            {
                _countTime.Dequeue();
                _countTime.Enqueue(_arrayTime[i]);
            }
        }
    }
    public void SetBarrier()
    {
        if (!_critical.CriticalNow)
        {
           _countTime.Enqueue(_barrierTime);
        }
      
    }
    private void GenerateBarrier()
    {
        Instantiate(_barrierPrefab, _enemy.transform.position + _barrierPrefab.transform.position, _barrierPrefab.transform.rotation, _enemy.parent);
    }
}
