using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [HideInInspector] public bool isTouched;//ÉvÉåÉCÉÑÅ[Ç…êGÇÍÇÁÇÍÇΩÇ©

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
