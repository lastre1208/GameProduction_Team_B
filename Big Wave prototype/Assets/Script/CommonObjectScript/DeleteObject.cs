using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeleteObject : MonoBehaviour
{
    //™‰–‚ª‘‚¢‚½
    [SerializeField] float deleteTime = 4f;
    [SerializeField] UnityEvent deleteEvents;
    private float currentDeleteTime = 0;
   
    void Start()
    {
        
    }

    // Update is called once per frame
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
