using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Side : PathBase
{
    
    [SerializeField] private float sideNumber;
    [SerializeField] private float sideLimit;
    [SerializeField] private GameObject target;
   
    private bool canMove = true;
    private Vector3 move;
    public override void OnUpdate()
    {
        if (canMove)
        {
          
            float MoveDirection = Mathf.Sign(sideLimit); // sideLimit‚Ì•„†‚ğæ“¾
            if (MoveDirection < 0)
            {
                move = Vector3.left;
            }
            else
            {
               move= Vector3.right;
            }

            target.transform.Translate(sideNumber*move*Time.deltaTime);
          

            if ((MoveDirection > 0 && target.transform.position.x >= sideLimit) ||
                (MoveDirection < 0 && target.transform.position.x <= sideLimit))
            {
                canMove = false;
              
            }
        }
       
    }

    public override void OnExit(PathBase roadBases_Exit)
    {
        canMove = true;
       
    }
}


