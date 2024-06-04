using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    //™‰–‚ª‘‚¢‚½
    [HideInInspector] public bool isTouched;//ƒvƒŒƒCƒ„[‚ÉG‚ê‚ç‚ê‚½‚©
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Touched()
    {
        isTouched = true;
    }

}
