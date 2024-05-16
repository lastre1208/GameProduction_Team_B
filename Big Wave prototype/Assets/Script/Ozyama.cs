using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ozyama : MonoBehaviour
{
    [SerializeField] float deletetime = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, deletetime);
    }
}
