using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTime : MonoBehaviour
{
    // Start is called before the first frame update

    public float time;
    // Update is called once per frame
    void Update()
    {
        time +=Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(time);
        }
        
    }
}
