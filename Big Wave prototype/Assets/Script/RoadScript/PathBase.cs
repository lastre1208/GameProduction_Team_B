using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PathBase : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void OnEnter(PathBase  roadBases_Entry) { }
    public virtual void OnUpdate() { }
    // Update is called once per frame

    public virtual void OnExit(PathBase roadBases_Exit) { }
}
