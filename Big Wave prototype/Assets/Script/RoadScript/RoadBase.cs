using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RoadBase : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void OnEnter(RoadBase  roadBases_Entry) { }
    public virtual void OnUpdate() { }
    // Update is called once per frame

    public virtual void OnExit(RoadBase roadBases_Exit) { }
}
