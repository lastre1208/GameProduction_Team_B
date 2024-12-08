using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//作成者:塩
//オブジェクトを指定数秒後に破壊
public class DeleteObject : MonoBehaviour
{
    [SerializeField] float deleteTime = 4f;
    [SerializeField] UnityEvent deleteEvents;
    private float currentDeleteTime = 0;

    void Update()
    {
        UpdateDeleteTime();
    }

    void UpdateDeleteTime()
    {
        currentDeleteTime += Time.deltaTime;

        if(currentDeleteTime>=deleteTime)
        {
            deleteEvents.Invoke();
            Destroy(gameObject);
        }
    }
}
