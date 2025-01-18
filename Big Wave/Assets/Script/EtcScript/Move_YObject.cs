using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_YObject : MonoBehaviour
{
    [SerializeField] float Max_Y;
    [SerializeField] float Min_Y;
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(0, Random.Range(Min_Y, Max_Y), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
