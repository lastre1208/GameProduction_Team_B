using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeleteObject : MonoBehaviour
{
    //™‰–‚ª‘‚¢‚½
    [SerializeField] float deleteTime = 4f;
    [SerializeField] UnityEvent deleteEvents;
    [SerializeField] GameObject deleteEffect;
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
            if(deleteEffect != null)
            {
                Instantiate(deleteEffect, gameObject.transform.position,Quaternion.Euler(-90,0,0));
            }
            deleteEvents.Invoke();
            Destroy(gameObject);
        }
    }
}
